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
            "OWNER,zophiel;GO,RELOAD_GAME||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nYour wish shall be granted.",
            "OWNER,zophiel;GO,RELOAD_GAME+1||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nYour wish shall be granted.",
            "OWNER,zophiel;GO,RELOAD_GAME+2||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nYour wish shall be granted.",
            "OWNER,zophiel;GO,RELOAD_GAME+3||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nYour wish shall be granted.",
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
        ["141"] =
        [
            "GO,142;WAIT,2;PROFILE,static;VOICE,static;COLOR_BUBBLE,H7ab5c9;COLOR_TEXT,H364971;GIS,muffle_timeout,5.5|common_sfx,186,pan$0|send_message,gale,DISPLAY_ITEM,29|DELAY,2.5|common_sfx,188"
        ],
        ["154"] = ["GIS,SAVE"],
        ["1766"] =
        [
            "GO,1767;GROUND_NPC,gale;ANIMATE,gale,fall=presenting;GIS,haze_screen,color$00ffff,alpha$0.5,transition$1,hold_time$4"
        ],
        ["3223"] =
        [
            "PROFILE,static;VOICE,static;COLOR_BUBBLE,H7ab5c9;COLOR_TEXT,H364971;OWNER,none;GOIF_FAST,3224|ITEM_HAVE_COUNT,111,3;GOIF_FAST,3225|ITEM_HAVE_COUNT,111,1"
        ],
        ["3358"] =
        [
            "GO,3359;GROUND_NPC,gale;ANIMATE,gale,fall=presenting;GIS,haze_screen,color$00ffff,alpha$0.5,transition$1,hold_time$4"
        ],
        ["5492"] =
        [
            "GO,5493;GROUND_NPC,gale;ANIMATE,gale,fall=presenting;GIS,haze_screen,color$00ffff,alpha$0.5,transition$1,hold_time$4"
        ],
        ["6397"] = ["GO,6398;GROUND_NPC,gale;ANIMATE,gale,fall=presenting"],
        ["7618"] =
        [
            "GO,7619;GROUND_NPC,gale;ANIMATE,gale,fall=presenting;GIS,haze_screen,color$00ffff,alpha$0.5,transition$1,hold_time$4"
        ],
        ["8228"] =
        [
            "GO,8229;GROUND_NPC,gale;ANIMATE,gale,fall=presenting;GIS,haze_screen,color$00ffff,alpha$0.5,transition$1,hold_time$4"
        ],
        ["8363"] = ["GO,8364;GROUND_NPC,gale;ANIMATE,gale,fall=presenting"],
        ["8366"] = ["GO,STOP_DISPLAY_ITEM;PROFILE,static;VOICE,static;COLOR_BUBBLE,H7ab5c9;COLOR_TEXT,H364971"],
        ["8430"] =
        [
            "GO,8431;GROUND_NPC,gale;ANIMATE,gale,fall=presenting;GIS,haze_screen,color$00ffff,alpha$0.5,transition$1,hold_time$4"
        ],
        ["8433"] = ["GO,STOP_DISPLAY_ITEM;PROFILE,static;VOICE,static;COLOR_BUBBLE,H7ab5c9;COLOR_TEXT,H364971"],
        ["9015"] =
        [
            "GO,9016;GROUND_NPC,gale;ANIMATE,gale,fall=presenting;GIS,haze_screen,color$00ffff,alpha$0.5,transition$1,hold_time$4"
        ],
        ["9435"] =
        [
            "GO,9488;WAIT,1;GIS,screen_fade_black,0.9|FRAN_QUEST_WARP_OPEN,WARP_OPEN_PANSELO|FILE_MARK_SI,FRAN_QUEST_10,true|moonstones_expend,10"
        ],
        ["9514"] =
        [
            "GO,9515;WAIT,4;GIS,FRAN_QUEST_WARP_OPEN,WARP_OPEN_ATAI|FILE_MARK_SI,FRAN_QUEST_20,true|moonstones_expend,10|FILE_MARK_SI,FRAN_FOOD,false|screen_fade_black,0.75|DELAY,1|uncommon_sfx,frontloader_printer_spawn,pitch$1.2|DELAY,2.5|uncommon_sfx,hint_bell|change_scene,p1_frans_base,99"
        ],
        ["9540"] =
        [
            "GO,9541;WAIT,4;GIS,FRAN_QUEST_WARP_OPEN,WARP_OPEN_CROP|FILE_MARK_SI,FRAN_QUEST_30,true|moonstones_expend,10|FILE_MARK_SI,FRAN_FOOD,false|screen_fade_black,0.75|DELAY,1|uncommon_sfx,frontloader_printer_spawn,pitch$1.2|DELAY,2.5|uncommon_sfx,hint_bell|change_scene,p1_fran_geo_outside,98"
        ],
        ["10222"] = ["PROFILE,static;TXT_BOX_WIDTH,1000;VOICE,static;POS,0.5,0.5;CHOICE,10227,10226,10225,10224,10223"],
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