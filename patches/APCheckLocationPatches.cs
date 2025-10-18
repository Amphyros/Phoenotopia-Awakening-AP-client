using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Models;
using HarmonyLib;
using PhoA_AP_client.util;
using UnityEngine;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class APCheckLocationPatches
{
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

        Check location = LocationMapping.LocationMap
            .SelectMany(kvp => kvp.Value)
            .FirstOrDefault(check => check.GISIdentifier == identifier);

        if (location == null || !PhoaAPClient.APConnection.LocalAllLocations.Contains(location.ArchipelagoId) ||
            (!location.IsKeyItem &&
             PhoaAPClient.APConnection.LocalAllLocationsChecked.Contains(location.ArchipelagoId))) return true;

        component.Taken();
        // The original method calls these two methods. I don't have a clue why, but they're here, to be sure
        // PT2.thing_wheel.UpdateToolHudGraphics(false, false, false);
        // PT2.thing_wheel.UpdateWheelGraphics();

        return false;
    }

    [HarmonyPatch(typeof(SaveFile), "AddItemToolOrStatusIdToInventory")]
    [HarmonyPrefix] // Patch to prevent AP items from being added to the inventory
    private static bool AddItemToolOrStatusIdToInventoryPrefix(int item_tool_id, int quantity, bool ignore_ADDED_GIS)
    {
        int[] ids = FindAPItemIdsInItemDef();
        if (ids.Contains(item_tool_id)) return false;

        return true;
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

            if (instructionType != "FILE_MARK_SI" && instructionType != "FILE_MARK_OC" &&
                instructionType != "FILE_MARK_POC" && instructionType != "FILE_MARK_AP")
                continue;

            if (!APHelpers.IsConnectedToAP()) continue;

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

            if (PhoaAPClient.APConnection.LocalAllLocationsChecked.Contains(checkedLocation.ArchipelagoId)) continue;
            if (!PhoaAPClient.APConnection.LocalAllLocations.Contains(checkedLocation.ArchipelagoId)) continue;

            OnLocationGet(checkedLocation.ItemInfo);

            new Thread(() =>
            {
                PhoaAPClient.APConnection.Session.Locations
                    .CompleteLocationChecksAsync(
                        _ =>
                        {
                            MainThreadDispatcher.RunOnMainThread(() => PhoaAPClient.APConnection.OnLocationChecked());
                        }, checkedLocation.ArchipelagoId);
            }).Start();
        }

        instructionsList.RemoveAll(instruction => instruction.Contains("FILE_MARK_AP"));

        instructions = string.Join("|", instructionsList.ToArray());
    }

    private static void OnLocationGet(ScoutedItemInfo itemInfo)
    {
        PhoaAPClient.APConnection.SuppressedItemMessages.Add(itemInfo.ItemId);

        string itemName = itemInfo.ItemDisplayName;
        string playerName = itemInfo.Player.Name;

        StringBuilder message = new StringBuilder("Found ");

        if (playerName != PhoaAPClient.APConnection.Session?.Players.ActivePlayer.Name)
            message.Append($"{playerName}'s ");

        if ((itemInfo.Flags & ItemFlags.Advancement) != 0) message.Append("<sprite=30>");

        message.Append($"{itemName}");

        MainThreadDispatcher.RunOnMainThread(() =>
        {
            PT2.sound_g.PlayGlobalCommonSfx(133, 1f, 1f, 2);
            PT2.display_messages.DisplayMessage(message.ToString(), DisplayMessagesLogic.MSG_TYPE.SMALL_ITEM_GET);
        });
    }

    private static int[] FindAPItemIdsInItemDef()
    {
        Dictionary<string, int> targets = new Dictionary<string, int>()
        {
            { "Progressive Archipelago Item", 0 },
            { "Useful Archipelago Item", 1 },
            { "Filler Archipelago Item", 2 },
        };

        int[] ids = new int[targets.Count];
        int matches = 0;

        for (int i = 0; i < DB.ITEM_DEFS.Length; i++)
        {
            if (DB.ITEM_DEFS[i].item_name != null && targets.TryGetValue(DB.ITEM_DEFS[i].item_name, out int index))
            {
                ids[index] = i;
                matches++;
            }
        }

        if (matches != 3)
            PhoaAPClient.Logger.LogWarning(
                "Not all, or too many AP were found. Please report this bug to the developer of the AP implementation");

        return ids;
    }
}