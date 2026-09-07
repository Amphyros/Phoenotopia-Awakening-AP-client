using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using PhoA_AP_client.util;
using PhoA_AP_client.util.DataClasses;
using UnityEngine;
using WebSocketSharp;

namespace PhoA_AP_client.AP;

public class ItemHandler
{
    public DialogHandler DialogHandler { get; private set; }
    private readonly APSessionContext _sessionContext;
    public FillMode FillMode { get; private set; }
    public ReadOnlyCollection<long> LocalAllLocations { get; private set; }
    public ReadOnlyCollection<long> LocalAllLocationsChecked { get; private set; }
    public readonly HashSet<long> SuppressedItemMessages = [];
    public readonly HashSet<long> SuppressedItemAddition = [];

    private readonly HashSet<long> _preAddedItems = [];
    private static readonly Regex ItemLinkRegex = new(@"%ItemLink\$\d+%");

    private static readonly Dictionary<long, int[]> UpgradeChains = new()
    {
        { 292, [127, 216] },
        { 293, [6, 7, 8, 9] },
        { 294, [30, 28] },
        { 295, [31, 44] },
        { 296, [32, 43] },
        { 297, [33, 17] },
        { 298, [37, 38] },
        { 299, [40, 41] }
    };

    public ItemHandler(APSessionContext sessionContext)
    {
        _sessionContext = sessionContext;
        DialogHandler = new DialogHandler();
        if (PhoaAPClient.APConnection.Seed.IsNullOrEmpty())
            ScoutItems();
        _sessionContext.Session.Items.ItemReceived += AddMissingItems;
        FillMode = (long)_sessionContext.Login.SlotData["keep_excluded_status_upgrades_in_item_pool"] >= 1
            ? FillMode.StatusUpgrade
            : FillMode.Always;
        LocalAllLocations = _sessionContext.Session.Locations.AllLocations;
        LocalAllLocationsChecked = _sessionContext.Session.Locations.AllLocationsChecked;
    }

    public void RemoveEventHandlers()
    {
        _sessionContext.Session.Items.ItemReceived -= AddMissingItems;
    }

    public void PreAddItem(long id, ItemInfo apItem)
    {
        if (LevelBuildLogic.level_name.Equals("game_start")) return;
        if (LevelBuildLogic.level_name.Equals("limbo")) return;
        if (LevelBuildLogic.level_name.StartsWith("cutscene")) return;

        _preAddedItems.Add(apItem.ItemId);

        MainThreadDispatcher.RunPerFrameActionOnMainThread(() =>
        {
            AddItemToGame(id, apItem);
            ShowItemMessage(id, apItem);
        });
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

            if (_preAddedItems.Contains(apItem.ItemId))
            {
                _preAddedItems.Remove(apItem.ItemId);
                continue;
            }

            MainThreadDispatcher.RunPerFrameActionOnMainThread(() =>
            {
                AddItemToGame(id, apItem);
                ShowItemMessage(id, apItem);
            });
        }
    }

    public long HandleUpgradableItems(long id)
    {
        if (!UpgradeChains.TryGetValue(id, out var chain)) return id;

        int[] tools = PT2.save_file.FetchData(MenuLogic.MENU_TYPE.P1_TOOLS_ITEMS, false, "");
        int[] status = PT2.save_file.FetchData(MenuLogic.MENU_TYPE.P1_STATUS, false, "");
        int[] toolsAndStatus = tools.Concat(status).ToArray();

        foreach (var upgradeId in chain)
        {
            if (!toolsAndStatus.Contains(upgradeId))
                return upgradeId;
            PhoaAPClient.Logger.LogDebug($"{upgradeId} not found in toolsOrStatus");
        }

        return chain.Last();
    }

    private void AddItemToGame(long id, ItemInfo apItem)
    {
        if (SuppressedItemAddition.Remove(id)) return;

        if (id is 139)
            return;

        if (id is >= 292 and <= 299)
            id = HandleUpgradableItems(id);

        if (id is 216)
        {
            HandleSpellOfRejuvenation();
            return;
        }

        if (id > 300)
        {
            PickupLogic.PICKUP_CLASS pickupClass =
                (PickupLogic.PICKUP_CLASS)Enum.Parse(typeof(PickupLogic.PICKUP_CLASS), "P1_RAI");
            PT2.save_file.ApplyPickupEffect(pickupClass, (int)id - 300);
            return;
        }

        // TODO: Implement functionality to handle quantity. For now, only one item (fruit jam) adds more than 1
        int quantity = apItem.ItemId == 57 ? 3 : 1;

        if (PT2.save_file.HowMuchCanBeAdded((int)id, 1) > 0)
        {
            bool ignoreCutscene = apItem.Player.Name != _sessionContext.Session.Players.ActivePlayer.Name ||
                                  PT2.director.is_directing;
            PT2.save_file.AddItemToolOrStatusIdToInventory((int)id, quantity, ignoreCutscene);

            ApplyStatusUpgrade(id, ignoreCutscene);
            return;
        }

        MainThreadDispatcher.EnqueueNonMapLevelAction(() =>
        {
            PT2.item_gen.SpawnLoot((int)id, quantity, PT2.gale_script.GetTransform().position, "", Vector2.zero);
        });
    }

    private void ApplyStatusUpgrade(long id, bool ignoreCutscene)
    {
        string alwaysGisCommand = id switch
        {
            14 or 15 or 16 or 17 or 18 or 19 or 20 or 25 or 26 or 27 or 34 => "enable_gale_abilities",
            129 => "FILE_MARK_SI,BATTLE_SONG_BOOSTS,true",
            _ => ""
        };

        string conditionalGisCommand = ignoreCutscene
            ? id switch
            {
                3 => "apply_upgrade,HEALTH_UPGRADE|FILE_INTEGER_ADD,2,1",
                4 => "apply_upgrade,STAMINA_UPGRADE|FILE_INTEGER_ADD,3,1",
                5 => "common_sfx,145|FILE_INTEGER_ADD,8,1|FILE_INTEGER_ADD,9,1",
                _ => ""
            }
            : id switch
            {
                7 => "cutscene,line$BAT2_GET",
                8 => "cutscene,line$BAT3_GET",
                11 => "cutscene,line$ARMOR2_GET",
                12 => "cutscene,line$ARMOR3_GET",
                15 => "cutscene,line$TUSK_STRIKE_GET|muffle_timeout,5.5",
                16 => "cutscene,line$5492|muffle_timeout,5.5",
                17 => "cutscene,line$SPEAR_BOMB_GET|muffle_timeout,5.5",
                18 => "cutscene,line$8228|muffle_timeout,5.5",
                19 => "cutscene,line$7618|muffle_timeout,5.5",
                20 => "cutscene,line$9015|muffle_timeout,5.5",
                29 => "cutscene,line$OCARINA_GET",
                32 => "cutscene,line$LAMP_GET",
                33 => "cutscene,line$SPEAR_GET|muffle_timeout,5.5",
                34 => "cutscene,line$ROCKET_GET|muffle_timeout,5.5",
                35 => "cutscene,line$8430|muffle_timeout,5.5",
                37 => "cutscene,line$CROSSBOW_GET",
                39 => "cutscene,line$LAMP2_GET",
                40 => "cutscene,line$FISHPOLE_GET",
                124 => "haze_screen,color$ffffff,alpha$1,transition$1,hold_time$8|global_common_sfx,235|muffle_timeout,11.5",
                125 => "haze_screen,color$ffffff,alpha$1,transition$1,hold_time$10|global_common_sfx,237|muffle_timeout,9.5",
                126 => "haze_screen,color$ffffff,alpha$1,transition$1,hold_time$7|global_common_sfx,239|muffle_timeout,7",
                127 => "haze_screen,color$ffffff,alpha$1,transition$1,hold_time$9|global_common_sfx,236|muffle_timeout,12",
                128 => "haze_screen,color$ffffff,alpha$1,transition$1,hold_time$4|global_common_sfx,240|muffle_timeout,4",
                129 => "haze_screen,color$ffffff,alpha$1,transition$1,hold_time$3.7|global_common_sfx,238|muffle_timeout,3.7",
                _ => ""
            };

        string gisCommand = alwaysGisCommand.Length > 0
            ? (conditionalGisCommand.Length > 0 ? $"{conditionalGisCommand}|{alwaysGisCommand}" : alwaysGisCommand)
            : conditionalGisCommand;

        MainThreadDispatcher.RunOnMainThread(() =>
        {
            PT2.GIS_ProcessInstructions(gisCommand, PT2.gale_script.GetTransform().position);
        });
    }

    private void ShowItemMessage(long id, ItemInfo apItem)
    {
        if (SuppressedItemMessages.Remove(id)) return;
        if (apItem.Player.Name == "Server") return;

        string itemName = apItem.ItemDisplayName;
        if ((apItem.Flags & ItemFlags.Advancement) != 0) itemName = "<sprite=30>" + itemName;

        string message = $"<#ffffffB3>Found</color> {itemName}";
        if (apItem.Player.Name != _sessionContext.Session.Players.ActivePlayer.Name)
            message = $"<#ffffffB3>Received</color> {itemName} <#ffffffB3>from</color> {apItem.Player.Name}";

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
                        ProcessCheck(result, checks, i, levelName);
                }

                DialogHandler.ApplyDialogPatchesToGame();
            },
            false,
            _sessionContext.Session.Locations.AllLocations.ToArray()
        );
    }

    private void ProcessCheck(Dictionary<long, ScoutedItemInfo> result, List<Check> checks, int i, string levelName)
    {
        bool isExcluded = !result.TryGetValue(checks[i].ArchipelagoId, out ScoutedItemInfo itemInfo);

        if (isExcluded)
            checks[i].OverrideType = checks[i].OverrideType.Replace("%ItemId%", 215.ToString());

        bool shouldPatchDialog = checks[i].DialogReplacements != null &&
                                 (!isExcluded || FillMode <= checks[i].FillWhenExcluded);

        if (shouldPatchDialog)
            DialogHandler.AddDialogPatch(
                checks[i].DialogReplacements,
                checks[i].ArchipelagoId,
                isExcluded ? null : itemInfo,
                isExcluded || itemInfo.Player.Name == _sessionContext.Session.Players.ActivePlayer.Name,
                checks[i].CompletionDialogId);

        bool foundLinkedMoneyCheck = FillLinkedItemValues(result, checks, i);

        if (isExcluded) return;

        LocationMapping.LocationMap[levelName][i].ItemInfo = itemInfo;

        bool isAnitmatedSprite = checks[i].OverrideType.Contains("CustomAnimatedSprite");
        var replacementId = DetermineReplacementId(checks[i], itemInfo);

        bool hasNothingToReplace = !checks[i].OverrideType.Contains("%ItemId%");
        checks[i].OverrideType = checks[i].OverrideType.Replace("%ItemId%", replacementId);

        bool isFromThisWorld = itemInfo.Player.Name == _sessionContext.Session.Players.ActivePlayer.Name;
        bool isNpcType = checks[i].OverrideType.Contains("speech=");
        string[] overrideTypeAttributes = checks[i].OverrideType.Split(';');
        bool isStandaloneItem = overrideTypeAttributes.Contains("id=22");

        if (!isFromThisWorld || foundLinkedMoneyCheck || isNpcType || isStandaloneItem || hasNothingToReplace ||
            isAnitmatedSprite)
            return;

        ProcessRinReplacement(checks, i);
    }

    private static string DetermineReplacementId(Check check, ScoutedItemInfo itemInfo)
    {
        string replacementId = itemInfo.ItemId > 300 ? "22" : itemInfo.ItemId.ToString();

        if (!string.Equals(itemInfo.ItemGame, "Phoenotopia: Awakening"))
        {
            replacementId = 215.ToString();
            if ((itemInfo.Flags & ItemFlags.NeverExclude) != 0) replacementId = 214.ToString();
            if ((itemInfo.Flags & ItemFlags.Advancement) != 0) replacementId = 213.ToString();
            if ((itemInfo.Flags & ItemFlags.Trap) != 0) replacementId = 213.ToString();
        }

        if (!check.OverrideType.Contains("CustomAnimatedSprite")) return replacementId;
        int[] animatedFillerIds = [213, 214, 215];

        check.OverrideType = check.OverrideType.Replace("CustomAnimatedSprite;", "");
        int id = int.Parse(replacementId);
        return animatedFillerIds.Contains(id) ? (id + 32).ToString() : replacementId;
    }

    private static void ProcessRinReplacement(List<Check> checks, int i)
    {
        var gisCmds = GetGisCmdsFromOverwriteType(checks[i]);

        if (gisCmds.IsNullOrEmpty())
        {
            GiveRinReplacementInstructionFailureWarning(checks[i].ArchipelagoId);
            return;
        }

        string newOverwriteType = GetRinPickupReplacementString(gisCmds, checks[i]);

        if (newOverwriteType.IsNullOrEmpty())
        {
            GiveRinReplacementInstructionFailureWarning(checks[i].ArchipelagoId);
            return;
        }

        checks[i].OverrideType = newOverwriteType;
    }

    private void HandleSpellOfRejuvenation()
    {
        PT2.GIS_ProcessInstructions("FILE_MARK_SI,PANSELO_SONG_HEALS,true", PT2.gale_script.GetTransform().position);
    }

    private static string GetGisCmdsFromOverwriteType(Check check)
    {
        // Checks if GIS Pack
        if (check.ObjectIds.Any(id => id.Contains("-")))
            return check.OverrideType;

        string[] overwriteData = check.OverrideType.Split(';');
        string gisCmds = "";

        foreach (string data in overwriteData)
        {
            if (!data.Contains("GIS=")) continue;
            gisCmds = data.Split('=')[1];
            break;
        }

        return gisCmds;
    }

    private static string GetRinPickupReplacementString(string gisCmds, Check check)
    {
        string result = check.OverrideType;
        string[] instructions = gisCmds.Split('|');

        foreach (string instruction in instructions)
        {
            if (!instruction.Contains("SPAWN_loot,22,")) continue;

            List<string> splitInstruction = instruction.Split(',').ToList();

            if (splitInstruction.Count < 3) GiveRinReplacementInstructionFailureWarning(check.ArchipelagoId);

            // BUG: Might break when loot_GIS_PACK is used to spawn loot
            string identifier = "";
            string pos = "";
            foreach (string split in splitInstruction)
            {
                if (split.Contains("loot_GIS_MARK_")) identifier = split;
                if (split.Contains("pos")) pos = $",{split}";
            }

            if (identifier.IsNullOrEmpty()) GiveRinReplacementInstructionFailureWarning(check.ArchipelagoId);

            identifier = identifier.Replace("loot_GIS_MARK_", "FILE_MARK_").Replace("$", ",");

            result = result.Replace(instruction,
                $"SPAWN_pickup,P1_RAI,{check.ItemInfo.ItemId - 300}{pos}|{identifier},true");
            break;
        }

        return result;
    }

    private static void GiveRinReplacementInstructionFailureWarning(long apId)
    {
        PhoaAPClient.Logger.LogWarning(
            $"An instruction replacement for rin was improperly handled at check {apId}. Please contact the developer");
    }

    private static bool FillLinkedItemValues(Dictionary<long, ScoutedItemInfo> result, List<Check> checks, int i)
    {
        bool foundMoneyCheck = false;

        foreach (Match match in ItemLinkRegex.Matches(checks[i].OverrideType))
        {
            string valueToFill = match.Value;
            if (!int.TryParse(valueToFill.Trim('%').Split('$')[1], out int apId))
            {
                PhoaAPClient.Logger.LogError("Invalid link value: " + valueToFill);
                continue;
            }

            string replacement = result.TryGetValue(apId, out ScoutedItemInfo linkItemInfo)
                ? DetermineReplacementId(checks[i], linkItemInfo)
                : "215";

            if (replacement == "22") foundMoneyCheck = true;

            checks[i].OverrideType = checks[i].OverrideType.Replace(valueToFill, replacement);
        }

        return foundMoneyCheck;
    }
}