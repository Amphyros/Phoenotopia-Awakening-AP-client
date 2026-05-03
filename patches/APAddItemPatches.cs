using System.Linq;
using System.Text;
using HarmonyLib;
using PhoA_AP_client.AP;
using PhoA_AP_client.util;
using UnityEngine;
using WebSocketSharp;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class APAddItemPatches
{
    [HarmonyPatch(typeof(SaveFile), "_NS_CompactSaveDataAsString")]
    [HarmonyPostfix] // Patch to add an array of collected items to the savefile
    private static void NSCompactSaveDataAsStringPostfix(ref string __result)
    {
        StringBuilder stringBuilder = new StringBuilder(__result);
        var receivedItems = APSaveState.CollectedItems;
        stringBuilder.Append("APITEMS");
        stringBuilder.Append("|");

        for (int i = 0; i < receivedItems.Count; i++)
        {
            stringBuilder.Append(receivedItems[i]);
            stringBuilder.Append("|");
        }

        stringBuilder.Append(",");

        __result = stringBuilder.ToString();
    }

    [HarmonyPatch(typeof(SaveFile), "_NS_ProcessSaveDataString")]
    [HarmonyPostfix] // Patch to extract the collect items from the savefile and compare them to AP
    private static void NSProcessSaveDataStringPostfix(string save_data_string)
    {
        string[] saveDataArray = save_data_string.Split(',');
        string apItemsString = saveDataArray.FirstOrDefault(entry => entry.StartsWith("APITEMS"));

        APSaveState.LoadFromSaveString(apItemsString);

        if (!APHelpers.IsConnectedToAP()) return;
        PhoaAPClient.APConnection.ItemHandler.AddMissingItems();
    }

    [HarmonyPatch(typeof(SaveFile), "_NS_ProcessSaveDataString")]
    [HarmonyPostfix] // Patch to assure all completed NPC locations with an SI value are checked within the game
    private static void NSProcessSaveDataStringNpcCompletionPostfix()
    {
        if (!APHelpers.IsConnectedToAP())
        {
            PhoaAPClient.Logger.LogWarning(
                "Save loaded while disconnected from AP. Please reconnect and reload the save");
            return;
        }

        var matches = LocationMapping.LocationMap.Values
            .SelectMany(checks => checks)
            .Where(check => check.IsNpc && check.IsKeyItem && check.CompletionDialogId == null &&
                            PhoaAPClient.APConnection.SessionContext.Session.Locations.AllLocationsChecked
                                .Contains(check.ArchipelagoId));

        foreach (Check check in matches)
        {
            string identifier = check.DifferingInGameIdentifier ?? check.GISIdentifier;
            PT2.GIS_ProcessInstructions($"FILE_MARK_SI,{identifier},true", Vector3.zero);
        }
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPrefix] // Patch to trigger APConnection.AddMissingItems() on level load
    private static void LoadLevelPrefix(ref bool __state)
    {
        __state = false;

        if (!LevelBuildLogic.level_name.IsNullOrEmpty() && LevelBuildLogic.level_name.Equals("game_start"))
            __state = true;
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPostfix] // Postfix follow-up of LoadLevelPrefix()
    private static void LoadLevelPostfix(string new_level_name, bool __state)
    {
        if (!APHelpers.IsConnectedToAP() || __state) return;

        PhoaAPClient.APConnection.ItemHandler.AddMissingItems();
    }
}