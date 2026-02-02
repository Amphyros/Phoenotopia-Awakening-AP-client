using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class StoryManagementPatches
{
    private static readonly HashSet<string> LevelsWithManagementNpcs = ["p1_panselo_village_01"];

    private static readonly FieldInfo LevelPathPrefixField =
        AccessTools.Field(typeof(LevelBuildLogic), "_level_path_prefix");

    private static int _chapter = 0;

    private static readonly string[] ChapterOneEventList =
        ["ABDUCTION_HAPPENED", "CH_1_EVENT_A", "CH_1_EVENT_B", "CH_1_OVER"];

    private static readonly string[] ChapterTwoEventList = ["BIRDY_CAUGHT", "RETURN_W_LISA", "CH_2_OVER"];
    private static readonly string[] ChapterThreeEventList = ["TOWER_ARC_OVER", "CH_3_OVER"];


    [HarmonyPatch(typeof(PT2), "Initialize")]
    [HarmonyPostfix] // Patch to add custom level files
    private static void InitializePostfix()
    {
        string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (modFolder == null)
            return;

        var customLevelsPath = Path.Combine(modFolder, "PhoA_AP_client/");
        if (!Directory.Exists(customLevelsPath))
            Directory.CreateDirectory(customLevelsPath);

        var resources = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceNames()
            .Where(res => res.EndsWith(".xml"));

        foreach (string customLevelXml in resources)
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(customLevelXml);
            if (stream == null) continue;

            string fileName = Path.GetFileNameWithoutExtension(customLevelXml).Split('.').Last() + ".xml";
            string destinationPath = Path.Combine(customLevelsPath, fileName);

            using FileStream fs = File.Create(destinationPath);
            byte[] buffer = new byte[stream.Length];

            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, bytesRead);
            }
        }
    }

    [HarmonyPatch(typeof(PT2), "GIS_ProcessInstructions")]
    [HarmonyPrefix] // Patch to add timewarp GIS command
    private static void GISProcessInstructionsTimewarpPrefix(ref string instructions)
    {
        List<string> instructionsList = instructions.Split('|').ToList();

        foreach (string instruction in instructionsList)
        {
            string[] instructionParts = instruction.Split(',');
            string instructionType = instructionParts[0];

            if (instructionType != "TIME_WARP_RELOAD")
                continue;

            if (!int.TryParse(instructionParts[1], out int newChapter))
                continue;

            PhoaAPClient.Logger.LogDebug($"Timewarp initiated. Force chapter: {newChapter}");

            _chapter = newChapter;
            PT2.LoadLevel(instructionParts[2], 9000, Vector3.zero, false, 1.5f, false, false);
        }

        instructionsList.RemoveAll(instruction => instruction.Contains("TIME_WARP_RELOAD"));

        instructions = string.Join("|", instructionsList.ToArray());
    }

    [HarmonyPatch(typeof(SaveFile), "_Evaluate_QL_BasicPhrase")]
    [HarmonyPostfix]
    private static void EvaluateQLBasicPhrasePostfix(string ql_phrase, ref bool __result)
    {
        if (_chapter <= 0)
            return;

        string[] qlArray = ql_phrase.Split(',');

        if (qlArray[0] != "SI_TRUE" && qlArray[0] != "SI_FALSE")
            return;

        int eventChapter =
            ChapterOneEventList.Contains(qlArray[1]) ? 1 :
            ChapterTwoEventList.Contains(qlArray[1]) ? 2 :
            ChapterThreeEventList.Contains(qlArray[1]) ? 3 :
            0;

        if (eventChapter == 0)
            return;

        bool newResult = qlArray[0] != "SI_FALSE";

        bool invert = eventChapter >= _chapter;

        __result = invert ? !newResult : newResult;
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPrefix] // Patch to set the custom path for modified levels
    private static void LoadLevelPrefix(LevelBuildLogic __instance, string new_level_name)
    {
        string modRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (modRoot == null)
            return;

        if (!LevelsWithManagementNpcs.Contains(new_level_name.ToLower()))
            return;

        LevelPathPrefixField.SetValue(__instance, Path.Combine(modRoot, "PhoA_AP_client/"));
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPostfix] // Patch to reset the directory prefix for level files
    private static void LoadLevelPostfix(LevelBuildLogic __instance)
    {
        string path = Application.dataPath + "/StreamingAssets/Levels/";
        if (!Directory.Exists(path))
            path = Application.dataPath + "/Resources/Data/StreamingAssets/levels/";
        LevelPathPrefixField.SetValue(__instance, path);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPostfix] // Patch to change custom lines for timewarp NPC
    private static void LoadLevelPostfixForTimewarp(string new_level_name)
    {
        if (!LevelsWithManagementNpcs.Contains(new_level_name.ToLower()))
            return;

        PhoaAPClient.Logger.LogWarning($"Level loaded with timewarp NPC: {new_level_name}");
        ConstructAndReplaceTimewarpLines();
    }

    private static void ConstructAndReplaceTimewarpLines()
    {
        bool defeatedSlargummy = PT2.save_file.QL_EvaluateExpression("SI_TRUE,BOSS_SLIME_DEFEATED");
        // bool defeatedBirdy = false;
        // bool defeatedKatash = false;
        PhoaAPClient.Logger.LogDebug($"Defeated Slargummy: {defeatedSlargummy}");

        DB.lines[DB.line_id_map["TIMEWARP_PANSELO"] + 1] = GetPanseloTimeWarpString(defeatedSlargummy);
    }

    // TODO: Expand with all relevant story flags
    private static string GetPanseloTimeWarpString(bool defeatedSlargummy)
    {
        if (!defeatedSlargummy)
            return "GO,TIMEWARP_NOT_AVAILABLE||||";

        StringBuilder backend = new StringBuilder("CHOICE,TIMEWARP_PANSELO+2");
        StringBuilder frontend = new StringBuilder("||Before the abduction");

        if (defeatedSlargummy)
        {
            backend.Append(",TIMEWARP_PANSELO+3");
            frontend.Append("||After the abduction");
        }

        return backend + ",CLOSE_ALL;OWNER,gale||||..." + frontend + "||Never mind";
    }
}