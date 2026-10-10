using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using PhoA_AP_client.AP;
using PhoA_AP_client.util;
using UnityEngine;
using WebSocketSharp;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
public class GameplayAdjustmentPatches
{
    private static bool _justRespawnedInWater;

    private static readonly Dictionary<int, int> DungeonItemBundleReference = new()
    {
        { 98, 217 },
        { 108, 218 },
        { 115, 219 },
        { 116, 220 },
        { 119, 225 },
        { 120, 226 },
        { 121, 227 },
    };

    private static readonly Dictionary<string, string> SettingNameMap = new()
    {
        { "PERRO", "enable_perros" }
    };

    [HarmonyPatch(typeof(GaleInteracter), "ReturnToCheckpoint")]
    [HarmonyPrefix] // Patch to detect whether the player respawns in water
    private static void ReturnToCheckpointPrefix(GaleInteracter __instance)
    {
        Vector3 checkpointLocation = Traverse.Create(__instance).Field<Vector3>("_checkpoint_location").Value;
        RaycastHit2D hit = Physics2D.Raycast(checkpointLocation, Vector2.zero, 1f, GL.mask_WATER);

        if (hit.collider == null) return;
        Traverse.Create(__instance).Field<bool>("_checkpoint_flush").Value = false;

        if (!Traverse.Create(__instance).Field<bool>("DEBUG_CAN_SWIM").Value)
            _justRespawnedInWater = true;
    }

    [HarmonyPatch(typeof(GaleLogicOne), "_STATE_Drowning")]
    [HarmonyPostfix] // Patch to prevent the player from infinitely drowning
    private static void STATEDrowningPostfix()
    {
        if (!_justRespawnedInWater) return;
        PT2.gale_script.SetGaleModeOnLevelLoad(GALE_MODE.SWIMMING);
        PT2.gale_script.SendGaleCommand(GALE_CMD.SET_GALE_MODE);
        _justRespawnedInWater = false;
    }

    // [HarmonyPatch(typeof(PT2), "GIS_ProcessInstructions")]
    // [HarmonyPrefix] // Patch to permanently disable Franways when apworld demands it
    // private static void GISProcessInstructionsFranwayDisabledPrefix(ref string instructions)
    // {
    //     if (PhoaAPClient.APConnection.SessionContext.Login.SlotData.TryGetValue("franway_unlock_mode",
    //             out var franwayUnlockMode) && (long)franwayUnlockMode != 0)
    //         return;
    //
    //     List<string> instructionsList = instructions.Split('|').ToList();
    //
    //     instructionsList.RemoveAll(instruction =>
    //         instruction.Contains("WARP_OPEN_PANSELO") || 
    //         instruction.Contains("WARP_OPEN_ATAI") ||
    //         instruction.Contains("WARP_OPEN_CROP"));
    //
    //     instructions = string.Join("|", instructionsList.ToArray());
    // }

    [HarmonyPatch(typeof(SaveFile), "AddItemToolOrStatusIdToInventory")]
    [HarmonyPostfix] // Patch to unlock Franways once enough moonstones are acquired
    private static void AddItemToolOrStatusIdToInventoryPostfix(int item_tool_id)
    {
        if (item_tool_id != 5) return;
        if (PhoaAPClient.APConnection.SessionContext.Login.SlotData.TryGetValue("franway_unlock_mode",
                out var franwayUnlockMode) && (long)franwayUnlockMode != 2)
            return;

        int moonstoneTotalGame = PT2.save_file.GetInt(8);
        int moonstoneTotalAP = APSaveState.CollectedItems.Count(itemId => itemId == 5);
        if (moonstoneTotalGame != moonstoneTotalAP)
            PhoaAPClient.Logger.LogWarning("Moonstone total in game is not in sync with AP");

        string teleporter = moonstoneTotalGame switch
        {
            10 => "WARP_OPEN_PANSELO",
            20 => "WARP_OPEN_ATAI",
            30 => "WARP_OPEN_CROP",
            _ => ""
        };

        if (teleporter.IsNullOrEmpty()) return;

        PT2.GIS_ProcessInstructions($"FILE_MARK_SI,{teleporter},true", PT2.gale_script.GetTransform().position);

        string region = teleporter switch
        {
            "WARP_OPEN_PANSELO" => "Panselo",
            "WARP_OPEN_ATAI" => "Atai",
            "WARP_OPEN_CROP" => "Cosette",
            _ => ""
        };

        PT2.display_messages.DisplayMessage($"{region} teleporter unlocked!",
            DisplayMessagesLogic.MSG_TYPE.GALE_PLUS_STATUS);
        PT2.sound_g.PlayGlobalUncommonSfx("computer_access", 1f);
        LeanTween.delayedCall(PT2.gale_script.GetGaleObject(GALE_OBJ_REQ.GAME_OBJ), .5f,
            () => { PT2.sound_g.PlayGlobalUncommonSfx("battery_powered_up", 1f); });
    }

    [HarmonyPatch(typeof(SaveFile), "_Evaluate_QL_BasicPhrase")]
    [HarmonyPrefix] // Patch to add ITEM_DONT_HAVE_COUNT to _Evaluate_QL_BasicPhrase
    private static bool EvaluateQLBasicPhraseItemDontHaveCountPrefix(string ql_phrase, ref bool __result,
        SaveFile __instance)
    {
        if (!ql_phrase.Contains("ITEM_DONT_HAVE_COUNT")) return true;

        string[] splitQLPhrase = ql_phrase.Split(',');
        var method = AccessTools.Method(typeof(SaveFile), "_QL_HandleItemsHaveCount");
        __result = !(bool)method.Invoke(__instance, [splitQLPhrase]);

        return false;
    }

    [HarmonyPatch(typeof(SaveFile), "_Evaluate_QL_BasicPhrase")]
    [HarmonyPrefix] // Patch to add AP_CHECK_DONE to _Evaluate_QL_BasicPhrase
    private static bool EvaluateQLBasicPhraseAPLocationCheckedPrefix(string ql_phrase, ref bool __result,
        SaveFile __instance)
    {
        if (!ql_phrase.Contains("AP_LOCATION_CHECKED") && !ql_phrase.Contains("AP_LOCATION_NOT_CHECKED")) return true;

        string checkIdentifier = ql_phrase.Split(',')[1];
        long archipelagoId = LocationMapping.LocationMap
            .SelectMany(kvp => kvp.Value)
            .Where(check => check.GISIdentifier == checkIdentifier)
            .Select(check => check.ArchipelagoId)
            .FirstOrDefault();

        __result = archipelagoId != 0 &&
                   PhoaAPClient.APConnection.ItemHandler.LocalAllLocationsChecked.Contains(archipelagoId);
        if (ql_phrase.Contains("AP_LOCATION_NOT_CHECKED")) __result = !__result;

        return false;
    }

    [HarmonyPatch(typeof(SaveFile), "_Evaluate_QL_BasicPhrase")]
    [HarmonyPrefix] // Patch to add AP_SETTING_TRUE/FALSE to _Evaluate_QL_BasicPhrase
    private static bool EvaluateQLBasicPhraseAPSettingPrefix(string ql_phrase, ref bool __result, SaveFile __instance)
    {
        if (!ql_phrase.Contains("AP_SETTING_")) return true;

        string[] splitQLPhrase = ql_phrase.Split(',');

        bool checkValue = splitQLPhrase[0].EndsWith("TRUE");

        if (!SettingNameMap.TryGetValue(splitQLPhrase[1], out string checkSetting))
        {
            __result = true;
            PhoaAPClient.Logger.LogWarning("AP settings not found for " + splitQLPhrase[1]);
            return false;
        }

        bool perrosEnabled =
            PhoaAPClient.APConnection.SessionContext.Login.SlotData.TryGetValue(checkSetting,
                out var enablePerros) && (long)enablePerros == 1;

        __result = checkValue == perrosEnabled;

        return false;
    }

    [HarmonyPatch(typeof(SaveFile), "_QL_HandleItemsHaveCount")]
    [HarmonyPostfix] // Patch to handle functionality of dungeon item bundles
    private static void QLHandleItemsHaveCountPostfix(string[] args, ref bool __result)
    {
        if (__result) return;

        int itemId = int.Parse(args[1]);
        if (!DungeonItemBundleReference.Keys.Contains(itemId)) return;

        __result = PT2.save_file.QL_EvaluateExpression($"ITEM_HAVE_COUNT,{DungeonItemBundleReference[itemId]},1");
    }

    [HarmonyPatch(typeof(SaveFile), "_QL_HandleItemsHave")]
    [HarmonyPostfix] // Patch to handle functionality of dungeon item bundles
    private static void QLHandleItemsHavePostfix(string[] args, ref bool __result)
    {
        if (__result) return;

        int[] itemIds = PT2.GIS_ParseIntList(args[1]);
        bool foundReplacement = false;

        for (int i = 0; i < itemIds.Length; i++)
        {
            if (!DungeonItemBundleReference.TryGetValue(itemIds[i], out int replacement)) continue;
            itemIds[i] = replacement;
            foundReplacement = true;
        }

        if (!foundReplacement) return;

        string ids = string.Join("/", Array.ConvertAll(itemIds, n => n.ToString()));

        __result = PT2.save_file.QL_EvaluateExpression($"ITEM_HAVE,int_list({ids})");
    }

    [HarmonyPatch(typeof(SaveFile), "_QL_HandleItemsDontHave")]
    [HarmonyPostfix] // Patch to handle functionality of dungeon item bundles
    private static void QLHandleItemsDontHavePostfix(string[] args, ref bool __result)
    {
        if (!__result) return;

        int[] itemIds = PT2.GIS_ParseIntList(args[1]);
        bool foundReplacement = false;

        for (int i = 0; i < itemIds.Length; i++)
        {
            if (!DungeonItemBundleReference.TryGetValue(itemIds[i], out int replacement)) continue;
            itemIds[i] = replacement;
            foundReplacement = true;
        }

        if (!foundReplacement) return;

        string ids = string.Join("/", Array.ConvertAll(itemIds, n => n.ToString()));

        __result = PT2.save_file.QL_EvaluateExpression($"ITEM_DONT_HAVE,int_list({ids})");
    }
}