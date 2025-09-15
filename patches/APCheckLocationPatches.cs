using System.Collections.Generic;
using System.Linq;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Packets;
using HarmonyLib;
using PhoA_AP_client.util;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class APCheckLocationPatches
{
    [HarmonyPatch(typeof(SaveFile), "AddItemToolOrStatusIdToInventory")]
    [HarmonyPrefix] // Patch to prevent AP items from being added to the inventory
    private static bool AddItemToolOrStatusIdToInventoryPrefix(int item_tool_id, int quantity, bool ignore_ADDED_GIS)
    {
        // TODO: This patch currently only handles the custom AP items. Items from PhoA worlds need to be handled separately 
        int[] ids = FindAPItemIdsInItemDef();
        if (ids.Contains(item_tool_id)) return false;
        return true;
    }

    [HarmonyPatch(typeof(PT2), "GIS_ProcessInstructions")]
    [HarmonyPrefix] // Patch to check locations in AP once grabbed
    public static bool GISProcessInstructionsPrefix(string instructions)
    {
        PhoaAPClient.Logger.LogDebug($"GIS_ProcessInstructions was called with instructions: {instructions}");
        bool continueInstruction = true;

        string[] instructionsArray = instructions.Split(',');
        string instruction = instructionsArray[0];

        if (instruction != "FILE_MARK_SI" && instruction != "FILE_MARK_OC" && instruction != "FILE_MARK_AP")
            return continueInstruction;

        if (instruction.Equals("FILE_MARK_AP")) continueInstruction = false;

        if (!APHelpers.IsConnectedToAP())
            return continueInstruction;

        string identifier = instructionsArray[1];

        Check checkedLocation = LocationMapping.LocationMap
            .SelectMany(kvp => kvp.Value)
            .FirstOrDefault(check => check.GISIdentifier == identifier);

        if (checkedLocation == null) return continueInstruction;

        if (checkedLocation.ArchipelagoId == 1)
        {
            PhoaAPClient.APConnection.Session.Socket.SendPacket(new StatusUpdatePacket
            {
                Status = ArchipelagoClientState.ClientGoal
            });
            return continueInstruction;
        }

        PhoaAPClient.APConnection.Session.Locations
            .CompleteLocationChecks(checkedLocation.ArchipelagoId);

        return continueInstruction;
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
                PhoaAPClient.Logger.LogDebug($"Name: {DB.ITEM_DEFS[i].item_name}, ID: {i}, index: {index}");
                ids[index] = i;
                matches++;
            }
        }

        if (matches != 3)
            PhoaAPClient.Logger.LogWarning(
                "Not all, or too many AP were found. Please report a bug to the developer of the AP implementation");

        return ids;
    }
}