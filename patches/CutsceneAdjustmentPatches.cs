using HarmonyLib;
using PhoA_AP_client.util;
using UnityEngine;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
public class CutsceneAdjustmentPatches
{
    // TODO: Edit level files in a way to handle the cutscene without interference of patches
    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPostfix] // Patch to manipulate the slingshot cutscene
    private static void LoadLevelPostfix(string new_level_name)
    {
        if (new_level_name.ToLower() != "p1_duri_forest_06") return;
        if (PT2.save_file.QL_EvaluateExpression("ITEM_HAVE,int_list(30)")) return;

        PT2.GIS_ProcessInstructions(
            "put,alex2,name(alex)+vec3(3/0/0)|put,alex,tmx(2/23)|override_npc_anim,alex2,alex_slingshot",
            Vector3.zero);
    }

    [HarmonyPatch(typeof(SaveFile), "QL_EvaluateExpression")]
    [HarmonyPrefix] // Patch to force level state for Anuri temple entrance
    private static void QLEvaluateExpressionPrefix(ref string expression)
    {
        if (LevelBuildLogic.level_name != "p1_duri_forest_06") return;
        if (!APHelpers.IsConnectedToAP())
        {
            PhoaAPClient.Logger.LogWarning(
                "This room was loaded while disconnected from the AP server. Wrong level state might be loaded");
            return;
        }

        const long targetId = 7676008;

        if (!PhoaAPClient.APConnection.SessionContext.Session.Locations.AllLocations.Contains(targetId)) return;

        bool alexChecked =
            PhoaAPClient.APConnection.SessionContext.Session.Locations.AllLocationsChecked.Contains(targetId);

        expression = expression.Replace("ITEM_HAVE,int_list(30)", alexChecked ? "ALWAYS_TRUE" : "ALWAYS_FALSE");
        expression = expression.Replace("ITEM_DONT_HAVE,int_list(30)", alexChecked ? "ALWAYS_FALSE" : "ALWAYS_TRUE");
    }
}