using System.Collections.Generic;
using System.Linq;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Packets;
using HarmonyLib;
using PhoA_AP_client.util;
using UnityEngine;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class APCheckLocationPatches
{
    private static bool lootCheck;
    private static bool apItemFound;
    private static int? _cachedItemToolId;
    private static int? _cachedQuantity;
    private static bool? _cachedIgnore;
    
    [HarmonyPatch(typeof(GaleInteracter), "_AttemptGrabbingLoot")]
    [HarmonyPrefix] // Patch to initiate possible custom behaviour for AP
    private static void AttemptGrabbingLootPrefix(Collider2D loot_collider)
    {
        lootCheck = true;
    }

    [HarmonyPatch(typeof(SaveFile), "AddItemToolOrStatusIdToInventory")]
    [HarmonyPrefix] // Patch to prevent AP items from being added to the inventory
    private static bool AddItemToolOrStatusIdToInventoryPrefix(int item_tool_id, int quantity, bool ignore_ADDED_GIS)
    {
        if (!lootCheck) return true;
        
        int[] ids = FindAPItemIdsInItemDef();
        if (ids.Contains(item_tool_id))
        {
            apItemFound = true;
            return false;
        }
        
        _cachedItemToolId = item_tool_id;
        _cachedQuantity = quantity;
        _cachedIgnore = ignore_ADDED_GIS;
        
        return false;
    }

    [HarmonyPatch(typeof(PT2), "GIS_ProcessInstructions")]
    [HarmonyPrefix] // Patch to check locations in AP once grabbed
    private static bool GISProcessInstructionsPrefix(string instructions)
    {
        PhoaAPClient.Logger.LogDebug($"GIS_ProcessInstructions was called with instructions: {instructions}");
        bool continueInstruction = true;

        string[] instructionsArray = instructions.Split(',');
        string instruction = instructionsArray[0];

        if (instruction != "FILE_MARK_SI" && instruction != "FILE_MARK_OC" && instruction != "FILE_MARK_AP")
            return continueInstruction;

        if (instruction.Equals("FILE_MARK_AP")) continueInstruction = false;

        if (!APHelpers.IsConnectedToAP()) return continueInstruction;

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

        _cachedItemToolId = null;
        _cachedQuantity = null;
        _cachedIgnore = null;
        
        PhoaAPClient.APConnection.Session.Locations
            .CompleteLocationChecks(checkedLocation.ArchipelagoId);

        return continueInstruction;
    }

    [HarmonyPatch(typeof(SoundGenerator), "PlayGlobalCommonSfx")]
    [HarmonyPrefix] // Patch to prevent loot pickup sound from being played
    private static bool PlayGlobalCommonSfxPrefix(int audio_clip_index)
    {
        if (lootCheck && audio_clip_index == 133 && !apItemFound && !_cachedItemToolId.HasValue) return false;
        return true;
    }

    [HarmonyPatch(typeof(DisplayMessagesLogic), "DisplayMessage")]
    [HarmonyPrefix] // Patch to prevent the default loot message from happening
    private static bool DisplayMessagePrefix()
    {
        if (lootCheck && !apItemFound && !_cachedItemToolId.HasValue) return false;
        return true;
    }

    [HarmonyPatch(typeof(GaleInteracter), "_AttemptGrabbingLoot")]
    [HarmonyPostfix] // Patch to end lootCheck behaviour and add items to inventory if needed
    private static void AttemptGrabbingLootPostfix()
    {
        lootCheck = false;
        apItemFound = false;
        
        if (_cachedItemToolId.HasValue && _cachedQuantity.HasValue && _cachedIgnore.HasValue)
            PT2.save_file
                .AddItemToolOrStatusIdToInventory(_cachedItemToolId.Value, _cachedQuantity.Value, _cachedIgnore.Value);

        _cachedItemToolId = null;
        _cachedQuantity = null;
        _cachedIgnore = null;
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