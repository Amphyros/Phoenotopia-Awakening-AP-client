using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using PhoA_AP_client.util;
using UnityEngine;

namespace PhoA_AP_client.AP;

public class ItemHandler
{
    private readonly APSessionContext _sessionContext;
    public ReadOnlyCollection<long> LocalAllLocations { get; private set; }
    public ReadOnlyCollection<long> LocalAllLocationsChecked { get; private set; }
    public readonly HashSet<long> SuppressedItemMessages = [];

    public ItemHandler(APSessionContext sessionContext)
    {
        _sessionContext = sessionContext;
        ScoutItems();
        _sessionContext.Session.Items.ItemReceived += AddMissingItems;
        LocalAllLocations = _sessionContext.Session.Locations.AllLocations;
        LocalAllLocationsChecked = _sessionContext.Session.Locations.AllLocationsChecked;
    }

    public void RemoveEventHandlers()
    {
        _sessionContext.Session.Items.ItemReceived -= AddMissingItems;
    }

    public void AddMissingItems(ReceivedItemsHelper helper = null)
    {
        if (!APHelpers.IsConnectedToAP()) return;

        LocalAllLocationsChecked = _sessionContext.Session.Locations.AllLocationsChecked;

        if (LevelBuildLogic.level_name.Equals("game_start")) return;
        if (LevelBuildLogic.level_name.Equals("limbo")) return;
        if (LevelBuildLogic.level_name.StartsWith("cutscene")) return;

        List<long> saveItems = new List<long>(APSaveState.CollectedItems);
        var apItems = helper?.AllItemsReceived ?? _sessionContext.Session.Items.AllItemsReceived;

        foreach (ItemInfo apItem in apItems)
        {
            long id = apItem.ItemId;
            if (saveItems.Remove(id)) continue;

            APSaveState.CollectedItems.Add(id);

            MainThreadDispatcher.RunPerFrameActionOnMainThread(() =>
            {
                AddItemToGame(id, apItem);
                ShowItemMessage(id, apItem);
            });
        }
    }

    private void AddItemToGame(long id, ItemInfo apItem)
    {
        if (PT2.save_file.HowMuchCanBeAdded((int)id, 1) > 0)
        {
            bool ignoreCutscene = apItem.Player.Name != _sessionContext.Session.Players.ActivePlayer.Name;
            PT2.save_file.AddItemToolOrStatusIdToInventory((int)id, 1, ignoreCutscene);

            if (ignoreCutscene) ApplyHealthOrStaminaUpgrade(id);
            return;
        }

        MainThreadDispatcher.EnqueueNonMapLevelAction(() =>
        {
            PT2.item_gen.SpawnLoot((int)id, 1, PT2.gale_script.GetTransform().position, "", Vector2.zero);
        });
    }

    private void ApplyHealthOrStaminaUpgrade(long id)
    {
        string gisCommand = id switch
        {
            3 => "apply_upgrade,HEALTH_UPGRADE|FILE_INTEGER_ADD,2,1",
            4 => "apply_upgrade,STAMINA_UPGRADE|FILE_INTEGER_ADD,3,1",
            _ => ""
        };
        MainThreadDispatcher.RunOnMainThread(() =>
        {
            PT2.GIS_ProcessInstructions(gisCommand, PT2.gale_script.GetTransform().position);
        });
    }

    private void ShowItemMessage(long id, ItemInfo apItem)
    {
        if (SuppressedItemMessages.Remove(id)) return;

        string itemName = apItem.ItemDisplayName;
        if ((apItem.Flags & ItemFlags.Advancement) != 0) itemName = "<sprite=30>" + itemName;

        string message = $"Found {itemName}";
        if (apItem.Player.Name != _sessionContext.Session.Players.ActivePlayer.Name)
            message = $"Received {itemName} from {apItem.Player.Name}";

        PT2.sound_g.PlayGlobalCommonSfx(133, 1f, 1f, 2);
        PT2.display_messages.DisplayMessage(message, DisplayMessagesLogic.MSG_TYPE.SMALL_ITEM_GET);
    }

    public void OnLocationChecked()
    {
        LocalAllLocationsChecked = _sessionContext.Session.Locations.AllLocationsChecked;
    }

    private void ScoutItems()
    {
        _sessionContext.Session.Locations.ScoutLocationsAsync(
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
            _sessionContext.Session.Locations.AllLocations.ToArray()
        );
    }
}