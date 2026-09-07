using System.Linq;
using HarmonyLib;
using PhoA_AP_client.util;
using UnityEngine;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
public class GameplayAdjustmentPatches
{
    private static bool _justRespawnedInWater;

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
    private static bool EvaluateQLBasicPhrasePrefix(string ql_phrase, ref bool __result, SaveFile __instance)
    {
        if (!ql_phrase.Contains("AP_LOCATION_CHECKED") && !ql_phrase.Contains("AP_LOCATION_NOT_CHECKED")) return true;

        string checkIdentifier = ql_phrase.Split(',')[1];
        long archipelagoId = LocationMapping.LocationMap
            .SelectMany(kvp => kvp.Value)
            .Where(check => check.GISIdentifier == checkIdentifier)
            .Select(check => check.ArchipelagoId)
            .FirstOrDefault();

        if (archipelagoId == 0) PhoaAPClient.Logger.LogDebug("Couldn't find check");

        __result = archipelagoId != 0 &&
                   PhoaAPClient.APConnection.ItemHandler.LocalAllLocationsChecked.Contains(archipelagoId);
        if (ql_phrase.Contains("AP_LOCATION_NOT_CHECKED")) __result = !__result;

        return false;
    }
}