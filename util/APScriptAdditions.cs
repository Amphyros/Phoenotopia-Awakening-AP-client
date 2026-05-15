using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoA_AP_client.util;

internal static class APScriptAdditions
{
    private static readonly Dictionary<string, List<string>> CustomLines = new()
    {
        ["TIMEWARP_PANSELO"] =
        [
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nIf you wish to go to a certain point in time, you need only ask.",
            "CHOICE,TIMEWARP_PANSELO+2,TIMEWARP_PANSELO+3,TIMEWARP_PANSELO+4,TIMEWARP_PANSELO+5,CLOSE_ALL;OWNER,gale||||...||Before the abduction||After the abduction||After returning home with Lisa||After hearing Leo's story||Never mind",
            "OWNER,zophiel;GO,RELOAD_GAME||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nOption 1 was chosen. <*_>Your wish shall be granted.",
            "OWNER,zophiel;GO,RELOAD_GAME+1||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nOption 2 was chosen. <*_>Your wish shall be granted.",
            "OWNER,zophiel;GO,RELOAD_GAME+2||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nOption 3 was chosen. <*_>Your wish shall be granted.",
            "OWNER,zophiel;GO,RELOAD_GAME+3||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nOption 4 was chosen. <*_>Your wish shall be granted.",
        ],
        ["RELOAD_GAME"] =
        [
            "GIS,TIME_WARP_RELOAD,1,p1_panselo_village_01;WAIT,1.25||||",
            "GIS,TIME_WARP_RELOAD,2,p1_panselo_village_01;WAIT,1.25||||",
            "GIS,TIME_WARP_RELOAD,3,p1_panselo_village_01;WAIT,1.25||||",
            "GIS,TIME_WARP_RELOAD,4,p1_panselo_village_01;WAIT,1.25||||",
        ],
        ["TIMEWARP_NOT_AVAILABLE"] =
        [
            "OWNER,zophiel;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nThough<*_>, time has yet to pass.",
            "OWNER,zophiel||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nPlease come back once time has passed and the world has changed."
        ],
        ["3223"] =
        [
            "PROFILE,static;VOICE,static;COLOR_BUBBLE,H7ab5c9;COLOR_TEXT,H364971;OWNER,none;GOIF_FAST,3224|ITEM_HAVE_COUNT,111,3;GOIF_FAST,3225|ITEM_HAVE_COUNT,111,1",
        ],
    };

    public static void AddCustomScriptLines()
    {
        List<string> lines = DB.lines.ToList();
        foreach (var customLine in CustomLines)
        {
            string lineLabel = customLine.Key;
            int lineIndex = lines.Count;

            if (int.TryParse(lineLabel, out int lineToReplace))
            {
                string originalLineText = DB.lines[lineToReplace].Split(["||||"], StringSplitOptions.None)[1];
                lines[lineToReplace] = $"{customLine.Value[0]}||||{originalLineText}";
                continue;
            }

            DB.line_id_map.Add(lineLabel, lineIndex);

            foreach (string line in customLine.Value)
            {
                lineIndex++;
                lines.Add(line.Replace("%NextIndex%", lineIndex.ToString()));
            }
        }

        DB.lines = lines.ToArray();
    }
}