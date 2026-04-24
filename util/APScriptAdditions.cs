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
        ["GEO_ROBOT_01_CUSTOM"] =
        [
            "JUMP_TO,3848,IF_TRUE|SI_TRUE,GEO_TICKET_1;GO,%NextIndex%;GIS,override_npc_anim,geo_bot,green_robot_clap||||Hurray! <*_>Congratulations on completing the GEO challenge!",
            "GO,%NextIndex%||||You're visitor #1 to this location! <*_>That's right, <*_>the very first!",
            "GIS,erase_npc_overrides,geo_bot|FILE_MARK_SI,GEO_TICKET_1,true||||Here's your ticket! <*_>Visit the nearest GEO base to redeem it for prizes!",
        ],
        ["AMANDA_2A_CUSTOM"] =
        [
            "JUMP_TO,856,IF_TRUE|SI_TRUE,KID_LUNCH;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Amanda - <*name_ed></color></size></i><*stop=0.15>\nI was assigned to cooking duty.<*_>.<*_>.<*_> I think I'm getting the hang of it.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Amanda - <*name_ed></color></size></i><*stop=0.15>\nHere, <*_>be my first victim... <*_>Uh, <*_>customer!",
            "GIS,FILE_MARK_SI,KID_LUNCH,true||||<i><size=-10><color=#898989><*name_op>- Amanda - <*name_ed></color></size></i><*stop=0.15>\nWell? <*_>Isn't it just like what grandma Nana used to make?",
        ],
        ["PLANTO_P2_CUSTOM"] =
        [
            "JUMP_TO,PLANTO_DONE,IF_TRUE|SI_TRUE,PLANTO_2;JUMP_TO,PLANTO_P2_CUSTOM+3,IF_TRUE|OC_EXISTS,greet_planto;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nHow nostalgic.<*_> These flowers have grown so big.<*_> And they provide shade for everything below.",
            "GO,%NextIndex%;GIS,FILE_MARK_OC,greet_planto||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nAh. <*_>We meet again.<*_> Try as you might,<*_> you'd have a hard time destroying my shade here.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nHeh heh.<*_> I joke.<*_> I am over that.<*_> Promise.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nHmmm...<*_> the soil balance is off here...",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nFetch me five ''<#00ffff>food</color>'' units please!",
            "OWNER,gale;CHOICE,PLANTO_ON_FOOD,%NextIndex%,PLANTO_ON_FOOD+-1||||...||Ask about ''Food''||Give 5 ''Food'' units||Sorry!",
            "JUMP_TO,PLANTO_REWARD+-2,IF_FALSE|ITEM_HAVE_COUNT,62,5;GO,%NextIndex%;OWNER,planto;GIS,FILE_MARK_SI,PLANTO_2,true|DELAY,0.1|ITEM_remove,62,1|common_sfx,227|DELAY,0.1|ITEM_remove,62,1|common_sfx,227|DELAY,0.1|ITEM_remove,62,1|common_sfx,227|DELAY,0.1|ITEM_remove,62,1|common_sfx,227|DELAY,0.1|ITEM_remove,62,1|common_sfx,227||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nObservation.<*_> Whoever produced these ''food'' units is a terrible cook.",
            "GO,%NextIndex%;OWNER,gale||||...",
            "GO,%NextIndex%;OWNER,planto||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nAgain,<*_> I joke.",
            "GO,%NextIndex%;OWNER,planto;JUMP_TO,PLANTO_REWARD_CUSTOM,IF_TRUE|SI_ALL_TRUE,PLANTO_1,PLANTO_2,PLANTO_3,PLANTO_4,PLANTO_5,PLANTO_6||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nReceive this as payment.",
            "GIS,FILE_MARK_AP,AP_PLANTO_2|HACK_ME_OUT;CLOSE_ALL_DIALOGUE,NULL;WAIT,0.25||||",
        ],
        ["PLANTO_REWARD_CUSTOM"] =
        [
            "||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nStar Iliad will release on April 31st",
        ],
        ["HONEY_BUN_CUSTOM"] =
        [
            "OWNER,hachi;GO,%NextIndex%;FLIP_NPC,hachi,right||||A freshly baked <#00ffff>%APPlayer%%APItem%</color>!<*_> I eat one every day.<*_> The secret to good health, perhaps?",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy %APPlayer%%APItem% for 14 R?||No||Yes",
            "OWNER,hachi;JUMP_TO,HACHI_SAD+1,IF_FALSE|MONEY_HAVE,P1_RAI,14;GIS,money_adjust,P1_RAI,-14|FILE_MARK_AP,HONEY_SHOP_BUN|recycle,shop_1||||Wonderful! <*_>Enjoy the treat!",
        ],
        ["HONEY_BREW_CUSTOM"] =
        [
            "OWNER,hachi;GO,%NextIndex%;FLIP_NPC,hachi,right||||That's <#00ffff>%APPlayer%%APItem%</color>.<*_> It's an invigorating fizzy drink!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy %APPlayer%%APItem% for 20 R?||No||Yes",
            "OWNER,hachi;JUMP_TO,HACHI_SAD+1,IF_FALSE|MONEY_HAVE,P1_RAI,20;GIS,money_adjust,P1_RAI,-20|FILE_MARK_AP,HONEY_SHOP_BREW|recycle,shop_2||||Wonderful! <*_>Enjoy the drink. <*_>It tastes best chilled!",
        ],
        ["HONEY_DROP_CUSTOM"] =
        [
            "OWNER,hachi;GO,%NextIndex%;FLIP_NPC,hachi,right||||Those are <#00ffff>%APPlayer%%APItem%</color>.<*_> They are sweet candy that make kids extra hyper,<*_> hah hah!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy %APPlayer%%APItem% for 24 R?||No||Yes",
            "OWNER,hachi;JUMP_TO,HACHI_SAD+1,IF_FALSE|MONEY_HAVE,P1_RAI,24;GIS,money_adjust,P1_RAI,-24|FILE_MARK_AP,HONEY_SHOP_DROP|recycle,shop_3||||Wonderful! <*_>Enjoy the candy!",
        ],
        ["GEO_ROBOT_02_CUSTOM"] =
        [
            "JUMP_TO,3865,IF_TRUE|SI_TRUE,GEO_TICKET_2;GO,%NextIndex%;GIS,override_npc_anim,geo_bot,green_robot_clap||||Congratulations on completing the GEO challenge!",
            "GO,%NextIndex%||||You're visitor #423 to this location!",
            "GIS,erase_npc_overrides,geo_bot|FILE_MARK_SI,GEO_TICKET_2,true||||Here's your ticket! <*_>Visit the nearest GEO base to redeem it for prizes!",
        ],
        ["OURO_PRINCE_CUSTOM"] =
        [
            "GO,%NextIndex%||||I'll talk. <*_>I'll reveal everything there is to know about the path to the Ouroboros hideout.",
        ],
        ["BANDIT_BOSS_GATE_CUSTOM"] = // TODO: Unfinished
        [
            "JUMP_TO,OURO_PRINCE_3,IF_TRUE|SI_TRUE,CH2_D4_GOT_OCARINA;JUMP_TO,%NextIndex%,IF_TRUE|ITEM_HAVE_COUNT,123,1;GO,1608||||I'm quite serious. <*_>I've cut my ties with Ouroboros!",
            "GO,%NextIndex%||||GASP! <*__>Is that wine for me?",
            "OWNER,gale;CHOICE,1613,%NextIndex%||||Give bandit the bottle of wine?||No||Yes",
            "OWNER,ouro_prince;GO,%NextIndex%;GIS,ITEM_remove,123,1|common_sfx,227||||Thank you! <*_>I've been ready to tell all for a while, <*_>but no one would fulfill my simple request!",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Zeke - <*name_ed></color></size></i><*stop=0.15>\nSince I'm cutting my ties with Ouroboros, <*_>you can have my flute.",
            "GIS,FILE_MARK_SI,CH2_D4_GOT_OCARINA,true|override_npc_idle_anim,ouro_prince,bandit_prince_action||||<i><size=-10><color=#898989><*name_op>- Zeke - <*name_ed></color></size></i><*stop=0.15>\nTake it and repeat after me. <*_>I'll whistle the password until you can play it just as well as I do!"
        ],
        ["MERCHANT_VALA_CUSTOM"] =
        [
            "OWNER,merchant_veg;GO,%NextIndex%||||Those are <#00ffff>%APPlayer%%APItem%</color>.<*_> They're a very healthy snack!<*_> Convenient to carry and to eat!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a handful of %APPlayer%%APItem% for 20 R?||No||Yes",
            "OWNER,merchant_veg;JUMP_TO,MERCHANT_ATAIVEG_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,20;GIS,money_adjust,P1_RAI,-20|FILE_MARK_AP,ATAI_MARKET_BEAN|recycle,shop_1||||Wonderful! <*_>It's always great to serve a fellow connoisseur of legumes!",
        ],
        ["MERCHANT_SQUASH_CUSTOM"] =
        [
            "OWNER,merchant_veg;GO,%NextIndex%||||That's a <#00ffff>%APPlayer%%APItem%</color>.<*_> Eat it directly or in a stew.<*_> It's a robust plant for the extra hungry customer!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 20 R?||No||Yes",
            "OWNER,merchant_veg;JUMP_TO,MERCHANT_ATAIVEG_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,20;GIS,money_adjust,P1_RAI,-20|FILE_MARK_AP,ATAI_MARKET_SQUASH|recycle,shop_2||||Wonderful! <*_>It's always great to serve a fellow connoisseur of cucurbitas!",
        ],
        ["MERCHANT_KELP_CUSTOM"] =
        [
            "OWNER,merchant_veg;GO,%NextIndex%||||Fresh <#00ffff>%APPlayer%%APItem%,</color><*_> just picked from the waters of Moonlight Ravine this morning!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a bushel of %APPlayer%%APItem% for 20 R?||No||Yes",
            "OWNER,merchant_veg;JUMP_TO,MERCHANT_ATAIVEG_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,20;GIS,money_adjust,P1_RAI,-20|FILE_MARK_AP,ATAI_MARKET_KELP|recycle,shop_3||||Wonderful! <*_>It's always great to serve a fellow connoisseur of algae!",
        ],
        ["MERC_MEAT_BOAR_CUSTOM"] =
        [
            "OWNER,merchant_meat;GO,%NextIndex%||||<#00ffff>%APPlayer%%APItem%</color> hunted from a grown boar.<*_> Eat like our primal ancestors!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy %APPlayer%%APItem% for 22 R?||No||Yes",
            "OWNER,merchant_meat;JUMP_TO,MERC_MEAT_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,22;GIS,money_adjust,P1_RAI,-22|FILE_MARK_AP,ATAI_MARKET_BOAR_MEAT|recycle,shop_4||||Thanks for the business! <*_>You've got great taste!",
        ],
        ["MERC_MEAT_DRAKE_CUSTOM"] =
        [
            "OWNER,merchant_meat;GO,%NextIndex%||||You can't say you've experienced Atai until you've tried the <#00ffff>%APPlayer%%APItem%</color>,<*_> our truest delicacy!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 15 R?||No||Yes",
            "OWNER,merchant_meat;JUMP_TO,MERC_MEAT_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,15;GIS,money_adjust,P1_RAI,-15|FILE_MARK_AP,ATAI_MARKET_DRAKE_MEAT|recycle,shop_5||||Thanks for the business! <*_>You've got great taste!",
        ],
        ["MERC_MEAT_FISH_CUSTOM"] =
        [
            "OWNER,merchant_meat;GO,%NextIndex%||||<#00ffff>%APPlayer%%APItem%</color> cut from a medium-sized fish. <*_>Get your essential seafood nutrients!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy %APPlayer%%APItem% for 15 R?||No||Yes",
            "OWNER,merchant_meat;JUMP_TO,MERC_MEAT_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,15;GIS,money_adjust,P1_RAI,-15|FILE_MARK_AP,ATAI_MARKET_FISH_MEAT|recycle,shop_6||||Thanks for the business! <*_>You've got great taste!",
        ],
        ["BUY_PRICKLE_CUSTOM"] =
        [
            "OWNER,atai_doki;GO,%NextIndex%;FLIP_NPC,atai_doki,left||||That's a <#00ffff>%APPlayer%%APItem%</color>.<*_> %APItem%s grow on prickly cacti, but taste sweet.<*_> A reflection of life, perhaps?",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 6 R?||No||Yes",
            "GO,1441;OWNER,atai_doki;JUMP_TO,FRUIT_LADY_FAIL+3,IF_FALSE|MONEY_HAVE,P1_RAI,6;GIS,money_adjust,P1_RAI,-6|FILE_MARK_AP,ATAI_MARKET_PRICKLE|recycle,shop_7||||Enjoy!<*_> I advise you to lightly sear it.<*_> Prickle fruits have a lot of spiky hairs that make them annoying to eat.",
        ],
        ["BUY_BERRY_CUSTOM"] =
        [
            "GO,%NextIndex%;OWNER,atai_doki;FLIP_NPC,atai_doki,right||||That's a <#00ffff>%APPlayer%%APItem%</color>.<*_> It's an exotic, sweet fruit that grows in the eastern countryside.",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 10 R?||No||Yes",
            "OWNER,atai_doki;JUMP_TO,FRUIT_LADY_FAIL+3,IF_FALSE|MONEY_HAVE,P1_RAI,10;GIS,money_adjust,P1_RAI,-10|FILE_MARK_AP,ATAI_MARKET_BERRY|recycle,shop_8||||Pleasure doing business with you!",
        ],
        ["ATAI_DOKI_CUSTOM"] =
        [
            "JUMP_TO,%NextIndex%,IF_TRUE|SI_TRUE,ATAI_SELL_BERRIES;GO,1412||||Hey! <*_>You're from Panselo, are you not? <*_>You exude a lovely rustic charm.",
            "GO,%NextIndex%||||Hi!<*_> What can I do for you?",
            "OWNER,gale;CHOICE,%NextIndex%,1424,1423||||...||Sell berry fruits||How to harvest berry fruits?||Just saying hello",
            "OWNER,atai_doki;JUMP_TO,FRUIT_LADY_FAIL,IF_FALSE|ITEM_HAVE_COUNT,50,4;GIS,ITEM_remove,50,4|FILE_MARK_AP,ATAI_MARKET_BERRY_SELL|common_sfx,227||||Pleasure doing business with you!",
        ],
        ["GEN_MERCHANT_ARMOR_CUSTOM"] =
        [
            "OWNER,merchant_gen;GO,%NextIndex%;FLIP_NPC,merchant_gen,right||||A fashionable <#00ffff>%APPlayer%%APItem%</color>!<*_> It's reinforced with hard leather on the inside to protect you from all manner of blows.",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 150 R?||No||Yes",
            "OWNER,merchant_gen;JUMP_TO,GEN_MERCHANT_ATAI_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,150;GIS,money_adjust,P1_RAI,-150|FILE_MARK_AP,ATAI_SHOP_ARMOR|recycle,shop_1||||A wise choice! <*_>Thank you for the business!",
        ],
        ["GEN_MERCHANT_CROSSBOW_CUSTOM"] =
        [
            "OWNER,merchant_gen;GO,%NextIndex%;FLIP_NPC,merchant_gen,right||||That's a <#00ffff>%APPlayer%%APItem%</color>. <*_>It shoots a fast and straight bolt - <*_>great for striking your foes at a distance!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 125 R?||No||Yes",
            "OWNER,merchant_gen;JUMP_TO,GEN_MERCHANT_ATAI_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,125;GIS,money_adjust,P1_RAI,-125|FILE_MARK_AP,ATAI_SHOP_CROSSBOW|recycle,shop_2||||A wise choice! <*_>Thank you for the business!",
        ],
        ["GEN_MERCHANT_BAT2_CUSTOM"] =
        [
            "OWNER,merchant_gen;GO,%NextIndex%;FLIP_NPC,merchant_gen,right||||That's a <#00ffff>%APPlayer%%APItem%</color>!<*_> It's the next step up if you're still swinging a wooden bat. <*_>It's stronger but just as light!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 200 R?||No||Yes",
            "OWNER,merchant_gen;JUMP_TO,GEN_MERCHANT_ATAI_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,200;GIS,money_adjust,P1_RAI,-200|FILE_MARK_AP,ATAI_SHOP_BAT2|recycle,shop_3||||A wise choice! <*_>Thank you for the business!",
        ],
        ["GEN_MERCHANT_LAMP_CUSTOM"] =
        [
            "OWNER,merchant_gen;GO,%NextIndex%;FLIP_NPC,merchant_gen,right||||A useful <#00ffff>%APPlayer%%APItem%</color>. <*_>No need for oil, <*_>because this lamp is powered by crank energy.<*_> Ward off the darkness with your own hands!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 90 R?||No||Yes",
            "OWNER,merchant_gen;JUMP_TO,GEN_MERCHANT_ATAI_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,90;GIS,money_adjust,P1_RAI,-90|FILE_MARK_AP,ATAI_SHOP_LAMP|recycle,shop_4||||A wise choice! <*_>Thank you for the business!",
        ],
        ["GEN_MERCHANT_POLE_CUSTOM"] =
        [
            "OWNER,merchant_gen;GO,%NextIndex%;FLIP_NPC,merchant_gen,right||||A <#00ffff>%APPlayer%%APItem%</color>!<*_> Become self-sufficient by catching your own food!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 200 R?||No||Yes",
            "OWNER,merchant_gen;JUMP_TO,GEN_MERCHANT_ATAI_NOCOIN,IF_FALSE|MONEY_HAVE,P1_RAI,200;GIS,money_adjust,P1_RAI,-200|FILE_MARK_AP,ATAI_SHOP_POLE|recycle,shop_5||||A wise choice! <*_>Thank you for the business!",
        ],
        ["MEETING_LISA_CUSTOM"] =
        [
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Lisa - <*name_ed></color></size></i><*stop=0.15>\nLet me know if I can help with anything.",
            "OWNER,gale;CHOICE,%NextIndex%,LISA_LOCK_PICK,MEETING_LISA_4+-2,CLOSE_ALL||||...||ID card||Open a door||Your skills?||Never mind!",
            "OWNER,lisa;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Lisa - <*name_ed></color></size></i><*stop=0.15>\nOh, that's easy! <*_>Since you're of age now, just go to Daea's town hall.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Lisa - <*name_ed></color></size></i><*stop=0.15>\nPresent your birth certificate and information. <*_>Wait a month, and ta-da! <*_>ID card!",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Lisa - <*name_ed></color></size></i><*stop=0.15>\nOf course, for the sake of expediency, I could lend you my ID card.",
            "JUMP_TO,%NextIndex%,IF_TRUE|HAIR_IS,brown;GO,1916;GIS,FILE_MARK_AP,LISA_ID||||<i><size=-10><color=#898989><*name_op>- Lisa - <*name_ed></color></size></i><*stop=0.15>\nI bet if you dyed your hair similar to mine, you could convincingly pass for me!",
            "GIS,FILE_MARK_AP,LISA_ID||||<i><size=-10><color=#898989><*name_op>- Lisa - <*name_ed></color></size></i><*stop=0.15>\nWith your hair dyed like that,<*_> you could convincingly look like me!",
        ],
        ["ATAI_NPC_23_CUSTOM"] =
        [
            "JUMP_TO,%NextIndex%,IF_TRUE|SI_FALSE,ATAI_LOOT_1;GIS,FILE_ERASE_OC,atainpc23;OWNER,cooker||||The mayor's mansion is the heart of the city. <*__>When it cries, <*_>the town cries too.",
            "GIS,FILE_ERASE_OC,atainpc23|FILE_MARK_SI,ATAI_LOOT_1,true;OWNER,cooker||||Here! <*_>In case you need to be cheered up a little today.",
        ],
        ["AT_GALLERY_OVER_CUSTOM"] =
        [
            "GO,%NextIndex%;GROUND_NPC,gale;ANIMATE,gale,fall=idle;GIS,uncommon_sfx,whistle|music_adjust,mini_game,vol$0|screen_fade_black,0.5;WAIT,0.6||||",
            "GO,%NextIndex%;WAIT,0.5;GIS,change_scene,p1_atai_shooting_gallery,1232|DELAY,0.2|send_message,gale,RESET_SPRITE||||",
            "GO,AT_GALLERY_LOST;WAIT,0.5;GROUND_NPC,gale;ANIMATE,gale,fall=idle;GIS,screen_fade_clear,0.5;JUMP_AT_END,AT_GALLERY_OVER_A,IF_TRUE|OC_EXISTS,courseA;JUMP_AT_END,AT_GALLERY_OVER_CUSTOM+3,IF_TRUE|OC_EXISTS,courseB;JUMP_AT_END,AT_GALLERY_OVER_CUSTOM+6,IF_TRUE|OC_EXISTS,courseC||||",
            "GO,%NextIndex%;OWNER,archer;JUMP_TO,AT_GALLERY_LOST,IF_FALSE|GB_SCORE_GT,20000||||Congratulations! <*_>You beat the Intermediate Course!",
            "GO,GP9;JUMP_AT_END,%NextIndex%,IF_TRUE|SI_FALSE,HEART_ATAI_3||||That merits a prize. <*_>Here you go!",
            "GIS,FILE_MARK_SI,HEART_ATAI_3,true|AT_scale,heart,vec3(0/0/0),duration$0.25||||",
            "GO,%NextIndex%;OWNER,archer;JUMP_TO,AT_GALLERY_LOST,IF_FALSE|GB_SCORE_GT,30000||||Woah! <*_>You're a great shot! <*_>Even better than the soldiers that come around.",
            "GO,GP10;JUMP_AT_END,%NextIndex%,IF_TRUE|SI_FALSE,MOON_ATAI_8||||That merits a prize. <*_>Here you go!",
            "GIS,FILE_MARK_SI,MOON_ATAI_8,true|AT_scale,moon,vec3(0/0/0),duration$0.25||||",
        ],
        ["BORDER_GUARD_MOON_CUSTOM"] =
        [
            "JUMP_TO,BORDER_GUARD_MOON+4,IF_TRUE|SI_TRUE,MOON_RHODUS_1;GO,%NextIndex%||||If I give you this, <*_>will you go away?",
            "GIS,FILE_MARK_SI,MOON_RHODUS_1,true||||",
        ],
        ["ATAI_BREW_CUSTOM"] =
        [
            "GO,%NextIndex%;OWNER,trader;FLIP_NPC,trader,left||||<#00ffff>%APPlayer%%APItem%</color> caught your eye?<*_> It's a new, popular energy drink.<*_> I sell out every day.<*_> Get one before it's too late!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy %APPlayer%%APItem% for 25 R?||No||Yes",
            "OWNER,trader;JUMP_TO,ATAI_TRADER+2,IF_FALSE|MONEY_HAVE,P1_RAI,25;GIS,money_adjust,P1_RAI,-25|FILE_MARK_AP,ATAI_BORDER_BREW|recycle,shop_1||||Excellent!<*_> If you enjoy it,<*_> please also tell your friends about it!",
        ],
        ["ATAI_CHOCOLATE_CUSTOM"] =
        [
            "GO,%NextIndex%;OWNER,trader;FLIP_NPC,trader,left||||Delicious <#00ffff>%APPlayer%%APItem%</color> imported from Daea.<*_> Ever try chocolate before?<*_> You're in for a real treat!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a box of %APPlayer%%APItem% for 36 R?||No||Yes",
            "OWNER,trader;JUMP_TO,ATAI_TRADER+2,IF_FALSE|MONEY_HAVE,P1_RAI,36;GIS,money_adjust,P1_RAI,-36|FILE_MARK_AP,ATAI_BORDER_CHOCOLATE|recycle,shop_2||||Excellent!<*_> If you enjoy them,<*_> please also tell your friends about them!",
        ],
        ["SHADE_DUCK_CUSTOM"] =
        [
            "OWNER,shady_merchant;GO,%NextIndex%;FLIP_NPC,shady_merchant,left||||It's a <#00ffff>%APPlayer%%APItem%</color>!<*_> Put it in your bath, or give it to your dog...<*_> Endless applications!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 14 R?||No||Yes",
            "OWNER,shady_merchant;JUMP_TO,SHADE_MERCH+-1,IF_FALSE|MONEY_HAVE,P1_RAI,14;GIS,money_adjust,P1_RAI,-14|FILE_MARK_AP,ATAI_BORDER_DUCK|recycle,shop_3||||Hurray!<*_> Thanks!",
        ],
        ["SHADE_LAMP_CUSTOM"] =
        [
            "JUMP_TO,SHADE_LAMP_CUSTOM+12,IF_TRUE|SI_TRUE,FAILED_HAGGLE;GO,%NextIndex%;OWNER,shady_merchant;FLIP_NPC,shady_merchant,left||||That's a <#00ffff>%APPlayer%%APItem%</color>!<*_> It's a little scruffed,<*_> but it illuminates with a can-do attitude!",
            "OWNER,gale;CHOICE,CLOSE_ALL,SHADE_LAMP_CUSTOM+14,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 80 R?||No||Yes||What's the catch?",
            "GO,%NextIndex%;OWNER,shady_merchant||||Well,<*_> it's a bit unsightly...<*_> Kinda like me...<*_> It works just as well as a regular %APPlayer%%APItem%!",
            "OWNER,gale;CHOICE,%NextIndex%,SHADE_LAMP_CUSTOM+14,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 80 R?||No||Yes||Hmmm...",
            "GO,%NextIndex%;OWNER,shady_merchant||||Okay!<*_> Occasionally, it emits a little spark.<*_> It's nothing to be concerned about!",
            "GO,%NextIndex%;OWNER,shady_merchant||||It's a feature, if anything!<*_> What if I sweeten the offer with a 10 R discount?",
            "OWNER,gale;CHOICE,%NextIndex%,SHADE_LAMP_CUSTOM+15,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 70 R?||No||Yes||Hmmm...",
            "GO,%NextIndex%;OWNER,shady_merchant||||Phew.<*_> Tough crowd.<*_> Okay, this is truthfully as low as I can go.",
            "GO,%NextIndex%||||I'll give you this beautiful %APPlayer%%APItem% lamp for a paltry<*_> 60 R.",
            "GO,%NextIndex%||||It's my final offer.<*_> So take it or leave it!",
            "OWNER,gale;CHOICE,%NextIndex%,SHADE_LAMP_CUSTOM+16;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 60 R?||No||Yes",
            "OWNER,shady_merchant;GIS,FILE_MARK_SI,FAILED_HAGGLE,true||||Suit yourself!",
            "GO,%NextIndex%;OWNER,shady_merchant;FLIP_NPC,shady_merchant,left||||It's a <#00ffff>%APPlayer%%APItem%</color>.<*_> If you want it,<*_> it's 80 R.",
            "OWNER,gale;CHOICE,CLOSE_ALL,SHADE_LAMP_CUSTOM+17,2792;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 80 R?||No||Yes||Hmmm...",
            "JUMP_TO,SHADE_MERCH+-1,IF_FALSE|MONEY_HAVE,P1_RAI,80;OWNER,shady_merchant;GIS,money_adjust,P1_RAI,-80|FILE_MARK_AP,ATAI_BORDER_LAMP|recycle,shop_4||||Thanks for the business!<*_> May you and your new lamp have many wonderful memories!",
            "JUMP_TO,SHADE_MERCH+-1,IF_FALSE|MONEY_HAVE,P1_RAI,70;OWNER,shady_merchant;GIS,money_adjust,P1_RAI,-70|FILE_MARK_AP,ATAI_BORDER_LAMP|recycle,shop_4||||Thanks for the business!<*_> May you and your new lamp have many wonderful memories!",
            "JUMP_TO,SHADE_MERCH+-1,IF_FALSE|MONEY_HAVE,P1_RAI,60;OWNER,shady_merchant;GIS,money_adjust,P1_RAI,-60|FILE_MARK_AP,ATAI_BORDER_LAMP|recycle,shop_4||||Thanks for the business!<*_> May you and your new lamp have many wonderful memories!",
            "JUMP_TO,SHADE_MERCH+-1,IF_FALSE|MONEY_HAVE,P1_RAI,80;GO,%NextIndex%;OWNER,shady_merchant;GIS,money_adjust,P1_RAI,-80|FILE_MARK_AP,ATAI_BORDER_LAMP|recycle,shop_4||||Really?<*_> You tested my patience because you really just wanted to pay me more,<*_> didn't you?",
            "||||You're too kind!",
        ],
        ["RHO_MILK_CUSTOM"] =
        [
            "OWNER,rho_merch;GO,%NextIndex%;FLIP_NPC,rho_merch,left||||Quench your thirst with sweet <#00ffff>%APPlayer%%APItem%</color>!<*_> Made fresh this morning with the most fragrant flowers!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy %APPlayer%%APItem% for 15 R?||No||Yes",
            "OWNER,rho_merch;JUMP_TO,RHO_MERCH+-1,IF_FALSE|MONEY_HAVE,P1_RAI,15;GIS,money_adjust,P1_RAI,-15|FILE_MARK_AP,ATAI_BORDER_MILK|recycle,shop_5||||Pleasure doing business with you!",
        ],
        ["RHO_CURRY_CUSTOM"] =
        [
            "OWNER,rho_merch;GO,%NextIndex%;FLIP_NPC,rho_merch,left||||Hot and spicy <#00ffff>%APPlayer%%APItem%</color>!<*_> It's a very popular dish in Rhodus.<*_> The spicy kick might just <i>invigorate your muscles</i>!",
            "CHOICE,CLOSE_ALL,%NextIndex%;GIS,money_show,P1_RAI||||Buy a %APPlayer%%APItem% for 32 R?||No||Yes",
            "OWNER,rho_merch;JUMP_TO,RHO_MERCH+-1,IF_FALSE|MONEY_HAVE,P1_RAI,32;GIS,money_adjust,P1_RAI,-32|FILE_MARK_AP,ATAI_BORDER_CURRY|recycle,shop_6||||Pleasure doing business with you!",
        ],
        ["B_BOT_1_CUSTOM"] =
        [
            "GO,%NextIndex%;JUMP_TO,2821,IF_FALSE|ITEM_CAN_ADD,101,1;JUMP_TO,2821,IF_TRUE|OC_PRESENT,bbot_gift||||All my friends get a little present. <*_>Here, this is for you!",
            "GIS,FILE_MARK_OC,bbot_gift||||",
        ],
        ["RHODUS_GUARD_2_CUSTOM"] =
        [
            "JUMP_TO,%NextIndex%,IF_TRUE|SI_FALSE,MOON_RHODUS_2;JUMP_TO,2699,IF_TRUE|OC_EXISTS,rhoguard2chat;GO,2698||||Do all Castellan soldiers sport your same hover shoes?",
            "GO,%NextIndex%||||D-did you just fly here!? <*_>That's amazing!",
            "GO,%NextIndex%||||I feel compelled to give you something. <*_>Here, take it!",
            "GIS,FILE_MARK_SI,MOON_RHODUS_2,true||||",
        ],
        ["BOAR_BOY_CUSTOM"] =
        [
            "JUMP_TO,%NextIndex%,IF_TRUE|SI_TRUE,MET_BOARBOY;GO,1746||||Oh good! <*_>A traveler! <*_>Perhaps you can help me out?",
            "JUMP_TO,%NextIndex%,IF_TRUE|ITEM_HAVE_COUNT,66,4;GO,1751||||Did you bring the four drake tails?",
            "GO,%NextIndex%||||F-four drake tails! <*_>You really brought them! <*_>You rock!",
            "GO,%NextIndex%||||I've heard great things about drake tail. <*_>I can't wait to try it out.",
            "GO,%NextIndex%;GIS,ITEM_remove,66,1|common_sfx,227|DELAY,0.1|ITEM_remove,66,1|common_sfx,227|DELAY,0.1|ITEM_remove,66,1|common_sfx,227|DELAY,0.1|ITEM_remove,66,1|common_sfx,227||||Ahem. <*_>Now to keep my end of the bargain.",
            "GO,%NextIndex%||||The truth is,<*_> I'm a dojo master! <*_>The name's Boar Boy!",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Boar Boy - <*name_ed></color></size></i><*stop=0.15>\nFrom the beginning, <*_>I've sensed in you a great potential to learn my move.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Boar Boy - <*name_ed></color></size></i><*stop=0.15>\nTo perform this move, <*_>you must think like a boar. <*_>Disregard the self. <*_>Think only of trampling the enemy!",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Boar Boy - <*name_ed></color></size></i><*stop=0.15>\nI call it, <*_>the ''%APPlayer%%APItem%''! .<*_>.<*_>.<*_> Or just ''%APItem%'' for short.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Boar Boy - <*name_ed></color></size></i><*stop=0.15>\nLet's begin lessons immediately.",
            "GO,%NextIndex%;WAIT,0.5;GIS,screen_fade_black,0.5|music_adjust,all,vol$0||||",
            "GO,%NextIndex%;WAIT,7.8;GIS,uncommon_sfx,gale_martial_learning||||",
            "GO,%NextIndex%;GROUND_NPC,gale;WAIT,1;GIS,screen_fade_clear,1|music_adjust,dojo,vol$1|music_adjust,mood_waterfall,vol$0.25||||",
            "GO,%NextIndex%;OWNER,boar_boy||||<i><size=-10><color=#898989><*name_op>- Boar Boy - <*name_ed></color></size></i><*stop=0.15>\nWhew! <*_>You learn quick!",
            "GO,%NextIndex%;GIS,send_message,gale_i,play_anim$133||||<i><size=-10><color=#898989><*name_op>- Boar Boy - <*name_ed></color></size></i><*stop=0.15>\nNow go out there and strike fear into the hearts of your enemies!",
            "GROUND_NPC,gale;ANIMATE,gale,fall=presenting;GIS,FILE_MARK_AP,BOAR_BOY||||",
        ],
        ["PLANTO_INTRO_CUSTOM"] =
        [
            "JUMP_TO,PLANTO_INTRO_CUSTOM+5,IF_TRUE|OC_EXISTS,take_respons;GO,%NextIndex%||||<*rate=25>Excuse you! <*_>You just destroyed my shade.",
            "GO,%NextIndex%;GIS,FILE_MARK_SI,PLANTO_ROCK,true||||<*rate=25>My job just became a lot more unpleasant.",
            "GO,%NextIndex%||||<*rate=25>Without shade,<*_> my body may overheat.",
            "GO,%NextIndex%;GIS,FILE_MARK_OC,take_respons||||<*rate=25>It is unlikely,<*_> for a specimen such as I. <*_>But it can not be ruled out.",
            "GO,%NextIndex%;OWNER,gale||||...",
            "GO,%NextIndex%;OWNER,planto||||<*rate=25>You DO<*_> plan to take responsibility,<*_> correct?",
            "OWNER,gale;CHOICE,%NextIndex%,7336||||...||Yes...||Gotta go!",
            "GO,%NextIndex%;OWNER,planto||||<*rate=25>That is better.<*_> Perhaps there is hope for your generation.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>I am Mr. Planto.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>I carry out the orders of my late master,<*_> Grasso,<*_> to beautify the world.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>And so I plant flowers.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>Do you like flowers?",
            "OWNER,gale;CHOICE,%NextIndex%,PLANTO_INTRO_CUSTOM+21||||...||No||Yes",
            "GO,%NextIndex%;OWNER,planto||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>... I see.<*_> So this mission was a failure from the start.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>Disappointed.",
            "OWNER,gale;CHOICE,PLANTO_INTRO_CUSTOM+19,%NextIndex%||||...||Flowers are pretty||...",
            "GO,%NextIndex%;OWNER,planto||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>So disappointed.",
            "GO,%NextIndex%;OWNER,gale||||...",
            "GO,PLANTO_INTRO_CUSTOM+15;OWNER,planto||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n...",
            "GO,%NextIndex%;OWNER,planto||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>Oh good.<*_> So you were joking.",
            "GO,%NextIndex%+1||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>I am familiar with jokes.<*_> I make them myself.<*_> Sometimes.",
            "GO,%NextIndex%;OWNER,planto||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>I am glad.",
            "GO,PLANTO_P1_CUSTOM;GIS,FILE_MARK_SI,MET_PLANTO,true||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>Now,<*_> let us talk about how you can make things up to me.",
        ],
        ["PLANTO_P1_CUSTOM"] =
        [
            "JUMP_TO,PLANTO_DONE,IF_TRUE|SI_TRUE,PLANTO_1;JUMP_TO,PLANTO_INTRO_CUSTOM,IF_TRUE|SI_FALSE,MET_PLANTO;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\n<*rate=25>The soil balance here is off.<*_> That's bad for the flowers.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nSome compost material would be advantageous.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nFetch me five ''<#00ffff>food</color>'' units please!",
            "OWNER,gale;CHOICE,PLANTO_ON_FOOD,%NextIndex%,PLANTO_ON_FOOD+-1||||...||Ask about ''Food''||Give 5 ''Food'' units||Sorry!",
            "JUMP_TO,PLANTO_REWARD+-2,IF_FALSE|ITEM_HAVE_COUNT,62,5;GO,%NextIndex%;OWNER,planto;GIS,FILE_MARK_SI,PLANTO_1,true|FILE_MARK_OC,just_plantoed|DELAY,0.1|ITEM_remove,62,1|common_sfx,227|DELAY,0.1|ITEM_remove,62,1|common_sfx,227|DELAY,0.1|ITEM_remove,62,1|common_sfx,227|DELAY,0.1|ITEM_remove,62,1|common_sfx,227|DELAY,0.1|ITEM_remove,62,1|common_sfx,227||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nThank you.<*_> Now observe.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nI shall transform this trash into art!",
            "GO,%NextIndex%;WAIT,3||||",
            "GO,%NextIndex%;OWNER,planto||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nOf course,<*_> flowers take some time to grow.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nFor now. <*_>Receive this as payment.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Mr. Planto - <*name_ed></color></size></i><*stop=0.15>\nSurprised?<*_> Mr. Planto is also generous.",
            "GIS,FILE_MARK_AP,AP_PLANTO_1||||",
        ],
        ["GEO_ILLUZ_2_CUSTOM"] =
        [
            "JUMP_TO,2836,IF_TRUE|SI_TRUE,ANCIENT_PIN_1;GO,%NextIndex%||||<*rate=10>mission... <*_>fulfilled... <*_>happy...",
            "GIS,FILE_MARK_SI,ANCIENT_PIN_1,true||||",
        ],
        ["RUBY_BANDIT_2_CUSTOM"] =
        [
            "GO,%NextIndex%;GIS,FILE_MARK_OC,saved_ruby_bandit||||<i><size=-10><color=#898989><*name_op>- Ruby - <*name_ed></color></size></i><*stop=0.15>\nYou did it! <*_>Thanks for saving me!",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Ruby - <*name_ed></color></size></i><*stop=0.15>\nPlease accept this gift with my gratitude!",
            "GIS,FILE_MARK_SI,HEART_BANDIT_3,true||||",
        ],
        ["SELENE_1_CUSTOM"] =
        [
            "JUMP_TO,1182,IF_TRUE|SI_TRUE,BANDIT_KEY_5_COLLECTED;JUMP_TO,SELENE_1_CUSTOM+10,IF_TRUE|POC_EXISTS,selene_shrine_talk;GO,%NextIndex%||||Oh! <*_>An outsider? <*_>You may just be the person I'm looking for...",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nCall me Melody. <*_>Will you hear my trouble?",
            "OWNER,gale;CHOICE,%NextIndex%,CLOSE_ALL||||...||Let's hear it||Too busy!",
            "GO,%NextIndex%;OWNER,selene;GIS,FILE_MARK_POC,selene_shrine_talk||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nThe situation within Ouroboros has deteriorated as of late.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nFights break out daily over who would be the most suitable leader for our tribe.",
            "GO,%NextIndex%;JUMP_TO,%NextIndex%,IF_TRUE|SI_TRUE,BIRDY_CAUGHT||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nIf Birdy continues as tribal chieftain, <*_>I fear things will get a lot worse!",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nWhich is why I think it's time for me to depart from Ouroboros.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nI always did want to pursue the world of dance!",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nBut if I leave without a coin in my purse, <*_>I won't get far...",
            "GO,%NextIndex%+1||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nI would be ever so appreciative if you could help me out...",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nI didn't expect to see you again...",
            "OWNER,gale;CHOICE,%NextIndex%,CLOSE_ALL;GIS,money_show||||...||Give 100 R||Sorry!",
            "OWNER,selene;JUMP_TO,%NextIndex%,IF_TRUE|MONEY_HAVE,P1_RAI,100||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nOh! <*_>It doesn't look like you have much either...",
            "GO,%NextIndex%;OWNER,selene;GIS,money_adjust,P1_RAI,-100||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nMy! <*_>How generous of you! <*_>I won't forget this act of kindness!",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Melody - <*name_ed></color></size></i><*stop=0.15>\nI won't be needing this %APItem% anymore. <*_>Perhaps it can be of use to you?",
            "GIS,FILE_MARK_SI,BANDIT_KEY_5_COLLECTED,true||||",
        ],
        ["WIN_VS_LIHU_CUSTOM"] =
        [
            "GO,%NextIndex%;GROUND_NPC,gale;ANIMATE,gale,fall=idle;WAIT,1.5;GIS,put,lihu,tmx(13/20.5)|cpart,P1_CLOUD,pos$name(lihu),intensity$2,deviation$vec3(1/1/1),dir$UP|cpart,P1_CLOUD,pos$name(lihu),intensity$2,deviation$vec3(1/1/1),dir$UP|common_sfx,101|common_sfx,211|juice_wobble,lihu||||",
            "GO,%NextIndex%;OWNER,lihu;FLIP_NPC,gale,left||||<i><size=-10><color=#898989><*name_op>- Lihu - <*name_ed></color></size></i><*stop=0.15>\nImpressive! <*_>An outsider has passed Lihu's Trial of Stealth?",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Lihu - <*name_ed></color></size></i><*stop=0.15>\nTell Lihu, <*_>why you are here?",
            "OWNER,gale;CHOICE,%NextIndex%,%NextIndex%+3||||...||To bring Birdy to justice!||To obtain great wealth!",
            "OWNER,lihu;GO,%ItemId%||||<i><size=-10><color=#898989><*name_op>- Lihu - <*name_ed></color></size></i><*stop=0.15>\nYou, <*_>an outsider, wish to challenge Lihu's chieftain,<*_> Birdy?",
            "GO,%ItemId%||||<i><size=-10><color=#898989><*name_op>- Lihu - <*name_ed></color></size></i><*stop=0.15>\nHah! <*_>She crush you!",
            "GO,%NextIndex%+1||||<i><size=-10><color=#898989><*name_op>- Lihu - <*name_ed></color></size></i><*stop=0.15>\nNevertheless, <*_>Lihu and Ouroboros tribe recognize strength and cunning!",
            "OWNER,lihu;GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Lihu - <*name_ed></color></size></i><*stop=0.15>\nThat... <*_>is a GREAT answer!",
            "GIS,FILE_MARK_SI,LIHU_KEY_GET,true||||<i><size=-10><color=#898989><*name_op>- Lihu - <*name_ed></color></size></i><*stop=0.15>\nReceive Lihu's Proof!",
        ],
        ["RALA_RACE_OVER_CUSTOM"] =
        [
            "GO,%NextIndex%;GROUND_NPC,gale;ANIMATE,gale,fall=idle;GIS,uncommon_sfx,whistle|music_adjust,mini_game,vol$0||||<i><size=-10><color=#898989><*name_op>- Rala - <*name_ed></color></size></i><*stop=0.15>\nSTOP!!",
            "GO,%NextIndex%;GIS,GB_TIMER_DISMISS|screen_fade_black,0.5;WAIT,0.5||||",
            "GO,%NextIndex%;WAIT,0.1;GIS,change_scene,p1_bandit_lair_rala,0||||",
            "GO,%NextIndex%;WAIT,0.5;GIS,put,gale,tmx(17/26);GROUND_NPC,gale;ANIMATE,gale,fall=idle,face=right||||",
            "GO,%NextIndex%;GIS,screen_fade_clear,0.5|puzzle,id$1,msg$FLIP_OFF|set_physics_layer,gamer,NPC;WAIT,0.5||||",
            "JUMP_TO,%NextIndex%,IF_TRUE|OC_PRESENT,race_game_win;OWNER,gamer;GO,3198||||<i><size=-10><color=#898989><*name_op>- Rala - <*name_ed></color></size></i><*stop=0.15>\nOver the time limit...<*_> Sorry, <*_>but slow and steady does not win this race!",
            "JUMP_TO,3203,IF_TRUE|OC_EXISTS,used_birdys_shortcut;GO,%NextIndex%;OWNER,gamer||||<i><size=-10><color=#898989><*name_op>- Rala - <*name_ed></color></size></i><*stop=0.15>\nWow! <*_>Mightily impressive!",
            "GO,%NextIndex%+2||||<i><size=-10><color=#898989><*name_op>- Rala - <*name_ed></color></size></i><*stop=0.15>\nUh... <*_>It's still not quite as fast as me, of course!",
            "GO,%NextIndex%;OWNER,gamer||||<i><size=-10><color=#898989><*name_op>- Rala - <*name_ed></color></size></i><*stop=0.15>\nBravo! <*_>You bested my course with strategic thinking.",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Rala - <*name_ed></color></size></i><*stop=0.15>\nI can respect a smart warrior!",
            "GO,%NextIndex%||||<i><size=-10><color=#898989><*name_op>- Rala - <*name_ed></color></size></i><*stop=0.15>\nReceive my Proof!",
            "GIS,FILE_MARK_SI,RALA_KEY_GET,true||||",
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

        // TODO: Can't reach this specific line with the current setup. So this is a temporary manual edit
        DB.lines[3088] = "FILE_MARK_SI,ATRI_KEY_GET,true|puzzle,id$9,msg$FLIP_OFF||||";

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