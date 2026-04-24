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
    private static void LoadLevelAnuriTempleEntrancePostfix(string new_level_name)
    {
        if (new_level_name.ToLower() != "p1_duri_forest_06") return;
        if (PT2.save_file.QL_EvaluateExpression("ITEM_HAVE,int_list(30)")) return;

        PT2.GIS_ProcessInstructions(
            "put,alex2,name(alex)+vec3(3/0/0)|put,alex,tmx(2/23)|override_npc_anim,alex2,alex_slingshot",
            Vector3.zero);
    }

    [HarmonyPatch(typeof(DirectorLogic), "IntroSetDifficultyLevel")]
    [HarmonyPrefix] // Patch to apply game state dependant options from AP at the start of the playthrough
    private static void IntroSetDifficultyLevelPrefix()
    {
        if (!APHelpers.IsConnectedToAP()) return;

        PT2.GIS_ProcessInstructions("FILE_MARK_SI,CH2_D1_GOT_WINE_QUEST,true", Vector3.zero);
        PT2.GIS_ProcessInstructions("FILE_MARK_SI,CH_2_A_MET_LISA,true", Vector3.zero);
        PT2.GIS_ProcessInstructions("FILE_MARK_SI,CH_2_B_MET_MAYOR,true", Vector3.zero);
        PT2.GIS_ProcessInstructions("FILE_MARK_SI,CH_2_C_LISA_ENLISTED,true", Vector3.zero);
        PT2.GIS_ProcessInstructions("FILE_MARK_SI,CH2_D2_GOT_ID_QUEST,true", Vector3.zero);
        PT2.GIS_ProcessInstructions("FILE_MARK_SI,CH2_E1_GOT_BOMB_QUEST,true", Vector3.zero);

        if (PhoaAPClient.APConnection.SessionContext.Login.SlotData.TryGetValue("open_panselo_gates",
                out var openPanseloGates) && (long)openPanseloGates == 1)
            PT2.GIS_ProcessInstructions(
                "FILE_MARK_SI,PANSELO_GATE_W_OPENED,true|FILE_MARK_SI,PANSELO_GATE_E_OPENED,true", Vector3.zero);
    }

    [HarmonyPatch(typeof(SaveFile), "_Evaluate_QL_BasicPhrase")]
    [HarmonyPrefix] // Patch to add ITEM_DONT_HAVE_COUNT to _Evaluate_QL_BasicPhrase
    private static bool EvaluateQLBasicPhrasePrefix(string ql_phrase, ref bool __result, SaveFile __instance)
    {
        if (!ql_phrase.Contains("ITEM_DONT_HAVE_COUNT")) return true;

        string[] splitQLPhrase = ql_phrase.Split(',');
        var method = AccessTools.Method(typeof(SaveFile), "_QL_HandleItemsHaveCount");
        __result = !(bool)method.Invoke(__instance, [splitQLPhrase]);

        return false;
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

        bool checkExcluded =
            !PhoaAPClient.APConnection.SessionContext.Session.Locations.AllLocations.Contains(targetId);
        bool alexChecked =
            PhoaAPClient.APConnection.SessionContext.Session.Locations.AllLocationsChecked.Contains(targetId);

        expression = expression
            .Replace("ITEM_HAVE,int_list(30)", alexChecked || checkExcluded ? "ALWAYS_TRUE" : "ALWAYS_FALSE");
        expression = expression
            .Replace("ITEM_DONT_HAVE,int_list(30)", alexChecked || checkExcluded ? "ALWAYS_FALSE" : "ALWAYS_TRUE");
    }
}