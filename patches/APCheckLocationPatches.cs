using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Models;
using HarmonyLib;
using PhoA_AP_client.util;
using PhoA_AP_client.util.DataClasses;
using UnityEngine;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class APCheckLocationPatches
{
    private static readonly List<long> ChecksToHint = [];
    private static int[] _apItemIds;

    private class KeycardData
    {
        public long ID { get; set; }
        public HashSet<long> LocationIDs { get; set; }
    }

    private static readonly Dictionary<string, KeycardData> KeycardChecks = new()
    {
        { "C", new KeycardData { ID = 119, LocationIDs = [7676503, 7676504, 7676505, 7676506, 7676507] } },
        { "B", new KeycardData { ID = 120, LocationIDs = [7676508, 7676509, 7676510, 7676511, 7676512] } },
        { "A", new KeycardData { ID = 121, LocationIDs = [7676513, 7676514, 7676515, 7676516, 7676517] } },
    };

    private static readonly HashSet<string> ValidInstructionTypes =
    [
        "FILE_MARK_SI",
        "FILE_MARK_OC",
        "FILE_MARK_POC",
        "POC_WRITE",
        "FILE_MARK_AP",
        "AP_HINT",
        "AP_HANDLE_KEYCARDS",
    ];

    [HarmonyPatch(typeof(DB), "_LoadItemDefinitions")]
    [HarmonyPriority(Priority.Last)]
    [HarmonyPostfix] // Patch to add AP item to item DB
    private static void LoadItemDefinitionsPostfix()
    {
        string[] targets =
        [
            "Progression Archipelago Item",
            "Useful Archipelago Item",
            "Filler Archipelago Item",
            "Panselo Franway Teleporter",
            "Atai Franway Teleporter",
            "Cosette Franway Teleporter",
        ];

        int[] ids = new int[targets.Length];
        int matches = 0;

        for (int i = 0; i < DB.ITEM_DEFS.Length; i++)
        {
            if (DB.ITEM_DEFS[i].item_name == null || !targets.Contains(DB.ITEM_DEFS[i].item_name)) continue;
            ids[matches] = i;
            matches++;
        }

        if (matches != targets.Length)
            PhoaAPClient.Logger.LogWarning(
                "Not all, or too many AP were found. Please report this bug to the developer of the AP implementation");

        _apItemIds = ids;
    }

    [HarmonyPatch(typeof(GaleInteracter), "_AttemptGrabbingLoot")]
    [HarmonyPrefix] // Patch to handle possible custom behaviour for AP
    private static bool AttemptGrabbingLootPrefix(Collider2D loot_collider)
    {
        if (!APHelpers.IsConnectedToAP())
        {
            PhoaAPClient.Logger.LogWarning("Item grab cancelled: Disconnected from AP.");

            PT2.sound_g.PlayGlobalCommonSfx(134, 1f, 1f, 2);
            PT2.display_messages.DisplayMessage("You are disconnected from the Archipelago server",
                DisplayMessagesLogic.MSG_TYPE.INVENTORY_FULL);

            return false;
        }

        LootLogic component = loot_collider.GetComponent<LootLogic>();
        var field = typeof(LootLogic).GetField("_collected_GIS_cmd", BindingFlags.NonPublic | BindingFlags.Instance);
        string collectedGIS = (string)field?.GetValue(component);
        if (collectedGIS == null) return true;

        string[] collectedGISParts = collectedGIS.Split(',');
        if (collectedGISParts.Length < 2) return true;
        string identifier = collectedGISParts[1];

        if (!LocationMapping.LocationMap.TryGetValue(LevelBuildLogic.level_name.ToLower(), out var locations))
            return true;
        Check location = locations.FirstOrDefault(check => check.GISIdentifier == identifier);

        if (location == null ||
            !PhoaAPClient.APConnection.ItemHandler.LocalAllLocations.Contains(location.ArchipelagoId) ||
            (!location.IsKeyItem &&
             PhoaAPClient.APConnection.ItemHandler.LocalAllLocationsChecked.Contains(location.ArchipelagoId)))
            return true;

        component.Taken();

        return false;
    }

    [HarmonyPatch(typeof(SaveFile), "AddItemToolOrStatusIdToInventory")]
    [HarmonyPrefix] // Patch to prevent AP items from being added to the inventory
    private static bool AddItemToolOrStatusIdToInventoryPrefix(int item_tool_id, int quantity, bool ignore_ADDED_GIS)
    {
        return !_apItemIds.Contains(item_tool_id);
    }

    [HarmonyPatch(typeof(PT2), "GIS_ProcessInstructions")]
    [HarmonyPrefix] // Patch to check locations in AP once grabbed
    private static void GISProcessInstructionsPrefix(ref string instructions)
    {
        PhoaAPClient.Logger.LogDebug($"GIS_ProcessInstructions was called with instructions: {instructions}");

        List<string> instructionsList = instructions.Split('|').ToList();

        foreach (string instruction in instructionsList)
        {
            string[] instructionParts = instruction.Split(',');
            string instructionType = instructionParts[0];

            if (instructionType is "CONTINUE_IF" &&
                !PT2.save_file.QL_EvaluateExpression(instruction.Substring(12)))
                break;
            if (instructionType is "ABORT_IF" &&
                PT2.save_file.QL_EvaluateExpression(instruction.Substring(9)))
                break;

            if (!ValidInstructionTypes.Contains(instructionType)) continue;

            if (!APHelpers.IsConnectedToAP()) continue;

            if (instructionType.StartsWith("AP_HANDLE_KEYCARDS"))
            {
                HandleKeycards(instructionParts[1]);
                continue;
            }

            if (instructionType.StartsWith("AP_HINT"))
            {
                ChecksToHint.Add(long.Parse(instructionParts[1]));
                continue;
            }

            string identifier = instructionParts[1];

            Check checkedLocation = LocationMapping.LocationMap
                .SelectMany(kvp => kvp.Value)
                .FirstOrDefault(check => check.GISIdentifier == identifier);

            if (checkedLocation == null) continue;

            if (checkedLocation.ArchipelagoId == 1)
            {
                APHelpers.SendGoalCompletedPacket();
                continue;
            }

            if (PhoaAPClient.APConnection.ItemHandler.LocalAllLocationsChecked.Contains(checkedLocation.ArchipelagoId))
                continue;
            if (!PhoaAPClient.APConnection.ItemHandler.LocalAllLocations.Contains(checkedLocation.ArchipelagoId))
                continue;

            if (checkedLocation.OverrideType.Contains("SPAWN_pickup,P1_RAI"))
                PhoaAPClient.APConnection.ItemHandler.SuppressedItemAddition.Add(checkedLocation.ItemInfo.ItemId);

            OnLocationGet(checkedLocation.ItemInfo);
            if (checkedLocation.ItemInfo.Player.Slot == PhoaAPClient.APConnection.SessionContext.Login.Slot)
                PhoaAPClient.APConnection.ItemHandler.PreAddItem(
                    checkedLocation.ItemInfo.ItemId, checkedLocation.ItemInfo);

            new Thread(() =>
            {
                PhoaAPClient.APConnection.SessionContext.Session.Locations
                    .CompleteLocationChecksAsync(
                        _ =>
                        {
                            MainThreadDispatcher.RunOnMainThread(() =>
                                PhoaAPClient.APConnection.ItemHandler.OnLocationChecked());
                        }, checkedLocation.ArchipelagoId);
            }).Start();
        }

        instructionsList.RemoveAll(instruction =>
            instruction.Contains("FILE_MARK_AP") || instruction.Contains("miceBoxbreak") ||
            instruction.Contains("scorpBoxbreak") || instruction.Contains("brokemousebox") ||
            instruction.Contains("AP_HINT") || instruction.Contains("AP_HANDLE_KEYCARDS"));

        instructions = string.Join("|", instructionsList.ToArray());
    }

    [HarmonyPatch(typeof(DirectorLogic), "_CloseCurrDialoguer")]
    [HarmonyPostfix] // Patch to apply hints after closing the dialoger
    private static void CloseCurrDialoguerPostfix()
    {
        if (!APHelpers.IsConnectedToAP() || ChecksToHint.Count <= 0) return;

        PhoaAPClient.APConnection.SessionContext.Session.Hints.CreateHints(
            HintStatus.Unspecified, ChecksToHint.ToArray());

        ChecksToHint.Clear();
    }

    [HarmonyPatch(typeof(SaveFile), "SaveGame")]
    [HarmonyPrefix] // Patch that stalls saving the game until the entire PerFrameActions queue is resolved
    private static bool SaveGamePrefix()
    {
        if (MainThreadDispatcher.ActionsLeftInPerFrameQueue() <= 0) return true;

        PhoaAPClient.Logger.LogDebug(
            $"{MainThreadDispatcher.ActionsLeftInPerFrameQueue()} per frame actions left in queue. " +
            $"Stalling save until queue is resolved...");
        MainThreadDispatcher.SetStalledSaveAction(() => PT2.save_file.SaveGame());
        return false;
    }

    private static void OnLocationGet(ScoutedItemInfo itemInfo)
    {
        PhoaAPClient.APConnection.ItemHandler.SuppressedItemMessages.Add(itemInfo.ItemId);

        string itemName = itemInfo.ItemDisplayName;
        string playerName = itemInfo.Player.Name;

        StringBuilder message = new StringBuilder("<#ffffffB3>Found</color> ");

        if (playerName != PhoaAPClient.APConnection.SessionContext?.Session?.Players.ActivePlayer.Name)
            message.Append($"{playerName}'s ");

        if ((itemInfo.Flags & ItemFlags.Advancement) != 0) message.Append("<sprite=30>");

        message.Append($"{itemName}");

        MainThreadDispatcher.RunOnMainThread(() =>
        {
            PT2.sound_g.PlayGlobalCommonSfx(133, 1f, 1f, 2);
            PT2.display_messages.DisplayMessage(message.ToString(), DisplayMessagesLogic.MSG_TYPE.SMALL_ITEM_GET);
        });
    }

    private static void HandleKeycards(string keycardType)
    {
        if (!KeycardChecks[keycardType].LocationIDs.All(location =>
                PhoaAPClient.APConnection.SessionContext.Session.Locations.AllLocationsChecked.Contains(location)))
        {
            PT2.GIS_ProcessInstructions($"FILE_MARK_AP,AP_KEYCARD_{keycardType}_1", Vector3.zero);
            PT2.juicer.J_QueueUp_GIS_Commands(0.4f, $"FILE_MARK_AP,AP_KEYCARD_{keycardType}_2");
            PT2.juicer.J_QueueUp_GIS_Commands(0.8f, $"FILE_MARK_AP,AP_KEYCARD_{keycardType}_3");
            PT2.juicer.J_QueueUp_GIS_Commands(1.2f, $"FILE_MARK_AP,AP_KEYCARD_{keycardType}_4");
            PT2.juicer.J_QueueUp_GIS_Commands(1.6f, $"FILE_MARK_AP,AP_KEYCARD_{keycardType}_5");
            return;
        }

        if (PhoaAPClient.APConnection.SessionContext.Login.SlotData.TryGetValue("bundle_keycards",
                out var openPanseloGates) && (long)openPanseloGates >= 1)
            return;

        int amountOfKeycardsAcquired = PhoaAPClient.APConnection.SessionContext.Session.Items.AllItemsReceived
            .Count(item => item.ItemName == $"Keycard {keycardType}");

        int[] inventoryItemIds = AccessTools.FieldRefAccess<SaveFile, int[]>(PT2.save_file, "_item_IDs");
        int[] inventoryItemCounts = AccessTools.FieldRefAccess<SaveFile, int[]>(PT2.save_file, "_item_ID_count");
        int itemInventoryId = Array.FindIndex(inventoryItemIds, itemId => itemId == KeycardChecks[keycardType].ID);
        int keycardsInInventory = itemInventoryId >= 0 ? inventoryItemCounts[itemInventoryId] : 0;

        float timer = 0.0f;
        while (keycardsInInventory < amountOfKeycardsAcquired)
        {
            PT2.juicer.J_QueueUp_GIS_Commands(timer, $"ITEM_add,{KeycardChecks[keycardType].ID},1");
            timer += 0.4f;
            keycardsInInventory++;
        }
    }
}