using System.Collections.Generic;
using System.Linq;

namespace PhoA_AP_client.util;

internal static class APScriptAdditions
{
    private static readonly Dictionary<string, List<string>> CustomLines = new()
    {
        ["NANA_CUSTOM"] =
        [
            "JUMP_TO,NANA+6,IF_TRUE|SI_TRUE,NANA_MUFFIN;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Nana - <*name_ed></color></size></i><*stop=0.15>\nI've baked muffins for tonight's dessert.",
            "GO,239;GIS,FILE_MARK_SI,NANA_MUFFIN,true||||<i><size=-10><color=#898989><*name_op>- Nana - <*name_ed></color></size></i><*stop=0.15>\nHere, you may enjoy yours early.",
        ],
        ["CLEM_CUSTOM"] =
        [
            "JUMP_TO,CLEM_2,IF_TRUE|POC_EXISTS,clem_gave_potato;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Jon - <*name_ed></color></size></i><*stop=0.15>\nHi, Gail! <*_>Good timing! <*_>I'd like to do a quality check for our upcoming harvest.",
            "GIS,POC_WRITE,clem_gave_potato;GO,357||||<i><size=-10><color=#898989><*name_op>- Jon - <*name_ed></color></size></i><*stop=0.15>\nSo please,<*_> eat this potato!",
        ],
        ["TAO_CUSTOM"] =
        [
            "OWNER,merchant;JUMP_TO,317,IF_FALSE|SI_FALSE,TAO_PRESENT;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Tao - <*name_ed></color></size></i><*stop=0.15>\nThanks for always looking after Ren.",
            "GIS,FILE_MARK_SI,TAO_PRESENT,true||||<i><size=-10><color=#898989><*name_op>- Tao - <*name_ed></color></size></i><*stop=0.15>\nMy mom made extra fruit jam, and she insists your family have them.",
        ],
        ["SETH_FOREST_CUSTOM"] =
        [
            "OWNER,seth;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Seth - <*name_ed></color></size></i><*stop=0.15>\nIf the anuri were alive today,<*_> do you think they would eat<*_> people?",
            "OWNER,seth;JUMP_AT_END,%NextIndex%,IF_TRUE|POC_ABSENT,seth_liz||||<i><size=-10><color=#898989><*name_op>- Seth - <*name_ed></color></size></i><*stop=0.15>\nSpeaking of eating,<*_> have you seen any small <#00ffff>green lizards</color> crawling about?<*_> You can shoot them for a scrumptious snack!",
            "GIS,FILE_MARK_POC,seth_liz;||||<i><size=-10><color=#898989><*name_op>- Seth - <*name_ed></color></size></i><*stop=0.15>\nYou can have this one I caught.",
        ],
        ["ALEX_GIVES_SLINGSHOT_CUSTOM"] =
        [
            "GO,%NextIndex%;OWNER,alex2||||<i><size=-10><color=#898989><*name_op>- Alex - <*name_ed></color></size></i><*stop=0.15>\nHmmm... <*_>I'm not having much success here...",
            "GO,%NextIndex%;GIS,override_npc_anim,alex,alex_idle;WAIT,0.5||||",
            "GO,%NextIndex%;FLIP_NPC,alex,left;WAIT,0.5;GIS,put,alex,name(alex2)|put,alex2,tmx(2/23)||||",
            "GO,%NextIndex%;OWNER,alex||||<i><size=-10><color=#898989><*name_op>- Alex - <*name_ed></color></size></i><*stop=0.15>\nHere, you try it!",
            "GIS,FILE_MARK_AP,AP_DOKI_ALEX_GIFT||||",
        ],
    };

    public static void AddCustomScriptLines()
    {
        List<string> lines = DB.lines.ToList();
        foreach (var customLine in CustomLines)
        {
            string lineLabel = customLine.Key;
            int lineIndex = lines.Count;

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