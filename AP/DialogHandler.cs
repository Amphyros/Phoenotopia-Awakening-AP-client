using System.Collections.Generic;
using System.Linq;
using Archipelago.MultiClient.Net.Models;
using PhoA_AP_client.util;

namespace PhoA_AP_client.AP;

public class DialogHandler
{
    private List<DialogPatch> _dialogPatches = new();

    public void AddDialogPatch(
        Dictionary<int, List<string[]>> dialogPatches,
        long archipelagoId,
        ScoutedItemInfo scoutedItemInfo,
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
            string playerName = dialogPatch.IsFromThisWorld ? "" : dialogPatch.ScoutedItem.Player.Name;
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
                    int lineToAlter = int.Parse(lines[targetLineId].Split(',')[2]);
                    lines[lineToAlter] = ApplyReplacements(lines[lineToAlter], dialogReplacements.Value, playerName,
                        dialogPatch.ScoutedItem.ItemName, bonusLineId);
                    continue;
                }

                string originalDialog = lines[targetLineId];
                lines.Add(originalDialog);
                int originalDialogId = lines.Count - 1;

                lines.Add(ApplyReplacements(originalDialog, dialogReplacements.Value, playerName,
                    dialogPatch.ScoutedItem.ItemName, bonusLineId));
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
        string itemName, int bonusLineId)
    {
        foreach (string[] dialogReplacement in replacements)
        {
            string replacement = dialogReplacement[1]
                .Replace("%APPlayer%", playerName)
                .Replace("%APItem%", itemName)
                .Replace("%BonusLine%", bonusLineId > -1 ? bonusLineId.ToString() : "UnknownLine");
            dialog = dialog.Replace(dialogReplacement[0], replacement);
        }

        return dialog;
    }
}