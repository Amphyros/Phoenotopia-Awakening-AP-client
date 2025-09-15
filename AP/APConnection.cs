using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using PhoA_AP_client.util;

namespace PhoA_AP_client.AP;

public class APConnection
{
    public ArchipelagoSession Session { get; private set; }

    public void Connect(string host, int port, string slot, string password = null)
    {
        PhoaAPClient.Logger.LogDebug("Connect() called");

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
                    PhoaAPClient.Logger.LogError(error);
                return;
            }

            LoginSuccessful loginSuccess = (LoginSuccessful)result;

            PhoaAPClient.Logger.LogInfo($"Succesfully connected to AP server: {loginSuccess}");
            ScoutItems();
            Session.Items.ItemReceived += AddMissingItems;
        }
        catch (Exception ex)
        {
            PhoaAPClient.Logger.LogError(ex.Message);
        }
    }

    public void Disconnect()
    {
        if (Session == null) return;

        Session.Items.ItemReceived -= AddMissingItems;
        Session?.Socket.Disconnect();
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
                string player = apItems[i].Player.Name;

                MainThreadDispatcher.RunOnMainThread(() =>
                {
                    PT2.save_file.AddItemToolOrStatusIdToInventory((int)id, 1);
                    PT2.sound_g.PlayGlobalCommonSfx(133, 1f, 1f, 2);
                    PT2.display_messages.DisplayMessage(
                        $"Recevied {itemName} from {player}",
                        DisplayMessagesLogic.MSG_TYPE.SMALL_ITEM_GET
                    );
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
                PhoaAPClient.Logger.LogDebug("Scouting locations...");

                foreach (var level in LocationMapping.LocationMap)
                {
                    string levelName = level.Key;
                    List<Check> checks = level.Value;

                    foreach (Check check in checks)
                    {
                        if (!result.TryGetValue(check.ArchipelagoId, out ScoutedItemInfo itemInfo)) continue;

                        PhoaAPClient.Logger.LogDebug(
                            $"{check.ArchipelagoId} has item {itemInfo.ItemName} ({itemInfo.ItemId})");

                        string replacementId = itemInfo.ItemId.ToString();
                        PhoaAPClient.Logger.LogDebug($"{itemInfo.ItemGame}");

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
}