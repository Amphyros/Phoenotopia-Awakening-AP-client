using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using PhoA_AP_client.util;

namespace PhoA_AP_client.AP;

public class APConnection(string host, int port, string slot, string password)
{
    public ArchipelagoSession Session { get; private set; }
    private Thread _connectionThread;
    private bool _keepTrying;

    public ReadOnlyCollection<long> LocalAllLocations { get; private set; }
    public ReadOnlyCollection<long> LocalAllLocationsChecked { get; private set; }

    public void ConnectAsync()
    {
        EndConnectionProcess();
        _keepTrying = true;
        _connectionThread = new Thread(() =>
        {
            while (_keepTrying)
            {
                if (Connect())
                    return;

                try
                {
                    Thread.Sleep(5000);
                }
                catch (ThreadInterruptedException)
                {
                    return;
                }
            }
        });

        _connectionThread.IsBackground = true;
        _connectionThread.Start();
    }

    public bool Connect()
    {
        PhoaAPClient.Logger.LogDebug("Connect() called");
        if (APHelpers.IsConnectedToAP()) return false;
        try
        {
            Session = ArchipelagoSessionFactory.CreateSession(host, port);

            LoginResult result =
                Session.TryConnectAndLogin(
                    "Phoenotopia: Awakening",
                    slot,
                    ItemsHandlingFlags.AllItems,
                    password: password
                );
            if (!result.Successful)
            {
                var failure = (LoginFailure)result;
                foreach (var error in failure.Errors)
                    PhoaAPClient.Logger.LogError($"Failed to connect: {error}. Retrying in 5s...");
                return false;
            }

            Session.Socket.SocketClosed += OnSocketClosed;

            var loginSuccess = (LoginSuccessful)result;
            PhoaAPClient.Logger.LogInfo($"Succesfully connected to AP server as slot: {loginSuccess.Slot}");

            // ExecuteStoredAPInstructions();
            ScoutItems();
            Session.Items.ItemReceived += AddMissingItems;
            LocalAllLocations = Session.Locations.AllLocations;
            LocalAllLocationsChecked = Session.Locations.AllLocationsChecked;
            
            MainThreadDispatcher.RunOnMainThread(() =>
            {
                PT2.sound_g.PlayGlobalCommonSfx(126, 1f, 1f, 2);
                PT2.display_messages.DisplayMessage("Connected to Archipelago!",
                    DisplayMessagesLogic.MSG_TYPE.GALE_PLUS_STATUS);
            });

            return true;
        }
        catch (Exception ex)
        {
            PhoaAPClient.Logger.LogError($"Could not connect: {ex.Message}. Retrying in 5s...");
        }

        return false;
    }

    public void EndConnectionProcess()
    {
        _keepTrying = false;
        if (_connectionThread != null && _connectionThread.IsAlive)
        {
            _connectionThread.Interrupt();
            _connectionThread.Join();
        }

        _connectionThread = null;
        Disconnect();
        Session = null;
    }

    public void Disconnect()
    {
        _keepTrying = false;
        if (Session == null) return;

        Session.Items.ItemReceived -= AddMissingItems;
        Session.Socket.SocketClosed -= OnSocketClosed;
        Session.Socket.Disconnect();
    }

    public void AddMissingItems(ReceivedItemsHelper helper = null)
    {
        if (!APHelpers.IsConnectedToAP()) return;

        LocalAllLocationsChecked = Session.Locations.AllLocationsChecked;

        if (LevelBuildLogic.level_name.Equals("game_start")) return;
        if (LevelBuildLogic.level_name.StartsWith("cutscene")) return;

        List<long> saveItems = new List<long>(APSaveState.CollectedItems);
        var apItems = helper?.AllItemsReceived ?? Session.Items.AllItemsReceived;

        for (int i = 0; i < apItems.Count; i++)
        {
            long id = apItems[i].ItemId;
            if (saveItems.Remove(id)) continue;

            APSaveState.CollectedItems.Add(id);

            string itemName = apItems[i].ItemDisplayName;
            if ((apItems[i].Flags & ItemFlags.Advancement) != 0) itemName = "<sprite=30>" + itemName;

            string player = apItems[i].Player.Name;
            string message = $"Received {itemName} from {player}";
            if (apItems[i].Player.Name == slot) message = $"Found {itemName}";

            bool ignoreCutscene = apItems[i].Player.Name != slot;

            MainThreadDispatcher.RunOnMainThread(() =>
            {
                PT2.save_file.AddItemToolOrStatusIdToInventory((int)id, 1, ignoreCutscene);
                PT2.sound_g.PlayGlobalCommonSfx(133, 1f, 1f, 2);
                PT2.display_messages.DisplayMessage(message, DisplayMessagesLogic.MSG_TYPE.SMALL_ITEM_GET);
            });

            PhoaAPClient.Logger.LogDebug($"Item {id} was added to the itempool");

            if (!apItems[i].ItemName.ToLower().Equals("moonstone")) return;
            MainThreadDispatcher.RunOnMainThread(() => { PT2.sound_g.PlayGlobalCommonSfx(145, 1f, 1f, 2); });
        }
    }

    public void OnLocationChecked(ScoutedItemInfo itemInfo)
    {
        LocalAllLocationsChecked = Session.Locations.AllLocationsChecked;

        string itemName = itemInfo.ItemDisplayName;
        string playerName = itemInfo.Player.Name;

        if (playerName == slot) return;

        if ((itemInfo.Flags & ItemFlags.Advancement) != 0) itemName = "<sprite=30>" + itemName;

        string message = $"Found {playerName}'s {itemName}";

        MainThreadDispatcher.RunOnMainThread(() =>
        {
            PT2.sound_g.PlayGlobalCommonSfx(133, 1f, 1f, 2);
            PT2.display_messages.DisplayMessage(message, DisplayMessagesLogic.MSG_TYPE.SMALL_ITEM_GET);
        });

        if (!itemInfo.ItemName.ToLower().Equals("moonstone")) return;
        MainThreadDispatcher.RunOnMainThread(() => { PT2.sound_g.PlayGlobalCommonSfx(145, 1f, 1f, 2); });
    }

    private void ScoutItems()
    {
        Session.Locations.ScoutLocationsAsync(
            result =>
            {
                foreach (var level in LocationMapping.LocationMap)
                {
                    string levelName = level.Key;
                    List<Check> checks = level.Value;

                    for (int i = 0; i < checks.Count; i++)
                    {
                        if (!result.TryGetValue(checks[i].ArchipelagoId, out ScoutedItemInfo itemInfo)) continue;

                        LocationMapping.LocationMap[levelName][i].ItemInfo = itemInfo;

                        string replacementId = itemInfo.ItemId.ToString();

                        if (!string.Equals(itemInfo.ItemGame, "Phoenotopia: Awakening"))
                        {
                            replacementId = 215.ToString();
                            if ((itemInfo.Flags & ItemFlags.NeverExclude) != 0) replacementId = 214.ToString();
                            if ((itemInfo.Flags & ItemFlags.Advancement) != 0) replacementId = 213.ToString();
                        }

                        if (checks[i].OverrideType.Contains("%ItemId%"))
                            checks[i].OverrideType = checks[i].OverrideType.Replace("%ItemId%", replacementId);
                    }
                }
            },
            false,
            Session.Locations.AllLocations.ToArray()
        );
    }

    private void OnSocketClosed(string reason)
    {
        MainThreadDispatcher.RunOnMainThread(() =>
        {
            PT2.sound_g.PlayGlobalCommonSfx(157, 1f, 1f, 2);
            PT2.display_messages.DisplayMessage("Lost connection with a AP server",
                DisplayMessagesLogic.MSG_TYPE.GALE_MINUS_STATUS);
        });
        PhoaAPClient.Logger.LogWarning($"Lost connection with the AP server: {reason}. Trying to Reconnect...");
        ConnectAsync();
    }
}