using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using PhoA_AP_client.util;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class APDialogReplacementPatches
{
    [HarmonyPatch(typeof(DB), "ReloadGameData")]
    [HarmonyPostfix]
    private static void ReloadGameDataPostfix()
    {
        PhoaAPClient.Logger.LogDebug($"Gamedata reloaded");
        PhoaAPClient.APConnection.ItemHandler.DialogHandler.ApplyDialogPatchesToGame();
    }

    [HarmonyPatch(typeof(DirectorLogic), "_ProcessTextAndCodes")]
    [HarmonyPrefix]
    private static void ProcessTextAndCodesPrefix(ref string text, ref string all_code_string)
    {
        if (!all_code_string.Contains("GO_AP")) return;

        string[] instructionArray = all_code_string.Split(',');
        string originalDialogId = instructionArray[1];
        string alteredDialogId = instructionArray[2];
        string archipelagoId = instructionArray[3];
        string completionDialogId = instructionArray.Length > 4 ? instructionArray[4] : null;

        void ApplyLine(int lineId, ref string text, ref string all_code_string)
        {
            string fullLine = DB.lines[lineId];
            string[] parts = fullLine.Split(["||||"], StringSplitOptions.None);
            all_code_string = parts[0];
            text = parts[1];
        }

        if (!APHelpers.IsConnectedToAP())
        {
            ApplyLine(DB.GetLine(originalDialogId), ref text, ref all_code_string);
            return;
        }

        string activeLevelName = LevelBuildLogic.level_name;
        if (!LocationMapping.LocationMap.TryGetValue(activeLevelName, out List<Check> checks))
        {
            ApplyLine(DB.GetLine(originalDialogId), ref text, ref all_code_string);
            return;
        }

        Check relatedCheck = checks.FirstOrDefault(c => c.ArchipelagoId == long.Parse(archipelagoId));
        if (relatedCheck == null)
        {
            PhoaAPClient.Logger.LogError(
                $"Level {activeLevelName} does not contain a check with Archipelago ID: {archipelagoId}. " +
                $"Please report this error to the developer");
            return;
        }

        bool isChecked =
            PhoaAPClient.APConnection.ItemHandler.LocalAllLocationsChecked.Contains(relatedCheck.ArchipelagoId);

        if (!isChecked)
        {
            ApplyLine(DB.GetLine(alteredDialogId), ref text, ref all_code_string);
            return;
        }

        if (!relatedCheck.IsKeyItem)
        {
            ApplyLine(DB.GetLine(originalDialogId), ref text, ref all_code_string);
            return;
        }

        if (completionDialogId == null)
        {
            ApplyLine(DB.GetLine(alteredDialogId), ref text, ref all_code_string);
            return;
        }

        ApplyLine(DB.GetLine(completionDialogId), ref text, ref all_code_string);
    }
}