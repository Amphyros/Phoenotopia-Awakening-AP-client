using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            "GIS,TIME_WARP_RELOAD,1,p1_panselo_village_01||||",
            "GIS,TIME_WARP_RELOAD,2,p1_panselo_village_01||||",
            "GIS,TIME_WARP_RELOAD,3,p1_panselo_village_01||||",
            "GIS,TIME_WARP_RELOAD,4,p1_panselo_village_01||||",
        ],
        ["TIMEWARP_NOT_AVAILABLE"] = 
        [
            "OWNER,zophiel;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nThough<*_>, time has yet to pass.",
            "OWNER,zophiel||||<i><size=-10><color=#898989><*name_op>- Zophiel statue - <*name_ed></color></size></i><*stop=0.15>\nPlease come back once time has passed and the world has changed."
        ],
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
        ["MERCHANT_TAO_EGG_CUSTOM"] =
        [
            "OWNER,merchant;GO,%NextIndex%;FLIP_NPC,merchant,left||||<i><size=-10><color=#898989><*name_op>- Tao - <*name_ed></color></size></i><*stop=0.15>\nA newly laid <#00ffff>%APPlayer%%APItem%</color> from our village coop!",
            "CHOICE,MERCHANT_TAO_REJECTED,%NextIndex%;GIS,money_show,P1_RAI||||Buy %APPlayer%%APItem% for 5 R?||No||Yes",
            "OWNER,merchant;JUMP_TO,MERCHANT_TAO_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,5;GIS,money_adjust,P1_RAI,-5|FILE_MARK_AP,PANSELO_SHOP_EGG|recycle,shop_1;GO,312||||<i><size=-10><color=#898989><*name_op>- Tao - <*name_ed></color></size></i><*stop=0.15>\nEnjoy! <*_>By the way, you're also free to pick eggs from the village coop!",
        ],
        ["MERCHANT_TAO_MILK_CUSTOM"] =
        [
            "OWNER,merchant;GO,%NextIndex%;FLIP_NPC,merchant,left||||<i><size=-10><color=#898989><*name_op>- Tao - <*name_ed></color></size></i><*stop=0.15>\nFresh pooki <#00ffff>%APPlayer%%APItem%</color>. <*_>Direct from udder to bottle!",
            "CHOICE,MERCHANT_TAO_REJECTED,%NextIndex%;GIS,money_show,P1_RAI||||Buy %APPlayer%%APItem% for 10 R?||No||Yes",
            "OWNER,merchant;JUMP_TO,MERCHANT_TAO_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,10;GIS,money_adjust,P1_RAI,-10|FILE_MARK_AP,PANSELO_SHOP_MILK|recycle,shop_2||||<i><size=-10><color=#898989><*name_op>- Tao - <*name_ed></color></size></i><*stop=0.15>\nEnjoy!",
        ],
        ["MERCHANT_TAO_POTATO_CUSTOM"] =
        [
            "OWNER,merchant;GO,%NextIndex%;FLIP_NPC,merchant,left||||<i><size=-10><color=#898989><*name_op>- Tao - <*name_ed></color></size></i><*stop=0.15>\nOur village's big <#00ffff>%APPlayer%%APItem%</color>. <*_>These babies put us on the map!<*_> Or so I hear...",
            "CHOICE,MERCHANT_TAO_REJECTED,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 13 R?||No||Yes",
            "OWNER,merchant;JUMP_TO,MERCHANT_TAO_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,13;GIS,money_adjust,P1_RAI,-13|FILE_MARK_AP,PANSELO_SHOP_POTATO|recycle,shop_3||||<i><size=-10><color=#898989><*name_op>- Tao - <*name_ed></color></size></i><*stop=0.15>\nEnjoy! <*_>I recommend cooking it to really improve the flavor!",
        ],
        ["SHELBY_FOREST_CUSTOM"] =
        [
            "JUMP_TO,SHELBY_FOREST+8,IF_TRUE|OC_PRESENT,cooked_in_p1_duri_forest_05&OC_PRESENT,shelby_gave_herb;JUMP_TO,%NextIndex%,IF_TRUE|OC_PRESENT,p1_duri_forest_05_fire_lit;GO,477;GIS,zoom_camera,lvl$1||||<i><size=-10><color=#898989><*name_op>- Shelby - <*name_ed></color></size></i><*stop=0.15>\nElla got tired,<*_> so we're taking a break.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Shelby - <*name_ed></color></size></i><*stop=0.15>\nThanks for lighting the fire! <*_>Now we can cook something!",
            "GO,%NextIndex%;ALT_BINDING||||<i><size=-10><color=#898989><*name_op>- Shelby - <*name_ed></color></size></i><*stop=0.15>\nEquip a <#00ffff>raw item</color> and <#00ffff>examine</color> the fire with <sprite=0> to begin the cooking process!",
            "JUMP_AT_END,%NextIndex%,IF_TRUE|OC_ABSENT,shelby_gave_herb||||<i><size=-10><color=#898989><*name_op>- Shelby - <*name_ed></color></size></i><*stop=0.15>\nAll you have to do is press the appropriate button when it hovers over the center panel. <*_>That's it!",
            "GIS,FILE_MARK_OC,shelby_gave_herb|FILE_ERASE_OC,cooked_in_p1_duri_forest_05||||<i><size=-10><color=#898989><*name_op>- Shelby - <*name_ed></color></size></i><*stop=0.15>\nHere are some cookable herbs for you to try.<*_> I'd do it myself, but I'm afraid I'll mess up!",
        ],
        ["KITER_CUSTOM"] =
        [
            "JUMP_TO,KITER_1,IF_FALSE|OC_PRESENT,talked_kiter;CHOICE,KITER_2,KITER_CUSTOM+1,KITER_CUSTOM+4;OWNER,gale||||...||About the kids...||I'm hungry!||How's the stew coming?",
            "OWNER,kiter;GOIF_FAST,255|SI_TRUE,GOT_KITER_LEFTOVERS;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Kitt - <*name_ed></color></size></i><*stop=0.15>\nThe stew's not ready... <*_>But there are some leftovers from lunch!",
            "OWNER,kiter;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Kitt - <*name_ed></color></size></i><*stop=0.15>\nTake it. <*_>You owe me for this!",
            "GIS,FILE_MARK_SI,GOT_KITER_LEFTOVERS,true||||",
            "OWNER,kiter;JUMP_TO,KITER_4+4,IF_TRUE|SI_TRUE,HELPED_KITER;JUMP_TO,%NextIndex%,IF_TRUE|ITEM_HAVE,int_list(67)||||<i><size=-10><color=#898989><*name_op>- Kitt - <*name_ed></color></size></i><*stop=0.15>\nI've gone overboard with the spices.<*_> Can you get <#00ffff>something</color> from the store to tone it down?",
            "OWNER,kiter;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Kitt - <*name_ed></color></size></i><*stop=0.15>\nI've gone overboard with the spices.<*_> But that milk you brought should do the trick!",
            "OWNER,kiter;GO,%NextIndex%;GIS,ITEM_remove,67,1||||<i><size=-10><color=#898989><*name_op>- Kitt - <*name_ed></color></size></i><*stop=0.15>\nI'll take that!",
            "OWNER,kiter;GIS,FILE_MARK_SI,HELPED_KITER,true||||<i><size=-10><color=#898989><*name_op>- Kitt - <*name_ed></color></size></i><*stop=0.15>\nHere, this should about cover it right?",
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

    public static void ReplacePossibleScriptLines(Check check, bool isFromThisWorld = false)
    {
        string matchKey = CustomLines
            .Where(customLine => check.OverrideType.Contains(customLine.Key))
            .Select(customLine => customLine.Key)
            .FirstOrDefault();

        if (matchKey == null) return;

        string apPlayer = isFromThisWorld ? "" : $"{check.ItemInfo.Player.Name}'s ";

        for (int i = 0; i < CustomLines[matchKey].Count; i++)
        {
            CustomLines[matchKey][i] = CustomLines[matchKey][i].Replace("%APPlayer%", apPlayer);
            CustomLines[matchKey][i] = CustomLines[matchKey][i].Replace("%APItem%", $"{check.ItemInfo.ItemName}");
        }
    }
}