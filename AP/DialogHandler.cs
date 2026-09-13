using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Archipelago.MultiClient.Net.Models;
using BepInEx;
using JetBrains.Annotations;
using PhoA_AP_client.util;
using PhoA_AP_client.util.DataClasses;

namespace PhoA_AP_client.AP;

public class DialogHandler
{
    private readonly List<DialogPatch> _dialogPatches = [];

    public void AddDialogPatch(
        Dictionary<int, List<string[]>> dialogPatches,
        long archipelagoId,
        [CanBeNull] ScoutedItemInfo scoutedItemInfo,
        bool isFromThisWorld = false,
        int? postCompletionDialogId = null)
    {
        _dialogPatches.Add(new DialogPatch
        {
            DialogReplacements = dialogPatches,
            ArchipelagoId = archipelagoId,
            ScoutedItem = scoutedItemInfo,
            IsFromThisWorld = isFromThisWorld,
            PostCompletionDialogId = postCompletionDialogId,
        });
    }

    public void ApplyDialogPatchesToGame()
    {
        List<string> lines = DB.lines.ToList();
        foreach (var dialogPatch in _dialogPatches)
        {
            string playerName = dialogPatch.ScoutedItem == null || dialogPatch.IsFromThisWorld
                ? ""
                : $"{dialogPatch.ScoutedItem.Player.Name}'s ";
            string itemName = dialogPatch.ScoutedItem == null ? "Nothing" : dialogPatch.ScoutedItem.ItemName;
            int bonusLineId = -1;

            if (dialogPatch.DialogReplacements.TryGetValue(-1, out var bonusDialog))
            {
                lines.Add(bonusDialog[0][0] + "||||");
                bonusLineId = lines.Count - 1;
            }

            foreach (var dialogReplacements in dialogPatch.DialogReplacements)
            {
                if (dialogReplacements.Key == -1) continue;

                int targetLineId = dialogReplacements.Key;

                if (lines[targetLineId].Contains("GO_AP"))
                {
                    string[] lineValues = lines[targetLineId].Split(["||||"], StringSplitOptions.None)[0].Split(',');
                    int lineToAlter = int.Parse(lineValues[2]);
                    lines[lineToAlter] = ApplyReplacements(lines[lineToAlter], dialogReplacements.Value, playerName,
                        itemName, bonusLineId, dialogPatch.ArchipelagoId);
                    lines[targetLineId] = lines[targetLineId]
                        .Replace(lineValues[3], $"{lineValues[3]}&{dialogPatch.ArchipelagoId}");
                    continue;
                }

                string originalDialog = lines[targetLineId];
                lines.Add(originalDialog);
                int originalDialogId = lines.Count - 1;

                lines.Add(
                    ApplyReplacements(originalDialog, dialogReplacements.Value, playerName, itemName, bonusLineId,
                        dialogPatch.ArchipelagoId));
                int alteredDialogId = lines.Count - 1;

                string newLine = $"GO_AP,{originalDialogId},{alteredDialogId},{dialogPatch.ArchipelagoId}";
                if (dialogPatch.PostCompletionDialogId > -1) newLine += $",{dialogPatch.PostCompletionDialogId}";
                // NOTE: GO_AP sentinel must have non-empty text after ||||
                // DirectorLogic.Update() treats empty text as a signal to close the dialoguer
                // and runs _ProcessTextAndCodes in actions mode, causing audio/positioning glitches
                newLine += "||||Filler dialog";

                lines[targetLineId] = newLine;
            }
        }

        DB.lines = lines.ToArray();
        APScriptAdditions.AddCustomScriptLines();
    }

    private string ApplyReplacements(string dialog, List<string[]> replacements, string playerName,
        string itemName, int bonusLineId, long archipelagoId)
    {
        foreach (string[] dialogReplacement in replacements)
        {
            string replacement = dialogReplacement[1]
                .Replace("%APPlayer%", playerName)
                .Replace("%APItem%", itemName)
                .Replace("%BonusLine%", bonusLineId > -1 ? bonusLineId.ToString() : "UnknownLine")
                .Replace("%APId%", $"{archipelagoId}");

            Match match = Regex.Match(dialogReplacement[1], @"%APPlayer/(.+?)%");
            if (match.Success)
            {
                foreach (Group group in match.Groups)
                    replacement = replacement
                        .Replace($"%APPlayer/{group.Value}%",
                            playerName.IsNullOrWhiteSpace() ? group.Value : playerName);
            }

            dialog = dialog.Replace(dialogReplacement[0], replacement);
        }

        return dialog;
    }
}