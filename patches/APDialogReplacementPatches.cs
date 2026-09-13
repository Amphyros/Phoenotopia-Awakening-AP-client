using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using PhoA_AP_client.util;
using PhoA_AP_client.util.DataClasses;

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
        long[] archipelagoIds = instructionArray[3]
            .Split('&')
            .Select(s =>
            {
                if (!long.TryParse(s, out var result))
                    throw new FormatException($"Invalid long value when parsing ApId: '{s}'");
                return result;
            })
            .ToArray();
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

        Check[] relatedChecks = checks.Where(c => archipelagoIds.Contains(c.ArchipelagoId)).ToArray();
        if (!relatedChecks.Any())
        {
            PhoaAPClient.Logger.LogError(
                $"Level {activeLevelName} does not contain a check with Archipelago ID: {archipelagoIds}. " +
                $"Please report this error to the developer");
            return;
        }

        bool allChecked = relatedChecks.All(c =>
            PhoaAPClient.APConnection.ItemHandler.LocalAllLocationsChecked.Contains(c.ArchipelagoId));
        bool isNotIncluded = relatedChecks.All(c =>
            !PhoaAPClient.APConnection.ItemHandler.LocalAllLocations.Contains(c.ArchipelagoId));

        if (isNotIncluded)
        {
            ApplyLine(DB.GetLine(completionDialogId ?? alteredDialogId), ref text, ref all_code_string);
            return;
        }

        if (!allChecked)
        {
            ApplyLine(DB.GetLine(alteredDialogId), ref text, ref all_code_string);
            return;
        }

        if (relatedChecks.Any(c => !c.IsKeyItem))
        {
            ApplyLine(DB.GetLine(originalDialogId), ref text, ref all_code_string);
            return;
        }

        ApplyLine(DB.GetLine(completionDialogId ?? alteredDialogId), ref text, ref all_code_string);
    }
}