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

public class APConnection
{
    public ArchipelagoSession Session { get; private set; }
    private Thread _connectionThread;
    private bool _keepTrying;

    private string _host = "localhost";
    private int _port = 38281;
    private string _slot = "Lenamphy";
    private string _password = null;

    public void Connect()
    {
        PhoaAPClient.Logger.LogDebug("Connect() called");
        Disconnect();

        _keepTrying = true;
        _connectionThread = new Thread(() =>
        {
            while (_keepTrying)
            {
                try
                {
                    Session = ArchipelagoSessionFactory.CreateSession(_host, _port);
                    
                    LoginResult result =
                        Session.TryConnectAndLogin(
                            "Phoenotopia: Awakening",
                            _slot,
                            ItemsHandlingFlags.AllItems,
                            password: _password
                        );
                    if (!result.Successful)
                    {
                        var failure = (LoginFailure)result;
                        foreach (var error in failure.Errors)
                            PhoaAPClient.Logger.LogError($"Failed to connect: {error}. Retrying in 5s...");
                        Thread.Sleep(5000);
                        continue;
                    }
                    
                    Session.Socket.SocketClosed += OnSocketClosed;
                    
                    var loginSuccess = (LoginSuccessful)result;
                    PhoaAPClient.Logger.LogInfo($"Succesfully connected to AP server as slot: {loginSuccess.Slot}");
                    
                    ScoutItems();
                    Session.Items.ItemReceived += AddMissingItems;
                    
                    return;
                }
                catch (Exception ex)
                {
                    PhoaAPClient.Logger.LogError($"Could not connect: {ex.Message}. Retrying in 5s...");
                }
                
                Thread.Sleep(5000);
            }
        });
        
        _connectionThread.IsBackground = true;
        _connectionThread.Start();
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
        if (Session == null) return;

        if (PT2.level_load_in_progress) return; // Depends on game behaviour when receiving an item when loading a level
        if (LevelBuildLogic.level_name.Equals("game_start")) return;
        if (LevelBuildLogic.level_name.StartsWith("cutscene")) return;
        // if (PT2.game_paused) return; Depends on game behaviour when receiving an item in the pause menu

        List<long> saveItems = new List<long>(APSaveState.CollectedItems);
        var apItems = helper?.AllItemsReceived ?? Session.Items.AllItemsReceived;

        for (int i = 0; i < apItems.Count; i++)
        {
            long id = apItems[i].ItemId;
            if (!saveItems.Remove(id))
            {
                APSaveState.CollectedItems.Add(id);
                PhoaAPClient.Logger.LogDebug($"Item {id} added.");
                
                string itemName = apItems[i].ItemDisplayName;
                if ((apItems[i].Flags & ItemFlags.Advancement) != 0) itemName = "<sprite=30>" + itemName;
                
                string player = apItems[i].Player.Name;
                string message = $"Received {itemName} from {player}";
                if (apItems[i].Player.Name == _slot) message = $"Found {itemName}";

                bool ignoreCutscene = apItems[i].Player.Name != _slot;
                
                MainThreadDispatcher.RunOnMainThread(() =>
                {
                    PT2.save_file.AddItemToolOrStatusIdToInventory((int)id, 1, ignoreCutscene);
                    PT2.sound_g.PlayGlobalCommonSfx(133, 1f, 1f, 2);
                    PT2.display_messages.DisplayMessage(message, DisplayMessagesLogic.MSG_TYPE.SMALL_ITEM_GET);
                });

                PhoaAPClient.Logger.LogInfo($"Item {id} was added to the itempool");
            }
        }
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

                    foreach (Check check in checks)
                    {
                        if (!result.TryGetValue(check.ArchipelagoId, out ScoutedItemInfo itemInfo)) continue;

                        // PhoaAPClient.Logger.LogDebug(
                        //     $"{check.ArchipelagoId} has item {itemInfo.ItemName} ({itemInfo.ItemId})");

                        string replacementId = itemInfo.ItemId.ToString();
                        // PhoaAPClient.Logger.LogDebug($"{itemInfo.ItemGame}");

                        if (!string.Equals(itemInfo.ItemGame, "Phoenotopia: Awakening"))
                        {
                            replacementId = 215.ToString();
                            if ((itemInfo.Flags & ItemFlags.NeverExclude) != 0) replacementId = 214.ToString();
                            if ((itemInfo.Flags & ItemFlags.Advancement) != 0) replacementId = 213.ToString();
                        }


                        if (check.OverrideType.Contains("%ItemId%"))
                            check.OverrideType = check.OverrideType.Replace("%ItemId%", replacementId);
                    }
                }
            },
            false,
            Session.Locations.AllLocations.ToArray()
        );
    }

    private void OnSocketClosed(string reason)
    {
        PhoaAPClient.Logger.LogWarning($"Lost connection with the AP server: {reason}. Trying to Reconnect...");
        Connect();
    }
}