using System.Collections.Generic;
using PhoA_AP_client.util.DataClasses;

namespace PhoA_AP_client.util;

public class LocationMapping
{
    public static readonly Dictionary<string, List<Check>> LocationMap = new()
    {
        ["p1_panselo_tower_right"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676000,
                ObjectIds = ["55"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_PANSELO_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_PANSELO_1,true;ql=SI_FALSE,HEART_PANSELO_1",
            },
            new Check
            {
                ArchipelagoId = 7676187,
                ObjectIds = ["96", "97"],
                IsKeyItem = false,
                GISIdentifier = "PANSELO_TRAP_CHEST",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$PANSELO_TRAP_CHEST",
            },
        },
        ["p1_panselo_house_ruth"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676001,
                ObjectIds = ["142"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_PANSELO_2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_PANSELO_2,true;ql=SI_FALSE,HEART_PANSELO_2",
            },
        },
        ["p1_panselo_village_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676028,
                ObjectIds = ["21"],
                IsKeyItem = false,
                GISIdentifier = "P1_PV_dandy1",
                OverrideType =
                    "id=%ItemId%;ql=OC_ABSENT,P1_PV_dandy1;collected_GIS=FILE_MARK_OC,P1_PV_dandy1;gravity=0",
            },
        },
        ["p1_panselo_village_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676029,
                ObjectIds = ["9"],
                IsKeyItem = false,
                GISIdentifier = "P1_PV_dandy2",
                OverrideType =
                    "id=%ItemId%;ql=OC_ABSENT,P1_PV_dandy2;collected_GIS=FILE_MARK_OC,P1_PV_dandy2;gravity=0",
            },
            new Check
            {
                ArchipelagoId = 7676069,
                ObjectIds = ["73"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [356] = [["JUMP_TO,CLEM_1+-1,IF_TRUE|ITEM_CANNOT_ADD,102,1;", ""], ["ITEM_add,102,1|", ""]],
                },
                GISIdentifier = "clem_gave_potato",
                OverrideType =
                    "name=clem;profile=digger;voice=man,1;speech=CLEM_1;behavior=action_only",
            }
        },
        ["p1_panselo_perro_coop"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676030,
                ObjectIds = ["21"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_EGG_4",
                OverrideType =
                    "id=%ItemId%;gravity=0;ql=SI_FALSE,REGEN_EGG_4;collected_GIS=FILE_MARK_SI,REGEN_EGG_4,true",
            },
        },
        ["p1_panselo_tower_left"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676031,
                ObjectIds = ["87"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_PANSELO_LOOT_1",
                OverrideType =
                    "type=P1_WOOD_S;ql=SI_FALSE,REGEN_PANSELO_LOOT_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_PANSELO_LOOT_1",
            },
            new Check
            {
                ArchipelagoId = 7676041,
                ObjectIds = ["89"],
                IsKeyItem = false,
                GISIdentifier = "AP_PANSELO_LIZARD_1",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_PANSELO_LIZARD_1;instruction=tmx(23/25),tmx(30/27),tmx(29.875/25);sort=bg_tiles,6",
            },
            new Check
            {
                ArchipelagoId = 7676061,
                ObjectIds = ["22"],
                IsKeyItem = true,
                GISIdentifier = "PANSELO_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$PANSELO_MONEY_1;ql=SI_FALSE,PANSELO_MONEY_1"
            }
        },
        ["p1_panselo_house_01_girls"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676032,
                ObjectIds = ["75"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_GOLD_EGG2",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,ABDUCTION_HAPPENED&SI_FALSE,REGEN_GOLD_EGG2;collected_GIS=FILE_MARK_SI,REGEN_GOLD_EGG2,true",
            },
        },
        ["p1_panselo_house_01_boys"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676058,
                ObjectIds = ["74"],
                IsKeyItem = true,
                GISIdentifier = "PANSELO_MONEY_6",
                OverrideType =
                    "type=P1_ATAI_CERAMIC_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$PANSELO_MONEY_6;ql=SI_FALSE,PANSELO_MONEY_6&SI_FALSE,ABDUCTION_HAPPENED;use_all_bright",
            },
        },
        ["p1_panselo_house_01_attic"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676060,
                ObjectIds = ["32"],
                IsKeyItem = true,
                GISIdentifier = "PANSELO_MONEY_5",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$PANSELO_MONEY_5;ql=SI_FALSE,PANSELO_MONEY_5",
            },
        },
        ["p1_panselo_house_01_hall"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676059,
                ObjectIds = ["287"],
                IsKeyItem = true,
                GISIdentifier = "PANSELO_MONEY_7",
                OverrideType =
                    "type=P1_WOOD_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$PANSELO_MONEY_7;ql=SI_FALSE,PANSELO_MONEY_7",
            },
            new Check // TODO: make non-missable (via time travel?)
            {
                ArchipelagoId = 7676556,
                ObjectIds = ["195"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [993] = [["this potato", "%APPlayer%%APItem%"], ["GO,994", "GO,996"]],
                    [996] = [["ITEM_add,102,1", "FILE_MARK_AP,AP_HEADS_OR_TAILS"]],
                },
                GISIdentifier = "AP_HEADS_OR_TAILS",
                OverrideType =
                    "name=game_kid;voice=MAN,1.15;profile=seth;behavior=stand;speech=HEADS_OR_TAILS;use_all_bright",
            },
        },
        ["p1_panselo_house_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676068,
                ObjectIds = ["31"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [238] = [["ITEM_add,47,1|", ""]],
                },
                GISIdentifier = "NANA_MUFFIN",
                OverrideType =
                    "all_bright;name=nana;voice=woman,0.94;profile=nana;behavior=action_talk;spacing=left,0.5;sort=fg_tiles,4;speech=NANA+2,NANA",
            },
            new Check
            {
                ArchipelagoId = 7676077,
                ObjectIds = ["30"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [253] = [["GIS,FILE_MARK_SI,GOT_KITER_LEFTOVERS,true;", ""]],
                    [254] = [["ITEM_add,49,1", "FILE_MARK_SI,GOT_KITER_LEFTOVERS,true"]],
                },
                GISIdentifier = "GOT_KITER_LEFTOVERS",
                OverrideType =
                    "name=kiter;profile=kiter;speech=KITER_1;behavior=action_talk;spacing=right,0.5;face_right",
            },
            new Check
            {
                ArchipelagoId = 7676078,
                ObjectIds = ["30"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [257] = [[";GIS,FILE_MARK_SI,HELPED_KITER,true", ""]],
                    [259] = [["money_adjust,P1_RAI,20", "FILE_MARK_SI,HELPED_KITER,true"]],
                },
                GISIdentifier = "HELPED_KITER",
                OverrideType =
                    "name=kiter;profile=kiter;speech=KITER_1;behavior=action_talk;spacing=right,0.5;face_right",
            },
            new Check
            {
                /* TODO:
                1. GISIdentifier is not unique
                2. Non-missable post-birdy via time travel?
                3. Implement new post-birdy check 7676550 (id="80")
                */
                ArchipelagoId = 7676090,
                ObjectIds = ["69"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [854] = [["JUMP_TO,855,IF_TRUE|ITEM_CANNOT_ADD,59,1;", ""], ["ITEM_add,59,1|", ""]],
                },
                GISIdentifier = "KID_LUNCH",
                OverrideType =
                    "name=amanda;voice=woman,1.1;profile=amanda;behavior=path,25,22;speech=AMANDA_2A,AMANDA_2A+6;sort=fg_tiles,-1",
            }
        },
        ["p1_panselo_shop"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676070,
                ObjectIds = ["51"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [316] = [["GO,GP1", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,TAO_PRESENT,true"]],
                },
                GISIdentifier = "TAO_PRESENT",
                OverrideType =
                    "profile=tao;name=merchant;voice=man,1.02;speech=TAO,TAO+2;behavior=stand",
            },
            new Check
            {
                ArchipelagoId = 7676072,
                HintWhenLoaded = true,
                ObjectIds = ["50"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [309] = [["perro egg", "%APPlayer%%APItem%"]],
                    [310] = [["a Perro Egg", "%APPlayer%%APItem%"]],
                    [311] =
                    [
                        ["JUMP_TO,MERCHANT_TAO_NOSPACE,IF_FALSE|ITEM_CAN_ADD,52,1;", ""],
                        ["ITEM_add,52,1", "FILE_MARK_AP,PANSELO_SHOP_EGG|recycle,shop_1"]
                    ],
                },
                GISIdentifier = "PANSELO_SHOP_EGG",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_1;speech=MERCHANT_TAO_EGG",
            },
            new Check
            {
                ArchipelagoId = 7676073,
                HintWhenLoaded = true,
                ObjectIds = ["48"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [306] = [["milk", "%APPlayer%%APItem%"]],
                    [307] = [["a Bottle of Milk", "%APPlayer%%APItem%"]],
                    [308] =
                    [
                        ["JUMP_TO,MERCHANT_TAO_NOSPACE,IF_FALSE|ITEM_CAN_ADD,67,1;", ""],
                        ["ITEM_add,67,1", "FILE_MARK_AP,PANSELO_SHOP_MILK|recycle,shop_2"]
                    ],
                },
                GISIdentifier = "PANSELO_SHOP_MILK",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_2;speech=MERCHANT_TAO_MILK",
            },
            new Check
            {
                ArchipelagoId = 7676074,
                HintWhenLoaded = true,
                ObjectIds = ["52"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [303] = [["potato", "%APPlayer%%APItem%"]],
                    [304] = [["a Potato", "%APPlayer%%APItem%"]],
                    [305] =
                    [
                        ["JUMP_TO,MERCHANT_TAO_NOSPACE,IF_FALSE|ITEM_CAN_ADD,102,1;", ""],
                        ["ITEM_add,102,1", "FILE_MARK_AP,PANSELO_SHOP_POTATO|recycle,shop_3"]
                    ],
                },
                GISIdentifier = "PANSELO_SHOP_POTATO",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_3;speech=MERCHANT_TAO_POTATO",
            },
            /* TODO:
            1. GISIdentifiers of the following checks are not unique 
            2. Non-missable post-birdy via time travel?
            3. Implement new post-birdy checks 7676551-7676555
            */
            new Check
            {
                ArchipelagoId = 7676084,
                ObjectIds = ["64"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_SUPPLY_1",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_SUPPLY_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_SUPPLY_1",
            },
            new Check
            {
                ArchipelagoId = 7676085,
                ObjectIds = ["69"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_SUPPLY_2",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_SUPPLY_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_SUPPLY_2",
            },
            new Check
            {
                ArchipelagoId = 7676086,
                ObjectIds = ["70"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_SUPPLY_3",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_SUPPLY_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_SUPPLY_3",
            },
            new Check
            {
                ArchipelagoId = 7676087,
                ObjectIds = ["71"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_SUPPLY_4",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_SUPPLY_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_SUPPLY_4",
            },
            new Check
            {
                ArchipelagoId = 7676088,
                ObjectIds = ["72"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_SUPPLY_5",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_SUPPLY_5;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_SUPPLY_5",
            },
        },
        ["p1_panselo_dojo"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676082,
                ObjectIds = ["76"],
                IsKeyItem = true,
                GISIdentifier = "PANSELO_MONEY_4",
                OverrideType =
                    "type=p1_spider;instruction=1;initial_behavior=punching_bag;defeated_GIS=FILE_MARK_OC,pdojo_bag_down|CONTINUE_IF,SI_FALSE,PANSELO_MONEY_4|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$PANSELO_MONEY_4;ql=OC_ABSENT,pdojo_bag_down",
            }
        },
        ["p1_panselo_dojo_a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676089,
                ObjectIds = ["47"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "AELLA_QUEST_4",
                OverrideType =
                    "remove;name=song_field;can_learn=3;desired_song=3;GIS=common_sfx,150|FILE_MARK_SI,AELLA_QUEST_4,true",
            }
        },
        ["p1_panselo_warehouse"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676080,
                ObjectIds = ["22"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                GISIdentifier = "WOODEN_BAT",
                OverrideType =
                    "name=bat_item;id=%ItemId%;collected_GIS=FILE_MARK_AP,WOODEN_BAT",
            },
            new Check
            {
                ArchipelagoId = 7676062,
                ObjectIds = ["100"],
                IsKeyItem = true,
                GISIdentifier = "PANSELO_MONEY_0",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$PANSELO_MONEY_0;ql=SI_FALSE,PANSELO_MONEY_0",
            },
        },
        ["p1_ex_forest_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676002,
                ObjectIds = ["138"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_FOREST_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_FOREST_1,true;ql=SI_FALSE,OXY_FOREST_1;name=FOCUS_PT",
            },
        },
        ["p1_ex_forest_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676003,
                ObjectIds = ["67"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_FIELD_1",
                OverrideType =
                    "type=P1_BANDIT_POT_S;ql=SI_FALSE,MOON_FIELD_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FIELD_1",
            },
            new Check
            {
                ArchipelagoId = 7676081,
                ObjectIds = ["75"],
                IsKeyItem = true,
                GISIdentifier = "PANSELO_MONEY_2",
                OverrideType =
                    "type=P1_BANDIT_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$PANSELO_MONEY_2;ql=SI_FALSE,PANSELO_MONEY_2",
            },
        },
        ["p1_ex_fields_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676004,
                ObjectIds = ["54"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_FIELD_2",
                OverrideType =
                    "type=P1_BANDIT_POT_S;ql=SI_FALSE,MOON_FIELD_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FIELD_2;name=pot",
            },
        },
        ["biome_flowers_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676005,
                ObjectIds = ["41"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_MAP_2",
                OverrideType =
                    "name=beez;type=p1_bee;instruction=tmx(-1/14),tmx(128/14);defeated_GIS=particle_emitter,bee_highlighter,stop|common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_MAP_2",
            },
        },
        ["p1_duri_forest_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676043,
                ObjectIds = ["239"],
                IsKeyItem = false,
                GISIdentifier = "AP_DOKI_LIZARD_2",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DOKI_LIZARD_2;instruction=tmx(16/20),tmx(18/26),tmx(17.875/21);sort=bg_tiles,11",
            },
        },
        ["p1_duri_forest_03a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676006,
                ObjectIds = ["204"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_DOKI_1",
                OverrideType =
                    "type=P1_WOOD_S;ql=SI_FALSE,MOON_DOKI_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_DOKI_1",
            },
        },
        ["p1_duri_forest_04"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676044,
                ObjectIds = ["174"],
                IsKeyItem = false,
                GISIdentifier = "AP_DOKI_LIZARD_3",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DOKI_LIZARD_3;instruction=tmx(61/29),tmx(64/34),tmx(63.875/30);sort=bg_tiles,11",
            },
            new Check
            {
                ArchipelagoId = 7676063,
                ObjectIds = ["33"],
                IsKeyItem = true,
                GISIdentifier = "D_FOREST_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;ql=SI_FALSE,D_FOREST_MONEY_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$D_FOREST_MONEY_1|CONTINUE_IF,NAME_EXISTS,crawl_tut|put,crawl_tut,vec3(0/0/0)",
            }
        },
        ["p1_duri_forest_05"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676045,
                ObjectIds = ["330"],
                IsKeyItem = false,
                GISIdentifier = "AP_DOKI_LIZARD_4",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DOKI_LIZARD_4;instruction=tmx(42/36),tmx(53/40),tmx(41.875/38);sort=bg_tiles,7",
            },
            new Check
            {
                ArchipelagoId = 7676046,
                ObjectIds = ["331"],
                IsKeyItem = false,
                GISIdentifier = "AP_DOKI_LIZARD_5",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DOKI_LIZARD_5;instruction=tmx(22/42),tmx(27/45),tmx(23.875/42);sort=bg_tiles,7",
            },
            new Check
            {
                ArchipelagoId = 7676092,
                ObjectIds = ["327"],
                IsKeyItem = true,
                GISIdentifier = "D_FOREST_MONEY_2",
                OverrideType =
                    "type=P1_ANURI_CERAMIC_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$D_FOREST_MONEY_2;ql=SI_FALSE,D_FOREST_MONEY_2",
            },
            new Check
            {
                ArchipelagoId = 7676076,
                ObjectIds = ["101"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [482] = [["&ITEM_CAN_ADD,45,1", ""]],
                    [483] = [["GO,GP2", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_OC,shelby_gave_herb|FILE_ERASE_OC,cooked_in_p1_duri_forest_05"]],
                },
                GISIdentifier = "shelby_gave_herb",
                OverrideType =
                    "name=shelby;voice=WOMAN,1.15;profile=shelby;behavior=stand;spacing=auto,0.25;speech=SHELBY_FOREST;all_bright",
            },
        },
        ["p1_duri_forest_06"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676007,
                ObjectIds = ["257"],
                IsKeyItem = true,
                GISIdentifier = "D_FOREST_MONEY_3",
                OverrideType =
                    "name=scale_fish;instruction=FISH_M;type=fish;defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$D_FOREST_MONEY_3|particle_emitter,highlighter2,stop;ql=ALWAYS_TRUE",
            },
            new Check
            {
                ArchipelagoId = 7676093,
                ObjectIds = ["273"],
                IsKeyItem = true,
                GISIdentifier = "REGEN_LAST", // Unsure why this is a regen and not a money identifier
                OverrideType =
                    "type=P1_ANURI_CERAMIC_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_LAST;ql=SI_FALSE,REGEN_LAST",
            },
            new Check
            {
                ArchipelagoId = 7676008,
                ObjectIds = ["130"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                IsNpc = true,
                CompletionDialogId = 537,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [536] = [["GO,GP4", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_AP,AP_DOKI_ALEX_GIFT"]],
                },
                GISIdentifier = "AP_DOKI_ALEX_GIFT",
                OverrideType =
                    "name=alex2;face_right;spacing=left,0.5;voice=man,1.1;profile=alex;behavior=action_only;speech=ALEX_GIVES_SLINGSHOT",
            },
            new Check
            {
                ArchipelagoId = 7676079,
                ObjectIds = ["152"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ANURI_4",
                OverrideType =
                    "type=P1_ANURI_CERAMIC_POT_S;ql=SI_FALSE,MOON_ANURI_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ANURI_4;name=moon1",
            },
            new Check
            {
                ArchipelagoId = 7676071,
                ObjectIds = ["123", "264"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [531] = [["GO,GP5", "GO,%BonusLine%"], [";JUMP_AT_END,532,IF_FALSE|ITEM_CAN_ADD,112,1", ""]],
                    [-1] = [["GIS,FILE_MARK_POC,seth_liz"]],
                },
                GISIdentifier = "seth_liz",
                OverrideType =
                    "name=seth;face_right;voice=man,1.15;profile=seth;behavior=stand;speech=SETH_FOREST+3,SETH_FOREST",
            },
        },
        ["p1_anuri_temple_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676009,
                ObjectIds = ["36"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_1_COLLECTED",
                OverrideType =
                    "name=SHINY_BONE1;type=P1_ANURI_CORPSE;GIS=particle_emitter,highlighter,stop|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ANURI_KEY_1_COLLECTED;ql=SI_FALSE,ANURI_KEY_1_COLLECTED;hp=4",
            },
            new Check
            {
                ArchipelagoId = 7676047,
                ObjectIds = ["74"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_1",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_1;instruction=tmx(13/15),tmx(19/19),tmx(13/15);sort=bg_tiles,12",
            },
            new Check
            {
                ArchipelagoId = 7676048,
                ObjectIds = ["75"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_2",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_2;instruction=tmx(65/15),tmx(75/18),tmx(70/15);sort=bg_tiles,12",
            },
            new Check
            {
                ArchipelagoId = 7676049,
                ObjectIds = ["76"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_3",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_3;instruction=tmx(94/28),tmx(97/34),tmx(97/31);sort=bg_tiles,12",
            },
            new Check
            {
                ArchipelagoId = 7676050,
                ObjectIds = ["77"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_4",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_4;instruction=tmx(71/29),tmx(75/35),tmx(75/29);sort=bg_tiles,12",
            },
        },
        ["p1_anuri_temple_02a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676010,
                ObjectIds = ["16"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_3_COLLECTED",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_3_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_3_COLLECTED,true;name=SHINY_LOOT",
            },
            new Check
            {
                ArchipelagoId = 7676066,
                ObjectIds = ["79"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_ANURI_RIN_1",
                OverrideType =
                    "type=P1_ANURI_CERAMIC_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_ANURI_RIN_1;ql=SI_FALSE,REGEN_ANURI_RIN_1",
            },
        },
        ["p1_anuri_temple_02c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676011,
                ObjectIds = ["37"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_5_COLLECTED",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_5_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_5_COLLECTED,true;name=SHINY_LOOT",
            },
            new Check
            {
                ArchipelagoId = 7676134,
                ObjectIds = ["170"],
                IsKeyItem = false,
                GISIdentifier = "herb_at02c2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_OC,herb_at02c2;ql=OC_ABSENT,herb_at02c2",
            },
            new Check
            {
                ArchipelagoId = 7676135,
                ObjectIds = ["171"],
                IsKeyItem = false,
                GISIdentifier = "herb_at02c1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_OC,herb_at02c1;ql=OC_ABSENT,herb_at02c1",
            },
        },
        ["p1_anuri_temple_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676064,
                ObjectIds = ["14"],
                IsKeyItem = true,
                GISIdentifier = "REGEN_BONE_RIN_1",
                OverrideType =
                    "type=P1_ANURI_CORPSE;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_BONE_RIN_1;ql=SI_FALSE,REGEN_BONE_RIN_1",
            }
        },
        ["p1_anuri_temple_04d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676012,
                ObjectIds = ["25"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_ANURI_1",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,OXY_ANURI_1;collected_GIS=FILE_MARK_SI,OXY_ANURI_1,true",
            },
            new Check
            {
                ArchipelagoId = 7676054,
                ObjectIds = ["136"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_8",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_8;instruction=tmx(24/11),tmx(28/14),tmx(23.875/12);sort=bg_tiles,12",
            },
        },
        ["p1_anuri_temple_04c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676013,
                ObjectIds = ["42"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ANURI_6",
                OverrideType =
                    "type=P1_ANURI_CERAMIC_POT_S;ql=SI_FALSE,MOON_ANURI_6;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ANURI_6",
            },
            new Check
            {
                ArchipelagoId = 7676053,
                ObjectIds = ["43"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_7",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_7;instruction=tmx(22/13),tmx(32/14),tmx(24/14);sort=bg_tiles,12",
            },
            new Check
            {
                ArchipelagoId = 7676065,
                ObjectIds = ["74"],
                IsKeyItem = true,
                GISIdentifier = "REGEN_BONE_RIN_2",
                OverrideType =
                    "type=P1_ANURI_CORPSE;face_right;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_BONE_RIN_2;ql=SI_FALSE,REGEN_BONE_RIN_2",
            },
        },
        ["p1_anuri_temple_04b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676014,
                ObjectIds = ["13"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_7_COLLECTED",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_7_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_7_COLLECTED,true|light_change,pearlstone_light,intensity$0;name=FOCUS_PT",
            },
        },
        ["p1_anuri_temple_01b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676015,
                ObjectIds = ["51"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_ANURI_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_ANURI_1,true;ql=SI_FALSE,HEART_ANURI_1;name=FOCUS_PT",
            },
            new Check
            {
                ArchipelagoId = 7676040,
                ObjectIds = ["79"],
                IsKeyItem = false,
                GISIdentifier = "herb_at01b1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_OC,herb_at01b1;ql=OC_ABSENT,herb_at01b1",
            },
        },
        ["p1_anuri_temple_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676016,
                ObjectIds = ["64"],
                IsKeyItem = true,
                GISIdentifier = "AP_ANURI_1",
                OverrideType =
                    "type=P1_ANURI_CERAMIC_POT_L;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_1",
            },
            new Check
            {
                ArchipelagoId = 7676051,
                ObjectIds = ["140"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_5",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_5;instruction=tmx(45/17),tmx(58/19),tmx(54.875/17);sort=bg_tiles,11",
            }
        },
        ["p1_anuri_temple_03b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676017,
                ObjectIds = ["61"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ANURI_2",
                OverrideType =
                    "type=P1_ANURI_CERAMIC_POT_L;ql=SI_FALSE,MOON_ANURI_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ANURI_2",
            },
            new Check
            {
                ArchipelagoId = 7676052,
                ObjectIds = ["125"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_6",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_6;instruction=tmx(46/6),tmx(52/10),tmx(49.875/6);sort=bg_tiles,7",
            }
        },
        ["p1_anuri_temple_03c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676018,
                ObjectIds = ["22"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_4_COLLECTED",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_4_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_4_COLLECTED,true;name=SHINY_LOOT",
            },
        },
        ["p1_anuri_temple_03a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676019,
                ObjectIds = ["5"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_2_COLLECTED",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_2_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_2_COLLECTED,true;name=SHINY_LOOT",
            },
            new Check
            {
                ArchipelagoId = 7676091,
                ObjectIds = ["93"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_MOUSE_1",
                OverrideType =
                    "name=mouse2;type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_MOUSE_1;instruction=tmx(57/20)",
            },
        },
        ["p1_anuri_temple_05"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676022,
                ObjectIds = ["98"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ANURI_1",
                OverrideType =
                    "ql=SI_FALSE,MOON_ANURI_1;profile=WEAK_ROCK;layers_to_erase=3,5;destroyed_by_bombs;particle_color=c3bb77;tiles_to_erase=tmx(48/30),tmx(50/31);destroyed_GIS=common_sfx,150|SPAWN_loot,%ItemId%,pos$tmx(49/31),loot_GIS_MARK_SI$MOON_ANURI_1"
            },
            new Check
            {
                ArchipelagoId = 7676023,
                ObjectIds = ["57"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_10_COLLECTED",
                OverrideType =
                    "name=slime1;type=p1_slimeboss;defeated_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ANURI_KEY_10_COLLECTED|particle_emitter,highlighter,stop;ql=SI_FALSE,ANURI_KEY_10_COLLECTED"
            },
            new Check
            {
                ArchipelagoId = 7676067,
                ObjectIds = ["118"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_LOOT_1_GET",
                OverrideType =
                    "type=P1_ANURI_CERAMIC_POT_L;ql=SI_FALSE,ANURI_LOOT_1_GET;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ANURI_LOOT_1_GET"
            },
        },
        ["p1_anuri_temple_05a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676020,
                ObjectIds = ["25"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_6_COLLECTED",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_6_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_6_COLLECTED,true;name=SHINY_LOOT",
            },
        },
        ["p1_anuri_temple_05b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676021,
                ObjectIds = ["84"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_9_COLLECTED",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_9_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_9_COLLECTED,true;name=SHINY_LOOT",
            },
        },
        ["p1_anuri_temple_01c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676024,
                ObjectIds = ["12"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ANURI_3",
                OverrideType =
                    "id=%ItemId%;name=MOON_STONE;collected_GIS=FILE_MARK_SI,MOON_ANURI_3,true;ql=SI_FALSE,MOON_ANURI_3"
            },
        },
        ["p1_anuri_temple_01d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676075,
                ObjectIds = ["132"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                GISIdentifier = "ANURI_TEMPLE_GOLEM_HEAD",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_AP,ANURI_TEMPLE_GOLEM_HEAD",
            },
            new Check
            {
                ArchipelagoId = 7676025,
                ObjectIds = ["191"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_FISH_3",
                OverrideType =
                    "name=moon_fish;face_right;initial_behavior=STATIC;type=fish;instruction=FISH_M;defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FISH_3|particle_emitter,fish_highlighter,stop;ql=ALWAYS_TRUE",
            }, // Can't get this with the possible amount of stamina
        },
        ["p1_anuri_temple_06a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676026,
                ObjectIds = ["71"],
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_8_COLLECTED",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_8_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_8_COLLECTED,true;name=FOCUS_PT",
            },
            new Check
            {
                ArchipelagoId = 7676057,
                ObjectIds = ["74"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_11",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_11;instruction=tmx(48/27),tmx(52/31),tmx(50.875/28);sort=bg_tiles,11",
            }
        },
        ["p1_anuri_temple_06b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676027,
                ObjectIds = ["68"],
                IsKeyItem = true,
                GISIdentifier = "AP_ANURI_2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_AP,AP_ANURI_2,true;name=FOCUS_PT",
            },
        },
        ["p1_ex_geo_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676033,
                ObjectIds = ["195"],
                IsKeyItem = false,
                GISIdentifier = "geo_01_loot1",
                OverrideType =
                    "id=%ItemId%;gravity=0;collected_GIS=FILE_MARK_POC,geo_01_loot1;ql=POC_ABSENT,geo_01_loot1",
            },
        },
        ["p1_ex_geo_01b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676083,
                ObjectIds = ["287"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3847] = [["Here's your ticket", "Here's %APPlayer/your %%APItem%"], ["|ITEM_add,140,1", ""]],
                },
                GISIdentifier = "GEO_TICKET_1",
                OverrideType =
                    "name=geo_bot;voice=robot,1;profile=green_robot;behavior=stand;speech=GEO_ROBOT_01",
            },
        },
        ["p1_teleport_panselo_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676034,
                ObjectIds = ["209"],
                IsKeyItem = false,
                GISIdentifier = "tele_pan_01_loot1",
                OverrideType =
                    "id=%ItemId%;gravity=0;collected_GIS=FILE_MARK_POC,tele_pan_01_loot1;ql=POC_ABSENT,tele_pan_01_loot1",
            },
        },
        ["p1_duri_forest_02a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676035,
                ObjectIds = ["102"],
                IsKeyItem = false,
                GISIdentifier = "df2a_herb1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_OC,df2a_herb1;ql=OC_ABSENT,df2a_herb1",
            },
            new Check
            {
                ArchipelagoId = 7676036,
                ObjectIds = ["107"],
                IsKeyItem = false,
                GISIdentifier = "df2a_herb2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_OC,df2a_herb2;ql=OC_ABSENT,df2a_herb2",
            },
            new Check
            {
                ArchipelagoId = 7676037,
                ObjectIds = ["101"],
                IsKeyItem = false,
                GISIdentifier = "df2a_herb3",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_OC,df2a_herb3;ql=OC_ABSENT,df2a_herb3",
            },
            new Check
            {
                ArchipelagoId = 7676042,
                ObjectIds = ["154"],
                IsKeyItem = false,
                GISIdentifier = "AP_DOKI_LIZARD_1",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DOKI_LIZARD_1;instruction=tmx(33/13),tmx(36/16),tmx(35.875/13);sort=bg_tiles,11",
            },
        },
        ["p1_anuri_temple_04a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676038,
                ObjectIds = ["62"],
                IsKeyItem = false,
                GISIdentifier = "herb_at04a1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_OC,herb_at04a1;ql=OC_ABSENT,herb_at04a1",
            },
            new Check
            {
                ArchipelagoId = 7676039,
                ObjectIds = ["63"],
                IsKeyItem = false,
                GISIdentifier = "herb_at04a2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_OC,herb_at04a2;ql=OC_ABSENT,herb_at04a2",
            },
            new Check
            {
                ArchipelagoId = 7676055,
                ObjectIds = ["34"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_9",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_9;instruction=tmx(84/16),tmx(90/19),tmx(89/18);sort=bg_tiles,30",
            },
            new Check
            {
                ArchipelagoId = 7676056,
                ObjectIds = ["71"],
                IsKeyItem = false,
                GISIdentifier = "AP_ANURI_TEMPLE_LIZARD_10",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_TEMPLE_LIZARD_10;instruction=tmx(45/11),tmx(49/18),tmx(47/12);sort=bg_tiles,30",
            },
        },
        ["p1_anuri_temple_pod"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676194,
                ObjectIds = ["233"],
                IsKeyItem = true,
                GISIdentifier = "GOT_ANURI_POD",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,GOT_ANURI_POD;collected_GIS=FILE_MARK_SI,GOT_ANURI_POD,true|light_change,urn_light,intensity$0,t$2|common_sfx,186",
            },
        },
        ["p1_sunflower_road_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676094,
                ObjectIds = ["13"],
                IsKeyItem = false,
                GISIdentifier = "SFR_01",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_01;ql=POC_ABSENT,SFR_01",
            },
            new Check
            {
                ArchipelagoId = 7676095,
                ObjectIds = ["12"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_FLOWER_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,MOON_FLOWER_1,true;ql=SI_FALSE,MOON_FLOWER_1",
            },
            new Check
            {
                ArchipelagoId = 7676096,
                ObjectIds = ["16"],
                IsKeyItem = false,
                GISIdentifier = "SFR_02",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_02;ql=POC_ABSENT,SFR_02",
            },
            new Check
            {
                ArchipelagoId = 7676097,
                ObjectIds = ["26"],
                IsKeyItem = false,
                GISIdentifier = "SFR_04",
                OverrideType =
                    "gravity=0;angle=270;id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_04;ql=POC_ABSENT,SFR_04",
            },
            new Check
            {
                ArchipelagoId = 7676098,
                ObjectIds = ["25"],
                IsKeyItem = false,
                GISIdentifier = "SFR_03",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_03;ql=POC_ABSENT,SFR_03",
            },
            new Check
            {
                ArchipelagoId = 7676099,
                ObjectIds = ["27"],
                IsKeyItem = true,
                GISIdentifier = "FLOWER_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$FLOWER_MONEY_1;ql=SI_FALSE,FLOWER_MONEY_1",
            },
            new Check
            {
                ArchipelagoId = 7676100,
                ObjectIds = ["33"],
                IsKeyItem = false,
                GISIdentifier = "SFR_06",
                OverrideType =
                    "gravity=0;angle=270;id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_06;ql=POC_ABSENT,SFR_06",
            },
            new Check
            {
                ArchipelagoId = 7676101,
                ObjectIds = ["31"],
                IsKeyItem = false,
                GISIdentifier = "SFR_05",
                OverrideType =
                    "angle=90;gravity=0;id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_05;ql=POC_ABSENT,SFR_05",
            },
            new Check
            {
                ArchipelagoId = 7676102,
                ObjectIds = ["24"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_FLOWER_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_FLOWER_1,true;ql=SI_FALSE,HEART_FLOWER_1",
            },
        },
        ["p1_sunflower_road_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676103,
                ObjectIds = ["12"],
                IsKeyItem = false,
                GISIdentifier = "SFR_13",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_13;ql=POC_ABSENT,SFR_13",
            },
            new Check
            {
                ArchipelagoId = 7676104,
                ObjectIds = ["11"],
                IsKeyItem = false,
                GISIdentifier = "SFR_12",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_12;ql=POC_ABSENT,SFR_12",
            },
            new Check
            {
                ArchipelagoId = 7676105,
                ObjectIds = ["56"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [7381] = [["GO,PLANTO_REWARD+-1", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_AP,AP_PLANTO_2"]],
                },
                GISIdentifier = "AP_PLANTO_2",
                DifferingInGameIdentifier = "PLANTO_2",
                OverrideType =
                    "name=planto;profile=planto;voice=man,0.85;speech=PLANTO_P2;sort=bg_tiles,-1;behavior=action_only;ql=SI_FALSE,PLANTO_2",
            },
        },
        ["p1_sunflower_road_02a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676106,
                HintWhenLoaded = true,
                ObjectIds = ["63"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1150] = [["honey bun", "%APPlayer%%APItem%"]],
                    [1151] = [["a Honey Bun", "%APPlayer%%APItem%"]],
                    [1152] =
                    [
                        ["JUMP_TO,HACHI_SAD,IF_FALSE|ITEM_CAN_ADD,205,1;", ""],
                        ["ITEM_add,205,1", "FILE_MARK_AP,HONEY_SHOP_BUN|recycle,shop_1"]
                    ],
                },
                GISIdentifier = "HONEY_SHOP_BUN",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_1;floating;use_all_bright;speech=HONEY_BUN;spacing=right,0.1",
            },
            new Check
            {
                ArchipelagoId = 7676107,
                HintWhenLoaded = true,
                ObjectIds = ["58"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1140] = [["Honey Brew", "%APPlayer%%APItem%"]],
                    [1147] = [["Honey Brew", "%APPlayer%%APItem%"]],
                    [1148] = [["a Honey Brew", "%APPlayer%%APItem%"]],
                    [1149] =
                    [
                        ["JUMP_TO,HACHI_SAD,IF_FALSE|ITEM_CAN_ADD,54,1;", ""],
                        ["ITEM_add,54,1", "FILE_MARK_AP,HONEY_SHOP_BREW|recycle,shop_2"]
                    ],
                },
                GISIdentifier = "HONEY_SHOP_BREW",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_2;floating;use_all_bright;speech=HONEY_BREW;spacing=right,0.1",
            },
            new Check
            {
                ArchipelagoId = 7676108,
                HintWhenLoaded = true,
                ObjectIds = ["64"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1153] = [["honey drops", "%APPlayer%%APItem%"]],
                    [1154] = [["a pack of 3 Honey Drops", "%APPlayer%%APItem%"]],
                    [1155] =
                    [
                        ["JUMP_TO,HACHI_SAD,IF_FALSE|ITEM_CAN_ADD,89,3;", ""],
                        ["ITEM_add,89,3", "FILE_MARK_AP,HONEY_SHOP_DROP|recycle,shop_3"]
                    ],
                },
                GISIdentifier = "HONEY_SHOP_DROP",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_3;floating;use_all_bright;speech=HONEY_DROP;spacing=right,0.1",
            },
            new Check
            {
                ArchipelagoId = 7676109,
                ObjectIds = ["73"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_SUN_1",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_SUN_1;ql=SI_FALSE,REGEN_SUN_1",
            },
        },
        ["p1_sunflower_road_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676110,
                ObjectIds = ["9"],
                IsKeyItem = false,
                GISIdentifier = "SFR_07",
                OverrideType =
                    "angle=270;gravity=0;id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_07;ql=POC_ABSENT,SFR_07",
            },
            new Check
            {
                ArchipelagoId = 7676111,
                ObjectIds = ["22"],
                IsKeyItem = false,
                GISIdentifier = "SFR_09",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_09;ql=POC_ABSENT,SFR_09",
            },
            new Check
            {
                ArchipelagoId = 7676112,
                ObjectIds = ["8"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_FLOWER_2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,MOON_FLOWER_2,true;ql=SI_FALSE,MOON_FLOWER_2",
            },
            new Check
            {
                ArchipelagoId = 7676113,
                ObjectIds = ["10"],
                IsKeyItem = false,
                GISIdentifier = "SFR_08",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_08;ql=POC_ABSENT,SFR_08",
            },
            new Check
            {
                ArchipelagoId = 7676114,
                ObjectIds = ["11"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_FLOWER_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_FLOWER_1,true;ql=SI_FALSE,OXY_FLOWER_1",
            },
            new Check
            {
                ArchipelagoId = 7676115,
                ObjectIds = ["20"],
                IsKeyItem = true,
                GISIdentifier = "FLOWER_MONEY_2",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$FLOWER_MONEY_2;ql=SI_FALSE,FLOWER_MONEY_2",
            },
            new Check
            {
                ArchipelagoId = 7676116,
                ObjectIds = ["41"],
                IsKeyItem = false,
                GISIdentifier = "SFR_11",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_11;ql=POC_ABSENT,SFR_11;angle=90;gravity=0",
            },
            new Check
            {
                ArchipelagoId = 7676131,
                ObjectIds = ["23"],
                IsKeyItem = false,
                GISIdentifier = "SFR_10",
                OverrideType =
                    "angle=270;gravity=0;id=%ItemId%;collected_GIS=FILE_MARK_POC,SFR_10;ql=POC_ABSENT,SFR_10",
            },
        },
        ["p1_ex_cave_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676117,
                ObjectIds = ["127"],
                IsKeyItem = true,
                GISIdentifier = "PANSELO_MONEY_3",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$PANSELO_MONEY_3;ql=SI_FALSE,PANSELO_MONEY_3",
            },
        },
        ["p1_ex_cave_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676118,
                ObjectIds = ["191"],
                IsKeyItem = true,
                GISIdentifier = "AP_TURTLE",
                OverrideType =
                    "type=fish;instruction=TURTLE;name=turtle;defeated_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_TURTLE,pos$name(gale)|particle_emitter,highlighter,stop",
            },
        },
        ["p1_ex_coast_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676132,
                ObjectIds = ["301"],
                IsKeyItem = true,
                GISIdentifier = "PERRO_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,PERRO_1,true;ql=AP_SETTING_TRUE,PERRO&SI_FALSE,PERRO_1",
            },
        },
        ["p1_bridge_atelo_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676119,
                ObjectIds = ["66"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_BRIDGE_LOOT_1",
                OverrideType =
                    "type=P1_WOOD_S;ql=SI_FALSE,REGEN_BRIDGE_LOOT_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_BRIDGE_LOOT_1",
            },
        },
        ["p1_bridge_atelo_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676120,
                ObjectIds = ["19"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATELO_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,MOON_ATELO_1,true;ql=SI_FALSE,MOON_ATELO_1",
            },
            new Check
            {
                ArchipelagoId = 7676121,
                ObjectIds = ["22"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_ATELO_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_ATELO_1,true;ql=SI_FALSE,HEART_ATELO_1",
            },
        },
        ["p1_bridge_atelo_02b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676191,
                ObjectIds = ["23"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATELO_3",
                OverrideType =
                    "name=SHINY_LOOT;type=P1_TOWER_POT_S;ql=SI_FALSE,MOON_ATELO_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ATELO_3",
            },
        },
        ["p1_bridge_atelo_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676122,
                ObjectIds = ["138"],
                IsKeyItem = true,
                GISIdentifier = "AP_ATELO_LIZARD_1",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ATELO_LIZARD_1;instruction=tmx(21/15.5),tmx(27/19),tmx(22.875/16)",
            },
            new Check
            {
                ArchipelagoId = 7676123,
                ObjectIds = ["137"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_BRIDGE_LOOT_2",
                OverrideType =
                    "type=P1_WOOD_S;ql=SI_FALSE,REGEN_BRIDGE_LOOT_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_BRIDGE_LOOT_2",
            },
            new Check
            {
                ArchipelagoId = 7676124,
                ObjectIds = ["136"],
                IsKeyItem = true,
                GISIdentifier = "ATELO_MONEY_2",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATELO_MONEY_2;ql=SI_FALSE,ATELO_MONEY_2",
            },
        },
        ["p1_ex_geo_02c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676125,
                ObjectIds = ["208"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3864] = [["Here's your ticket", "Here's %APPlayer/your %%APItem%"], ["|ITEM_add,140,1", ""]],
                },
                GISIdentifier = "GEO_TICKET_2",
                OverrideType =
                    "name=geo_bot;voice=robot,1;profile=green_robot;behavior=stand;speech=GEO_ROBOT_02;sort=fg_tiles,1",
            },
        },
        ["p1_bridge_atelo_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676126,
                ObjectIds = ["25"],
                IsKeyItem = true,
                GISIdentifier = "ATELO_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATELO_MONEY_1;ql=SI_FALSE,ATELO_MONEY_1",
            },
            new Check
            {
                ArchipelagoId = 7676127,
                ObjectIds = ["16"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATELO_2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,MOON_ATELO_2,true;ql=SI_FALSE,MOON_ATELO_2",
            },
            new Check
            {
                ArchipelagoId = 7676128,
                ObjectIds = ["27"],
                IsKeyItem = false,
                GISIdentifier = "ATELO_TEMP_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_OC$ATELO_TEMP_1;ql=OC_ABSENT,ATELO_TEMP_1",
            },
            new Check
            {
                ArchipelagoId = 7676129,
                ObjectIds = ["28"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_ATELO_1",
                OverrideType =
                    "name=SHINY_LOOT;id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_ATELO_1,true;ql=SI_FALSE,OXY_ATELO_1",
            },
        },
        ["p1_bridge_atelo_03a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676130,
                ObjectIds = ["125"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATELO_4",
                OverrideType =
                    "name=moon_pot;type=P1_BANDIT_POT_S;ql=SI_FALSE,MOON_ATELO_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ATELO_4|particle_emitter,highlighter,stop",
            },
        },
        ["p1_atai_tower_right"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676200,
                ObjectIds = ["43"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATAI_2",
                OverrideType =
                    "type=P1_ATAI_CERAMIC_POT_S;ql=SI_FALSE,MOON_ATAI_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ATAI_2",
            },
            new Check
            {
                ArchipelagoId = 7676201,
                ObjectIds = ["48"],
                IsKeyItem = true,
                GISIdentifier = "ATAI_MONEY_4",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATAI_MONEY_4;ql=SI_FALSE,ATAI_MONEY_4",
            },
        },
        ["p1_atai_prison"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676202,
                ObjectIds = ["133"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATAI_9",
                OverrideType =
                    "name=SHINY_LOOT;type=P1_ATAI_CERAMIC_POT_S;ql=SI_FALSE,MOON_ATAI_9;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ATAI_9",
            },
            new Check
            {
                ArchipelagoId = 7676203,
                ObjectIds = ["127"],
                IsKeyItem = true,
                GISIdentifier = "ATAI_MONEY_6",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATAI_MONEY_6;ql=SI_FALSE,ATAI_MONEY_6",
            },
            new Check
            {
                ArchipelagoId = 7676199,
                ObjectIds = ["244"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1627] = [["GO,OCARINA_GET", "GO,1628"], ["ITEM_add,29,1", "FILE_MARK_SI,CH2_D4_GOT_OCARINA,true"]],
                },
                GISIdentifier = "CH2_D4_GOT_OCARINA",
                OverrideType =
                    "name=ouro_prince;voice=man,1;profile=bandit_prince;speech=OURO_PRINCE;behavior=stand;face_right;sort=bg_tiles,12;spacing=right,0.2;long_talker;ql=SI_FALSE,BIRDY_CAUGHT",
            },
            new Check
            {
                ArchipelagoId = 7676198,
                ObjectIds = ["241"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                GISIdentifier = "AP_OUROBOROS_SONG",
                OverrideType =
                    "remove;name=song_field;can_learn=0;desired_song=0;GIS=GIS_PACK,3|common_sfx,150|override_npc_idle_anim,ouro_prince,bandit_prince_idle|FILE_MARK_AP,AP_OUROBOROS_SONG,true",
            },
        },
        ["p1_atai_hidden_room"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676204,
                ObjectIds = ["27"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_ATAI_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_ATAI_1,true;ql=SI_FALSE,HEART_ATAI_1",
            },
        },
        ["p1_atai_city_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676205,
                HintWhenLoaded = true,
                ObjectIds = ["291"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1494] = [["vala beans", "%APPlayer%%APItem%"]],
                    [1495] = [["a handful of 3 Vala Beans", "%APPlayer%%APItem%"]],
                    [1496] =
                    [
                        ["JUMP_TO,MERCHANT_ATAIVEG_NOSPACE,IF_FALSE|ITEM_CAN_ADD,178,3;", ""],
                        ["ITEM_add,178,3", "FILE_MARK_AP,ATAI_MARKET_BEAN|recycle,shop_1"]
                    ],
                },
                GISIdentifier = "ATAI_MARKET_BEAN",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_1;speech=MERCHANT_VALA;face_right;floating;spacing=left,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676206,
                HintWhenLoaded = true,
                ObjectIds = ["342"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1497] = [["desert squash", "%APPlayer%%APItem%"]],
                    [1498] = [["a desert squash", "%APPlayer%%APItem%"]],
                    [1499] =
                    [
                        ["JUMP_TO,MERCHANT_ATAIVEG_NOSPACE,IF_FALSE|ITEM_CAN_ADD,180,1;", ""],
                        ["ITEM_add,180,1", "FILE_MARK_AP,ATAI_MARKET_SQUASH|recycle,shop_2"]
                    ],
                },
                GISIdentifier = "ATAI_MARKET_SQUASH",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_2;speech=MERCHANT_SQUASH;floating;spacing=left,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676207,
                HintWhenLoaded = true,
                ObjectIds = ["290"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1500] = [["moon kelp", "%APPlayer%%APItem%"]],
                    [1501] = [["a bushel of 3 Moon Kelp", "%APPlayer%%APItem%"]],
                    [1502] =
                    [
                        ["JUMP_TO,MERCHANT_ATAIVEG_NOSPACE,IF_FALSE|ITEM_CAN_ADD,104,3;", ""],
                        ["ITEM_add,104,3", "FILE_MARK_AP,ATAI_MARKET_KELP|recycle,shop_3"]
                    ],
                },
                GISIdentifier = "ATAI_MARKET_KELP",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_3;speech=MERCHANT_KELP;floating;spacing=left,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676208,
                HintWhenLoaded = true,
                ObjectIds = ["288"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1479] = [["Big raw meat", "%APPlayer%%APItem%"]],
                    [1480] = [["Big Raw Meat", "%APPlayer%%APItem%"]],
                    [1481] =
                    [
                        ["JUMP_TO,MERC_MEAT_NOSPACE,IF_FALSE|ITEM_CAN_ADD,74,1;", ""],
                        ["ITEM_add,74,1", "FILE_MARK_AP,ATAI_MARKET_BOAR_MEAT|recycle,shop_4"]
                    ],
                },
                GISIdentifier = "ATAI_MARKET_BOAR_MEAT",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_4;speech=MERC_MEAT_BOAR;voice=man,0.95;floating;spacing=right,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676209,
                HintWhenLoaded = true,
                ObjectIds = ["124"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1476] = [["drake tail", "%APPlayer%%APItem%"]],
                    [1477] = [["a Drake Tail", "%APPlayer%%APItem%"]],
                    [1478] =
                    [
                        ["JUMP_TO,MERC_MEAT_NOSPACE,IF_FALSE|ITEM_CAN_ADD,66,1;", ""],
                        ["ITEM_add,66,1", "FILE_MARK_AP,ATAI_MARKET_DRAKE_MEAT|recycle,shop_5"]
                    ],
                },
                GISIdentifier = "ATAI_MARKET_DRAKE_MEAT",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_5;speech=MERC_MEAT_DRAKE;voice=man,0.95;floating;spacing=right,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676210,
                HintWhenLoaded = true,
                ObjectIds = ["289"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1482] = [["Prime fish fillet", "%APPlayer%%APItem%"]],
                    [1483] = [["Prime Fish Fillet", "%APPlayer%%APItem%"]],
                    [1484] =
                    [
                        ["JUMP_TO,MERC_MEAT_NOSPACE,IF_FALSE|ITEM_CAN_ADD,81,1;", ""],
                        ["ITEM_add,81,1", "FILE_MARK_AP,ATAI_MARKET_FISH_MEAT|recycle,shop_6"]
                    ],
                },
                GISIdentifier = "ATAI_MARKET_FISH_MEAT",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_6;speech=MERC_MEAT_FISH;voice=man,0.95;floating;spacing=right,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676222,
                HintWhenLoaded = true,
                ObjectIds = ["300"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1438] = [["prickle fruit", "%APPlayer%%APItem%"]],
                    [1439] = [["Prickle Fruit", "%APPlayer%%APItem%"]],
                    [1440] =
                    [
                        ["JUMP_TO,FRUIT_LADY_FAIL+2,IF_FALSE|ITEM_CAN_ADD,106,1;", ""],
                        ["ITEM_add,106,1", "FILE_MARK_AP,ATAI_MARKET_PRICKLE|recycle,shop_7"]
                    ],
                },
                GISIdentifier = "ATAI_MARKET_PRICKLE",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_7;speech=BUY_PRICKLE;spacing=left,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676223,
                HintWhenLoaded = true,
                ObjectIds = ["301"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1442] = [["berry fruit", "%APPlayer%%APItem%"]],
                    [1445] = [["Berry Fruit", "%APPlayer%%APItem%"]],
                    [1446] =
                    [
                        ["JUMP_TO,FRUIT_LADY_FAIL+2,IF_FALSE|ITEM_CAN_ADD,50,1;", ""],
                        ["ITEM_add,50,1", "FILE_MARK_AP,ATAI_MARKET_BERRY|recycle,shop_8"]
                    ],
                },
                GISIdentifier = "ATAI_MARKET_BERRY",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_8;speech=BUY_BERRY;sort=game_objects,41;spacing=right,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676224,
                ObjectIds = ["38"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1419] = [["||||", ";GIS,AP_HINT,%APId%||||"], ["25 RIN", "<#00ffff>%APPlayer%%APItem%</color>"]],
                    [1429] = [["How many are you looking to sell?", "For the first 4 I'll give you <#00ffff>%APPlayer%%APItem%</color>"]],
                    [1430] = [[",1432,1433", ""], ["25 R||Sell 8 Berry Fruits for 50 R||Sell 12 Berry Fruits for 75 R", "%APPlayer%%APItem%"]],
                    [1431] = [["money_adjust,P1_RAI,25", "FILE_MARK_AP,ATAI_MARKET_BERRY_SELL"]],
                },
                GISIdentifier = "ATAI_MARKET_BERRY_SELL",
                OverrideType =
                    "name=atai_doki;voice=woman,1;profile=atai_doki;speech=ATAI_DOKI;behavior=stand;long_talker;face_right",
            },
            new Check
            {
                ArchipelagoId = 7676219,
                ObjectIds = ["303"],
                IsKeyItem = true,
                GISIdentifier = "ATAI_MONEY_2",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATAI_MONEY_2;ql=SI_FALSE,ATAI_MONEY_2",
            },
            new Check
            {
                ArchipelagoId = 7676228,
                ObjectIds = ["9-won race"],
                IsKeyItem = true,
                GISIdentifier = "BO_QUEST_1",
                OverrideType =
                    "FILE_MARK_SI,BO_QUEST_1,true|FILE_MARK_OC,bo_temp",
            },
        },
        ["p1_atai_shop"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676211,
                HintWhenLoaded = true,
                ObjectIds = ["18"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                CompletionDialogId = 64,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1510] = [["JUMP_TO,ARMOR2_GET+-1,IF_TRUE|ITEM_HAVE,int_list(11);", ""], ["sky vest", "%APPlayer%%APItem%"]],
                    [1511] = [["a Sky Vest", "%APPlayer%%APItem%"]],
                    [1512] = [["ITEM_add,11,1;GO,ARMOR2_GET", "FILE_MARK_AP,ATAI_SHOP_ARMOR|recycle,shop_1"]],
                },
                GISIdentifier = "ATAI_SHOP_ARMOR",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_1;speech=GEN_MERCHANT_ARMOR;voice=man,0.95;spacing=stand;shiny",
            },
            new Check
            {
                ArchipelagoId = 7676212,
                HintWhenLoaded = true,
                ObjectIds = ["15"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                CompletionDialogId = 127,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1513] = [["JUMP_TO,CROSSBOW_GET+-1,IF_TRUE|ITEM_HAVE_COUNT,37,1;", ""], ["civilian crossbow", "%APPlayer%%APItem%"]],
                    [1514] = [["a Civilian Crossbow", "%APPlayer%%APItem%"]],
                    [1515] = [["ITEM_add,37,1;GO,CROSSBOW_GET", "FILE_MARK_AP,ATAI_SHOP_CROSSBOW|recycle,shop_2"]],
                },
                GISIdentifier = "ATAI_SHOP_CROSSBOW",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_2;speech=GEN_MERCHANT_CROSSBOW;voice=man,0.95;spacing=stand;shiny",
            },
            new Check
            {
                ArchipelagoId = 7676213,
                HintWhenLoaded = true,
                ObjectIds = ["58"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                CompletionDialogId = 50,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1519] = [["JUMP_TO,BAT2_GET+-1,IF_TRUE|ITEM_HAVE,int_list(7);", ""], ["composite bat", "%APPlayer%%APItem%"]],
                    [1520] = [["a Composite Bat", "%APPlayer%%APItem%"]],
                    [1521] = [["ITEM_add,7,1;GO,BAT2_GET", "FILE_MARK_AP,ATAI_SHOP_BAT2|recycle,shop_3"]],
                },
                GISIdentifier = "ATAI_SHOP_BAT2",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_3;speech=GEN_MERCHANT_BAT2;voice=man,0.95;spacing=stand;shiny",
            },
            new Check
            {
                ArchipelagoId = 7676214,
                HintWhenLoaded = true,
                ObjectIds = ["60"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                CompletionDialogId = 97,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1516] = [["JUMP_TO,LAMP_GET+-1,IF_TRUE|ITEM_HAVE_COUNT,32,1;", ""], ["crank lamp", "%APPlayer%%APItem%"]],
                    [1517] = [["a Crank Lamp", "%APPlayer%%APItem%"]],
                    [1518] = [["ITEM_add,32,1;GO,LAMP_GET", "FILE_MARK_AP,ATAI_SHOP_LAMP|recycle,shop_4"]],
                },
                GISIdentifier = "ATAI_SHOP_LAMP",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_4;speech=GEN_MERCHANT_LAMP;voice=man,0.95;spacing=stand;shiny",
            },
            new Check
            {
                ArchipelagoId = 7676215,
                HintWhenLoaded = true,
                ObjectIds = ["61"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                CompletionDialogId = 113,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1522] = [["JUMP_TO,FISHPOLE_GET+-1,IF_TRUE|ITEM_HAVE_COUNT,40,1;", ""], ["fishing rod", "%APPlayer%%APItem%"]],
                    [1523] = [["a fishing rod", "%APPlayer%%APItem%"]],
                    [1524] = [["ITEM_add,40,1;GO,FISHPOLE_GET", "FILE_MARK_AP,ATAI_SHOP_POLE|recycle,shop_5"]],
                },
                GISIdentifier = "ATAI_SHOP_POLE",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_5;speech=GEN_MERCHANT_POLE;voice=man,0.95;spacing=stand;shiny",
            },
            new Check
            {
                ArchipelagoId = 7676216,
                ObjectIds = ["51"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_ATAI_2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_ATAI_2,true;ql=SI_FALSE,HEART_ATAI_2;sort=fg_tiles,5",
            },
        },
        ["p1_atai_hidden_room2a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676217,
                ObjectIds = ["128"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATAI_6",
                OverrideType =
                    "name=SHINY_LOOT;type=P1_ATAI_CERAMIC_POT_S;ql=SI_FALSE,MOON_ATAI_6;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ATAI_6",
            },
            new Check
            {
                ArchipelagoId = 7676218,
                ObjectIds = ["127"],
                IsKeyItem = true,
                GISIdentifier = "ATAI_MAZE_MONEY",
                OverrideType =
                    "name=SHINY_LOOT_2;type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATAI_MAZE_MONEY;ql=SI_FALSE,ATAI_MAZE_MONEY",
            },
        },
        ["p1_atai_city_01_alley"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676220,
                ObjectIds = ["57"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATAI_5",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,MOON_ATAI_5,true;ql=SI_FALSE,MOON_ATAI_5",
            },
            new Check
            {
                ArchipelagoId = 7676221,
                ObjectIds = ["37"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATAI_4",
                OverrideType =
                    "name=pot;type=P1_ATAI_CERAMIC_POT_S;ql=SI_FALSE,MOON_ATAI_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ATAI_4|particle_emitter,highlighter,stop",
            },
        },
        ["p1_atai_inn_01"] = new List<Check>
        {
            new Check // TODO: dialogue resets for other item after buying one
            {
                ArchipelagoId = 7676225,
                ObjectIds = ["22"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1586] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["A Milk", "%APPlayer%%APItem%"]],
                    [1587] =
                    [
                        ["JUMP_TO,ATAI_BARTENDER+-2,IF_FALSE|ITEM_CAN_ADD,67,1;", ""],
                        ["ITEM_add,67,1", "FILE_MARK_AP,ATAI_BARTENDER_MILK"]
                    ],
                },
                GISIdentifier = "ATAI_BARTENDER_MILK",
                OverrideType =
                    "name=bartender;voice=man,.95;profile=atai_barkeep;speech=ATAI_BARTENDER;behavior=stand;floating;sort=bg_tiles,7;spacing=left,0.5",
            },
            new Check // TODO: dialogue resets for other item after buying one
            {
                ArchipelagoId = 7676226,
                ObjectIds = ["22"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1586] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["A Bottle Of Wine", "%APPlayer%%APItem%"]],
                    [1597] = [["|ITEM_add,123,1", ""]],
                },
                GISIdentifier = "CH2_D3_GOT_WINE",
                OverrideType =
                    "name=bartender;voice=man,.95;profile=atai_barkeep;speech=ATAI_BARTENDER;behavior=stand;floating;sort=bg_tiles,7;spacing=left,0.5",
            },
            new Check
            {
                ArchipelagoId = 7676133,
                ObjectIds = ["43"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1683] = [["GO,GP1", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,BLUE_MERC_GEAR,true"]],
                },
                GISIdentifier = "BLUE_MERC_GEAR",
                OverrideType =
                    "voice=man,0.85;profile=atai_gunner;speech=BLUE_MERC;behavior=stand;spacing=right,0.1;face_right;name=blue_merc;ql=SI_FALSE,BIRDY_CAUGHT",
            },
        },
        ["p1_atai_house_04"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676227,
                ObjectIds = ["114"],
                IsKeyItem = false,
                GISIdentifier = "AP_ATAI_MOUSE_1",
                OverrideType =
                    "name=mouse2;type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ATAI_MOUSE_1;instruction=tmx(23.5/21)",
            },
        },
        ["p1_ex_ouroboros_02d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676229,
                ObjectIds = ["112"],
                IsKeyItem = true,
                GISIdentifier = "OURO_SCROLL_2",
                OverrideType =
                    "id=%ItemId%;use_all_bright;collected_GIS=FILE_MARK_SI,OURO_SCROLL_2,true;ql=SI_FALSE,OURO_SCROLL_2",
            },
        },
        ["p1_atai_station"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676230,
                ObjectIds = ["335"],
                IsKeyItem = true,
                GISIdentifier = "ATAI_MONEY_8",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATAI_MONEY_8;ql=SI_FALSE,ATAI_MONEY_8",
            },
        },
        ["p1_atai_station_ex"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676231,
                ObjectIds = ["193"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATAI_7",
                OverrideType =
                    "type=P1_SCRAP_S;ql=SI_FALSE,MOON_ATAI_7;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ATAI_7",
            },
        },
        ["p1_atai_city_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676298,
                ObjectIds = ["106"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always, // Should get an option to keep item vanilla in the future
                IsNpc = true,
                CompletionDialogId = 1918,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1912] = [["JUMP_TO,LISA_ID_DONE,IF_TRUE|SI_TRUE,CH2_D3_GOT_WINE;JUMP_TO,LISA_ID_REMINDER,IF_TRUE|ITEM_HAVE,int_list(122);", ""]],
                    [1915] = [["ITEM_add,122,1", "FILE_MARK_AP,LISA_ID"]],
                    [1917] = [["ITEM_add,122,1", "FILE_MARK_AP,LISA_ID"]],
                },
                GISIdentifier = "LISA_ID",
                OverrideType =
                    "name=lisa;profile=lisa;voice=woman,1.1;speech=MEETING_LISA;behavior=stand;sort=fg_tiles,-1;ql=SI_TRUE,CH_2_A_MET_LISA&SI_FALSE,BIRDY_CAUGHT",
            },
        },
        ["p1_atai_mansion_kitchen"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676232,
                ObjectIds = ["38"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2664] = [["&ITEM_CAN_ADD,84,1", ""]],
                    [2665] = [["GO,GP1", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,ATAI_LOOT_1,true"]],
                },
                GISIdentifier = "ATAI_LOOT_1",
                OverrideType =
                    "name=cooker;profile=atai_cook;face_right;voice=woman,1;speech=ATAI_NPC_23;behavior=action_only;spacing=auto,0.1;override_action=atai_cook_idle",
            },
        },
        ["p1_atai_mansion_storage"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676233,
                ObjectIds = ["10"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATAI_1",
                OverrideType =
                    "name=SHINY_LOOT;type=P1_ATAI_CERAMIC_POT_S;ql=SI_FALSE,MOON_ATAI_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ATAI_1|particle_emitter,highlighter,stop",
            },
            new Check
            {
                ArchipelagoId = 7676234,
                ObjectIds = ["11"],
                IsKeyItem = true,
                GISIdentifier = "ATAI_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATAI_MONEY_1;ql=SI_FALSE,ATAI_MONEY_1",
            },
        },
        ["p1_atai_mansion_security"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676235,
                ObjectIds = ["70"],
                IsKeyItem = false,
                GISIdentifier = "AP_ATAI_LIZARD_1",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ATAI_LIZARD_1;instruction=tmx(8/16),tmx(14/18),tmx(7.875/16);sort=bg_tiles,6",
            },
        },
        ["p1_atai_well_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676237,
                ObjectIds = ["89"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_WELL_LOOT_1",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_WELL_LOOT_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_WELL_LOOT_1",
            },
        },
        ["p1_atai_well_03a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676236,
                ObjectIds = ["101"],
                IsKeyItem = true,
                GISIdentifier = "ATAI_MONEY_5",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATAI_MONEY_5;ql=SI_FALSE,ATAI_MONEY_5",
            },
        },
        ["p1_atai_city_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676238,
                ObjectIds = ["79"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ATAI_3",
                OverrideType =
                    "name=moon_pot;type=P1_ATAI_CERAMIC_POT_S;ql=SI_FALSE,MOON_ATAI_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ATAI_3|particle_emitter,highlighter,stop",
            },
        },
        ["p1_atai_shooting_gallery"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676239,
                HintWhenLoaded = true,
                ObjectIds = ["140"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2171] = [["GO,GP8", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_AP,ATAI_ARCHERY_1|AT_scale,duck,vec3(0/0/0),duration$0.25"]],
                },
                GISIdentifier = "ATAI_ARCHERY_1",
                OverrideType =
                    "CustomAnimatedSprite;name=duck;loot=%ItemId%;sort=game_objects,14;color=ffffff",
            },
            new Check
            {
                ArchipelagoId = 7676240,
                HintWhenLoaded = true,
                ObjectIds = ["142"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2173] = [["GO,GP9", "GO,2174"]],
                    [2174] = [["ITEM_add,3,1|", ""]],
                },
                GISIdentifier = "HEART_ATAI_3",
                OverrideType =
                    "CustomAnimatedSprite;name=heart;loot=%ItemId%;sort=game_objects,14;color=ffffff;ql=SI_FALSE,HEART_ATAI_3",
            },
            new Check
            {
                ArchipelagoId = 7676241,
                HintWhenLoaded = true,
                ObjectIds = ["143"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2176] = [["GO,GP10", "GO,2177"]],
                    [2177] = [["ITEM_add,5,1|", ""]],
                },
                GISIdentifier = "MOON_ATAI_8",
                OverrideType =
                    "CustomAnimatedSprite;name=moon;loot=%ItemId%;sort=game_objects,14;color=ffffff;ql=SI_FALSE,MOON_ATAI_8",
            },
        },
        ["p1_atai_house_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676242,
                ObjectIds = ["87"],
                IsKeyItem = true,
                GISIdentifier = "ATAI_MONEY_7",
                OverrideType =
                    "type=P1_WOOD_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATAI_MONEY_7;ql=SI_FALSE,ATAI_MONEY_7",
            },
        },
        ["p1_atai_border_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676245,
                HintWhenLoaded = true,
                ObjectIds = ["328"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2690] = [["GO,GP1", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,MOON_RHODUS_1,true"]],
                },
                GISIdentifier = "MOON_RHODUS_1",
                OverrideType =
                    "profile=soldierf;voice=woman,0.95;speech=loop,BORDER_GUARD_MOON,BORDER_GUARD_MOON+1,BORDER_GUARD_MOON+2,BORDER_GUARD_MOON+3;behavior=stand;floating;spacing=stand;talk_range=0.3",
            },
            new Check
            {
                ArchipelagoId = 7676246,
                HintWhenLoaded = true,
                ObjectIds = ["453"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2807] = [["Honey Brew", "%APPlayer%%APItem%"]],
                    [2808] = [["Honey Brew", "%APPlayer%%APItem%"]],
                    [2809] =
                    [
                        ["JUMP_TO,ATAI_TRADER,IF_FALSE|ITEM_CAN_ADD,54,1;", ""],
                        ["ITEM_add,54,1", "FILE_MARK_AP,ATAI_BORDER_BREW|recycle,shop_1"]
                    ],
                },
                GISIdentifier = "ATAI_BORDER_BREW",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_1;speech=ATAI_BREW;voice=man,1;sort=game_objects,41;spacing=left,0.1",
            },
            new Check
            {
                ArchipelagoId = 7676247,
                HintWhenLoaded = true,
                ObjectIds = ["449"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2804] = [["chocolate", "%APPlayer%%APItem%"]],
                    [2805] = [["a box of 3 Chocolates", "%APPlayer%%APItem%"]],
                    [2806] =
                    [
                        ["JUMP_TO,ATAI_TRADER,IF_FALSE|ITEM_CAN_ADD,68,3;", ""],
                        ["ITEM_add,68,3", "FILE_MARK_AP,ATAI_BORDER_CHOCOLATE|recycle,shop_2"]
                    ],
                },
                GISIdentifier = "ATAI_BORDER_CHOCOLATE",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_2;speech=ATAI_CHOCOLATE;voice=man,1;sort=game_objects,41;spacing=left,0.1",
            },
            new Check
            {
                ArchipelagoId = 7676248,
                HintWhenLoaded = true,
                ObjectIds = ["439"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2775] = [["rubber ducky", "%APPlayer%%APItem%"]],
                    [2776] = [["a Rubber Ducky", "%APPlayer%%APItem%"]],
                    [2777] =
                    [
                        ["JUMP_TO,SHADE_MERCH+-2,IF_FALSE|ITEM_CAN_ADD,109,1;", ""],
                        ["ITEM_add,109,1", "FILE_MARK_AP,ATAI_BORDER_DUCK|recycle,shop_3"]
                    ],
                },
                GISIdentifier = "ATAI_BORDER_DUCK",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_3;speech=SHADE_DUCK;spacing=left,0.1;face_right",
            },
            new Check
            {
                ArchipelagoId = 7676249,
                HintWhenLoaded = true,
                ObjectIds = ["440"],
                IsKeyItem = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2778] =
                    [
                        ["JUMP_TO,LAMP_GET+-1,IF_TRUE|ITEM_HAVE,int_list(39);", ""],
                        ["refurbished crank lamp", "%APPlayer%%APItem%"]
                    ],
                    [2779] = [["a Refurbished Crank Lamp", "%APPlayer%%APItem%"]],
                    [2781] = [["a Refurbished Crank Lamp", "%APPlayer%%APItem%"]],
                    [2784] = [["a Refurbished Crank Lamp", "%APPlayer%%APItem%"]],
                    [2786] = [["refurbished crank lamp", "%APPlayer%%APItem%"]],
                    [2788] = [["a Refurbished Crank Lamp", "%APPlayer%%APItem%"]],
                    [2790] = [["refurbished crank lamp", "%APPlayer%%APItem%"]],
                    [2791] = [["a Refurbished Crank Lamp", "%APPlayer%%APItem%"]],
                    [2793] = [["ITEM_add,39,1;GO,LAMP2_GET", "FILE_MARK_AP,ATAI_BORDER_LAMP|recycle,shop_4"]],
                    [2794] = [["ITEM_add,39,1;GO,LAMP2_GET", "FILE_MARK_AP,ATAI_BORDER_LAMP|recycle,shop_4"]],
                    [2795] = [["ITEM_add,39,1;GO,LAMP2_GET", "FILE_MARK_AP,ATAI_BORDER_LAMP|recycle,shop_4"]],
                    [2796] = [["ITEM_add,39,1", "FILE_MARK_AP,ATAI_BORDER_LAMP|recycle,shop_4"]],
                    [2797] = [["GO,LAMP2_GET", ""]],
                },
                GISIdentifier = "ATAI_BORDER_LAMP",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_4;speech=SHADE_LAMP;spacing=left,0.1;face_right",
            },
            new Check
            {
                ArchipelagoId = 7676250,
                HintWhenLoaded = true,
                ObjectIds = ["432"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2767] = [["saffron milk", "%APPlayer%%APItem%"]],
                    [2768] = [["Saffron Milk", "%APPlayer%%APItem%"]],
                    [2769] =
                    [
                        ["JUMP_TO,RHO_MERCH+-2,IF_FALSE|ITEM_CAN_ADD,177,1;", ""],
                        ["ITEM_add,177,1", "FILE_MARK_AP,ATAI_BORDER_MILK|recycle,shop_5"]
                    ],
                },
                GISIdentifier = "ATAI_BORDER_MILK",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_5;speech=RHO_MILK;sort=game_objects,41;spacing=left,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676251,
                HintWhenLoaded = true,
                ObjectIds = ["430"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2764] = [["curry bento", "%APPlayer%%APItem%"]],
                    [2765] = [["Curry Bento", "%APPlayer%%APItem%"]],
                    [2766] =
                    [
                        ["JUMP_TO,RHO_MERCH+-2,IF_FALSE|ITEM_CAN_ADD,61,1;", ""],
                        ["ITEM_add,61,1", "FILE_MARK_AP,ATAI_BORDER_CURRY|recycle,shop_6"]
                    ],
                },
                GISIdentifier = "ATAI_BORDER_CURRY",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_6;speech=RHO_CURRY;sort=game_objects,41;spacing=left,0.2",
            },
            new Check
            {
                ArchipelagoId = 7676252,
                ObjectIds = ["388"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2820] = [["GO,GP3", "GO,%BonusLine%"], ["JUMP_TO,2821,IF_FALSE|ITEM_CAN_ADD,101,1;", ""]],
                    [-1] = [["GIS,FILE_MARK_OC,bbot_gift"]],
                },
                GISIdentifier = "bbot_gift",
                OverrideType =
                    "profile=robot;voice=robot,1;speech=B_BOT_1,B_BOT_1+2;behavior=path,52,45;spacing=auto,0.1",
            },
            new Check
            {
                ArchipelagoId = 7676253,
                ObjectIds = ["331"],
                IsKeyItem = true,
                IsNpc = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2696] = [["GO,GP2", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,MOON_RHODUS_2,true"]],
                },
                GISIdentifier = "MOON_RHODUS_2",
                OverrideType =
                    "name=rhodus_guard;voice=man,0.95;profile=rhodosm;speech=RHODUS_GUARD_2;behavior=stand;face_right;spacing=right,1",
            },
        },
        ["p1_atai_border_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676243,
                ObjectIds = ["361"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_ATAI_LOOT_1",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_ATAI_LOOT_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_ATAI_LOOT_1",
            },
            new Check
            {
                ArchipelagoId = 7676244,
                ObjectIds = ["372"],
                IsKeyItem = false,
                GISIdentifier = "AP_ATAI_LIZARD_2",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ATAI_LIZARD_2;instruction=tmx(11/3),tmx(20/5),tmx(11/3.5)",
            },
        },
        ["p1_adars_house_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676254,
                ObjectIds = ["320"],
                IsKeyItem = false,
                GISIdentifier = "AP_ATAI_SCORPION_1",
                OverrideType =
                    "type=p_scorp;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ATAI_SCORPION_1;instruction=tmx(30.5/23)",
            },
            new Check
            {
                ArchipelagoId = 7676255,
                ObjectIds = ["266"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_ADAR_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_ADAR_1,true;ql=SI_FALSE,OXY_ADAR_1",
            },
        },
        ["p1_adars_house_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676197,
                ObjectIds = ["292"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                GISIdentifier = "ATAI_BOMBS",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_AP,ATAI_BOMBS",
            },
        },
        ["p1_adars_cave_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676192,
                ObjectIds = ["97"],
                IsKeyItem = true,
                GISIdentifier = "ADAR_TEMP_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_OC$ADAR_TEMP_1;ql=OC_ABSENT,ADAR_TEMP_1",
            },
        },
        ["p1_ex_vault_treasure"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676330,
                ObjectIds = ["213"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_EX_VAULT",
                OverrideType =
                    "name=heart;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_EX_VAULT,true;ql=SI_FALSE,HEART_EX_VAULT;gravity=0;sort=bg_tiles,16",
            },
            new Check
            {
                ArchipelagoId = 7676331,
                ObjectIds = ["217"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_EX_VAULT",
                OverrideType =
                    "name=oxygem;id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_EX_VAULT,true;ql=SI_FALSE,OXY_EX_VAULT;gravity=0;sort=bg_tiles,16",
            },
        },
        ["p1_ex_cave_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676256,
                ObjectIds = ["181"],
                IsKeyItem = true,
                GISIdentifier = "ATAI_MONEY_3",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ATAI_MONEY_3;ql=SI_FALSE,ATAI_MONEY_3",
            },
            new Check
            {
                ArchipelagoId = 7676257,
                ObjectIds = ["182"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_ATAI_6",
                OverrideType =
                    "name=heart_piece;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_ATAI_6,true;ql=SI_FALSE,HEART_ATAI_6",
            },
        },
        ["p1_teleport_atai_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676258,
                ObjectIds = ["301"],
                IsKeyItem = true,
                GISIdentifier = "TELEPORT_ATAI_MONEY",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$TELEPORT_ATAI_MONEY;ql=SI_FALSE,TELEPORT_ATAI_MONEY",
            },
        },
        ["p1_teleport_atai_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676259,
                ObjectIds = ["245"],
                IsKeyItem = true,
                GISIdentifier = "MOON_FISH_2",
                OverrideType =
                    "name=moon_fish;face_right;initial_behavior=STATIC;type=fish;instruction=FISH_S;defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FISH_2|particle_emitter,highlighter,stop;ql=SI_FALSE,MOON_FISH_2",
            },
            new Check
            {
                ArchipelagoId = 7676260,
                ObjectIds = ["268"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_FRUIT_1",
                OverrideType =
                    "id=%ItemId%;gravity=0;angle=0;collected_GIS=FILE_MARK_SI,REGEN_FRUIT_1,true;ql=SI_FALSE,REGEN_FRUIT_1",
            },
        },
        ["p1_bridge_daetai_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676190,
                ObjectIds = ["203"],
                IsKeyItem = true,
                GISIdentifier = "DAETAI_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$DAETAI_MONEY_1;ql=SI_FALSE,DAETAI_MONEY_1",
            },
            new Check
            {
                ArchipelagoId = 7676186,
                ObjectIds = ["188"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_FISH_1",
                OverrideType =
                    "name=moon_fish;face_right;initial_behavior=STATIC;type=fish;instruction=FISH_S;defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FISH_1|particle_emitter,highlighter,stop;ql=SI_FALSE,MOON_FISH_1",
            },
        },
        ["p1_bridge_daetai_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676189,
                ObjectIds = ["148"],
                IsKeyItem = true,
                GISIdentifier = "DAETAI_MONEY_4",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$DAETAI_MONEY_4;ql=SI_FALSE,DAETAI_MONEY_4",
            },
        },
        ["p1_bridge_daetai_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676185,
                ObjectIds = ["239"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_BRIDGE_LOOT_3",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_BRIDGE_LOOT_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_BRIDGE_LOOT_3",
            },
            new Check
            {
                ArchipelagoId = 7676182,
                ObjectIds = ["14"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_BRIDGE_LOOT_4",
                OverrideType =
                    "type=P1_WIDE_WOOD;ql=SI_FALSE,REGEN_BRIDGE_LOOT_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_BRIDGE_LOOT_4",
            },
            new Check
            {
                ArchipelagoId = 7676184,
                ObjectIds = ["242"],
                IsKeyItem = false,
                GISIdentifier = "AP_DAETAI_MOUSE_1",
                OverrideType =
                    "name=mouse2;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DAETAI_MOUSE_1;type=p_mouse;instruction=tmx(37/30)",
            },
            new Check
            {
                ArchipelagoId = 7676183,
                ObjectIds = ["236"],
                IsKeyItem = true,
                GISIdentifier = "DAETAI_MONEY_3",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$DAETAI_MONEY_3;ql=SI_FALSE,DAETAI_MONEY_3",
            },
            new Check
            {
                ArchipelagoId = 7676180,
                ObjectIds = ["185"],
                IsKeyItem = true,
                GISIdentifier = "DAETAI_MONEY_2",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$DAETAI_MONEY_2;ql=SI_FALSE,DAETAI_MONEY_2",
            },
            new Check
            {
                ArchipelagoId = 7676179,
                ObjectIds = ["189"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_DAETAI_3",
                OverrideType =
                    "name=moon_pot;type=P1_TOWER_POT_L;ql=SI_FALSE,MOON_DAETAI_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_DAETAI_3|particle_emitter,highlighter,stop",
            },
        },
        ["p1_bridge_daetai_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676181,
                ObjectIds = ["214"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_DAETAI_2",
                OverrideType =
                    "name=moon_pot;type=P1_BANDIT_POT_S;ql=SI_FALSE,MOON_DAETAI_2;destroyed_GIS=particle_emitter,highlighter,stop|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_DAETAI_2",
            },
        },
        ["p1_ex_geo_03c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676178,
                ObjectIds = ["224"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3871] = [["Here's your ticket", "Here's %APPlayer/your %%APItem%"], ["|ITEM_add,140,1", ""]],
                },
                GISIdentifier = "GEO_TICKET_3",
                OverrideType =
                    "name=geo_bot;voice=robot,1;profile=green_robot;behavior=stand;speech=GEO_ROBOT_03",
            },
        },
        ["p1_boar_boy"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676261,
                ObjectIds = ["64"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always, // Should get an option to keep item vanilla in the future
                IsNpc = true,
                CompletionDialogId = 1770,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1745] = [["JUMP_TO,BOAR_BOY_3,IF_TRUE|ITEM_HAVE,int_list(15);", ""]],
                    [1759] = [["Angry Boar Charging Tusk Strike", "%APPlayer%%APItem%"], ["Tusk Strike", "%APItem%"]],
                    [1765] = [["GO,1766", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_AP,BOAR_BOY"]],
                },
                GISIdentifier = "BOAR_BOY",
                OverrideType =
                    "name=boar_boy;profile=boar_boy;voice=man,1.1;speech=BOAR_BOY;behavior=stand",
            },
        },
        ["p1_oasis_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676262,
                ObjectIds = ["288"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2306] = [["2307;JUMP_AT_END,GP0,IF_TRUE|ITEM_CAN_ADD,177,1", "%BonusLine%"]],
                    [2312] = [["FIRST_LINE_A+2;JUMP_AT_END,GP0,IF_TRUE|ITEM_CAN_ADD,177,1", "%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,ATAI_LOOT_2,true"]],
                },
                GISIdentifier = "ATAI_LOOT_2",
                OverrideType =
                    "profile=soldierf;voice=woman,1;speech=FIRST_LINE_A,FIRST_LINE_A+4;floating",
            },
            new Check
            {
                ArchipelagoId = 7676263,
                ObjectIds = ["300"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [7362] = [["GO,PLANTO_REWARD+-1", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_AP,AP_PLANTO_1"]],
                },
                GISIdentifier = "AP_PLANTO_1",
                DifferingInGameIdentifier = "PLANTO_1",
                OverrideType =
                    "name=planto;profile=planto;voice=man,0.85;speech=PLANTO_P1;behavior=action_only;ql=SI_FALSE,PLANTO_1;floating;sort=bg_tiles,-1",
            },
            new Check
            {
                ArchipelagoId = 7676193,
                ObjectIds = ["305"],
                IsKeyItem = true,
                GISIdentifier = "OXY_FISH_1",
                OverrideType =
                    "name=moon_fish;face_right;initial_behavior=STATIC;type=fish;instruction=FISH_L;defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$OXY_FISH_1|particle_emitter,fish_highlighter,stop;ql=ALWAYS_TRUE",
            },
        },
        ["p1_ex_ouroboros_03d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676264,
                ObjectIds = ["269"],
                IsKeyItem = true,
                GISIdentifier = "OURO_SCROLL_3",
                OverrideType =
                    "id=%ItemId%;use_all_bright;collected_GIS=FILE_MARK_SI,OURO_SCROLL_3,true;ql=SI_FALSE,OURO_SCROLL_3",
            },
        },
        ["p1_drift_access"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676265,
                ObjectIds = ["258"],
                IsKeyItem = false,
                GISIdentifier = "AP_ATAI_LIZARD_3",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ATAI_LIZARD_3;instruction=tmx(57/19),tmx(62/23),tmx(61.875/19)",
            },
            new Check
            {
                ArchipelagoId = 7676266,
                ObjectIds = ["174"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_ACCESS_1",
                OverrideType =
                    "name=SHINY_ROCK;type=P1_BOULDER_L_BROWN;ql=SI_FALSE,MOON_ACCESS_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ACCESS_1",
            },
        },
        ["p1_ex_tower_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676267,
                ObjectIds = ["144"],
                IsKeyItem = false,
                GISIdentifier = "AP_SAND_DRIFTS_LIZARD_1",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_SAND_DRIFTS_LIZARD_1;instruction=tmx(89/44),tmx(93/48),tmx(91.875/44)",
            },
            new Check
            {
                ArchipelagoId = 7676268,
                ObjectIds = ["110"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_BANDIT_1",
                OverrideType =
                    "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_BANDIT_1,true;ql=SI_FALSE,OXY_BANDIT_1",
            },
            new Check
            {
                ArchipelagoId = 7676269,
                ObjectIds = ["301"],
                IsKeyItem = true,
                GISIdentifier = "PERRO_2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,PERRO_2,true;ql=AP_SETTING_TRUE,PERRO&SI_FALSE,PERRO_2",
            },
            new Check
            {
                ArchipelagoId = 7676270,
                ObjectIds = ["134"],
                IsKeyItem = false,
                GISIdentifier = "AP_CACTUS_FRUIT_1",
                OverrideType =
                    "id=%ItemId%;gravity=0;angle=0;collected_GIS=FILE_MARK_AP,AP_CACTUS_FRUIT_1",
            },
            new Check
            {
                ArchipelagoId = 7676271,
                ObjectIds = ["133"],
                IsKeyItem = false,
                GISIdentifier = "AP_CACTUS_FRUIT_2",
                OverrideType =
                    "id=%ItemId%;gravity=0;angle=-45;collected_GIS=FILE_MARK_AP,AP_CACTUS_FRUIT_2",
            },
        },
        ["p1_ex_ouroboros_01c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676272,
                ObjectIds = ["83"],
                IsKeyItem = true,
                GISIdentifier = "OURO_SCROLL_1",
                OverrideType =
                    "id=%ItemId%;use_all_bright;collected_GIS=FILE_MARK_SI,OURO_SCROLL_1,true;ql=SI_FALSE,OURO_SCROLL_1",
            },
        },
        ["p1_ex_illusory_maze_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676273,
                ObjectIds = ["108"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2835] = [["GO,GP8", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,ANCIENT_PIN_1,true"]],
                },
                GISIdentifier = "ANCIENT_PIN_1",
                OverrideType =
                    "name=rust_torso;face_right;voice=robot,0.75;profile=rust_torso;spacing=right,0.2;behavior=stand;speech=GEO_ILLUZ_2",
            },
        },
        ["p1_ex_illusory_maze_04"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676274,
                ObjectIds = ["35"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_OGEO_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_OGEO_1,true;ql=SI_FALSE,HEART_OGEO_1",
            },
        },
        ["p1_ex_sands_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676275,
                ObjectIds = ["126"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_BANDIT_1",
                OverrideType =
                    "name=loot_box;type=P1_WOOD_L;ql=SI_FALSE,HEART_BANDIT_1;destroyed_GIS=puzzle,id$6,msg$FLIP_ON|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$HEART_BANDIT_1,pos$name(loot_box)+vec3(0/1.5/0),velocity$vec3(0/10/0)|common_sfx,150",
            },
        },
        ["biome_desert_ruins_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676196,
                ObjectIds = ["92"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_MAP_1",
                OverrideType =
                    "ql=SI_FALSE,MOON_MAP_1;name=moon_weed;type=p_tumbleweed;dir=RIGHT;GIS=particle_emitter,weed_highlighter,stop|common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_MAP_1",
            },
        },
        ["p1_sand_city_00_save"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676276,
                ObjectIds = ["144"],
                IsKeyItem = false,
                GISIdentifier = "AP_ATAI_MOUSE_2",
                OverrideType =
                    "name=mouse2;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ATAI_MOUSE_2;type=p_mouse;instruction=tmx(17/24)",
            },
        },
        ["p1_sand_city_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676277,
                ObjectIds = ["21"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_BANDIT_2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_BANDIT_2,true;ql=SI_FALSE,HEART_BANDIT_2",
            },
        },
        ["p1_bandit_lair_10"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676291,
                ObjectIds = ["107"],
                IsKeyItem = false,
                GISIdentifier = "ATAI_METRO_BEANS",
                OverrideType =
                    "type=P1_BANDIT_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$ATAI_METRO_BEANS",
            },
        },
        ["p1_sand_city_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676278,
                ObjectIds = ["137"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_MONEY_0",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_MONEY_0;ql=SI_FALSE,BANDIT_MONEY_0",
            },
        },
        ["p1_sand_city_02a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676279,
                ObjectIds = ["207"],
                IsKeyItem = false,
                GISIdentifier = "sandcity2arin",
                OverrideType =
                    "name=box_s3;type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_OC$sandcity2arin;ql=OC_ABSENT,sandcity2arin",
            },
            new Check
            {
                ArchipelagoId = 7676280,
                ObjectIds = ["218"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_MONEY_8",
                OverrideType =
                    "type=P1_WOOD_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_MONEY_8;ql=SI_FALSE,BANDIT_MONEY_8",
            },
            new Check
            {
                ArchipelagoId = 7676281,
                ObjectIds = ["222"],
                IsKeyItem = false,
                GISIdentifier = "AP_ATAI_SCORPION_2",
                OverrideType =
                    "type=p_scorp;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ATAI_SCORPION_2;instruction=tmx(10/11)",
            },
        },
        ["p1_sand_city_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676282,
                ObjectIds = ["44"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_BANDIT_1",
                OverrideType =
                    "ql=SI_FALSE,MOON_BANDIT_1;profile=WOOD;layers_to_erase=5;shave_extra=1;destroyed_by_bombs;particle_color=da8746;destroyed_GIS=common_sfx,150|SPAWN_loot,%ItemId%,pos$tmx(77/56),loot_GIS_MARK_SI$MOON_BANDIT_1",
            },
        },
        ["p1_ex_ouroboros_04e"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676283,
                ObjectIds = ["192"],
                IsKeyItem = true,
                GISIdentifier = "OURO_SCROLL_4",
                OverrideType =
                    "id=%ItemId%;use_all_bright;collected_GIS=FILE_MARK_SI,OURO_SCROLL_4,true;ql=SI_FALSE,OURO_SCROLL_4",
            },
        },
        ["p1_bandit_lair_01c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676284,
                ObjectIds = ["21"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_MONEY_1;ql=SI_FALSE,BANDIT_MONEY_1",
            },
            new Check
            {
                ArchipelagoId = 7676285,
                ObjectIds = ["20"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_BANDIT_2",
                OverrideType =
                    "id=%ItemId%;name=MOON_STONE;collected_GIS=FILE_MARK_SI,MOON_BANDIT_2,true;ql=SI_FALSE,MOON_BANDIT_2",
            },
            new Check
            {
                ArchipelagoId = 7676286,
                ObjectIds = ["177"],
                IsKeyItem = false,
                GISIdentifier = "AP_BANDIT_LIZARD_1",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_BANDIT_LIZARD_1;instruction=tmx(74/19),tmx(77/23),tmx(73.875/19);sort=bg_tiles,11",
            },
        },
        ["p1_bandit_lair_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676289,
                ObjectIds = ["100"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_MONEY_5",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_MONEY_5|FILE_MARK_OC,p1bl01a_rin;ql=SI_FALSE,BANDIT_MONEY_5",
            },
            new Check
            {
                ArchipelagoId = 7676287,
                ObjectIds = ["5"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_BANDIT_4",
                OverrideType =
                    "type=P1_BANDIT_POT_L;ql=SI_FALSE,MOON_BANDIT_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_BANDIT_4",
            },
            new Check
            {
                ArchipelagoId = 7676288,
                ObjectIds = ["169"],
                IsKeyItem = false,
                GISIdentifier = "AP_BANDIT_MOUSE_1",
                OverrideType =
                    "name=mouse2;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_BANDIT_MOUSE_1;type=p_mouse;instruction=tmx(24/16)",
            },
        },
        ["p1_bandit_lair_01"] = new List<Check>
        {
            new Check // TODO: Spawns both scorpion locations
            {
                ArchipelagoId = 7676290,
                ObjectIds = ["194", "195"],
                IsKeyItem = false,
                GISIdentifier = "AP_BANDIT_SCORPION_1",
                OverrideType =
                    "GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_BANDIT_SCORPION_1;type=p_scorp;instruction=tmx(37/47)",
            },
        },
        ["p1_bandit_lair_01d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676292,
                ObjectIds = ["52"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_BANDLOOT_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,REGEN_BANDLOOT_1,true|FILE_MARK_OC,pbl_01a_chest;ql=SI_FALSE,REGEN_BANDLOOT_1",
            },
        },
        ["p1_bandit_lair_01e"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676195,
                ObjectIds = ["255"],
                IsKeyItem = false,
                GISIdentifier = "AP_LUNAR_COMPASS",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_AP,AP_LUNAR_COMPASS",
            },
        },
        ["p1_bandit_lair_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676293,
                ObjectIds = ["30"],
                IsKeyItem = false,
                GISIdentifier = "AP_BANDIT_BEANS_1",
                OverrideType =
                    "type=P1_BANDIT_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_BANDIT_BEANS_1|FILE_MARK_OC,bl02_beans;ql=OC_ABSENT,bl02_beans",
            },
        },
        ["p1_bandit_lair_04"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676294,
                ObjectIds = ["35"],
                IsKeyItem = false,
                GISIdentifier = "AP_BANDIT_BEANS_2",
                OverrideType =
                    "type=P1_BANDIT_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_BANDIT_BEANS_2|FILE_MARK_OC,bl04_beans;ql=OC_ABSENT,bl04_beans",
            },
        },
        ["p1_bandit_lair_04a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676295,
                ObjectIds = ["91"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_MONEY_6",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_MONEY_6;ql=SI_FALSE,BANDIT_MONEY_6",
            },
        },
        ["p1_bandit_lair_04b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676296,
                ObjectIds = ["29"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_BANDIT_3",
                OverrideType =
                    "name=SHINY_LOOT;type=P1_BANDIT_POT_L;ql=SI_FALSE,MOON_BANDIT_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_BANDIT_3",
            },
            new Check
            {
                ArchipelagoId = 7676297,
                ObjectIds = ["56"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_MONEY_7",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_MONEY_7;ql=SI_FALSE,BANDIT_MONEY_7",
            },
        },
        ["p1_bandit_lair_midpoint"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676299,
                ObjectIds = ["31"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_BANDLOOT_2",
                OverrideType =
                    "type=P1_BANDIT_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_BANDLOOT_2;ql=SI_FALSE,REGEN_BANDLOOT_2",
            },
            new Check
            {
                ArchipelagoId = 7676300,
                ObjectIds = ["12"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_BANDLOOT_3",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_BANDLOOT_3;ql=SI_FALSE,REGEN_BANDLOOT_3",
            },
        },
        ["p1_bandit_lair_main"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676301,
                ObjectIds = ["23"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_KEY_1_COLLECTED",
                OverrideType =
                    "name=guardA;type=p1_ninja;initial_behavior=shine;defeated_GIS=FILE_MARK_OC,beat_key_bandit1|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_KEY_1_COLLECTED;ql=SI_FALSE,BANDIT_KEY_1_COLLECTED;face_right",
            },
        },
        ["p1_bandit_lair_storeroom2"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676302,
                ObjectIds = ["98"],
                IsKeyItem = false,
                GISIdentifier = "AP_BANDIT_MOUSE_2",
                OverrideType =
                    "ql=ALWAYS_TRUE;name=mousey;type=p_mouse;instruction=tmx(50/22);GIS=particle_emitter,mouse_lights,stop|SPAWN_loot,%ItemLink$7676303%,loot_GIS_MARK_SI$BANDIT_KEY_2_COLLECTED|SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_BANDIT_MOUSE_2;binding=CONTINUE_IF,NAME_EXISTS,mousey|particle_emitter,mouse_lights,stop",
            },
            new Check
            {
                ArchipelagoId = 7676303,
                ObjectIds = ["98"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_KEY_2_COLLECTED",
                OverrideType =
                    "ql=ALWAYS_TRUE;name=mousey;type=p_mouse;instruction=tmx(50/22);GIS=particle_emitter,mouse_lights,stop|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_KEY_2_COLLECTED|SPAWN_loot,%ItemLink$7676302%,loot_GIS_MARK_AP$AP_BANDIT_MOUSE_2;binding=CONTINUE_IF,NAME_EXISTS,mousey|particle_emitter,mouse_lights,stop",
            },
            new Check
            {
                ArchipelagoId = 7676304,
                ObjectIds = ["89"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_BANDIT_6",
                OverrideType =
                    "name=SHINY_LOOT;type=P1_CHEST_S;ql=SI_FALSE,MOON_BANDIT_6;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_BANDIT_6;use_all_bright",
            },
            new Check
            {
                ArchipelagoId = 7676305,
                ObjectIds = ["87"],
                IsKeyItem = false,
                GISIdentifier = "bls2_pear",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_POC$bls2_pear;ql=POC_ABSENT,bls2_pear;use_all_bright",
            },
            new Check
            {
                ArchipelagoId = 7676306,
                ObjectIds = ["88"],
                IsKeyItem = false,
                GISIdentifier = "bls2_jerky",
                OverrideType =
                    "type=P1_WIDE_WOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_POC$bls2_jerky;ql=POC_ABSENT,bls2_jerky;use_all_bright",
            },
        },
        ["p1_bandit_lair_store_secret"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676307,
                ObjectIds = ["19"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_MONEY_2",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_MONEY_2;ql=SI_FALSE,BANDIT_MONEY_2",
            },
        },
        ["p1_bandit_lair_jail"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676310,
                ObjectIds = ["21"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2940] = [["ITEM_add,3,1|", ""]],
                },
                GISIdentifier = "HEART_BANDIT_3",
                OverrideType =
                    "name=ruby;voice=woman,1.15;profile=ruby;speech=line,RUBY_BANDIT_2,RUBY_BANDIT_3;behavior=stand;ql=SI_FALSE,HEART_BANDIT_3;use_all_bright",
            },
        },
        ["p1_bandit_lair_shrine"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676308,
                ObjectIds = ["133"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1181] = [["GO,GP1", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,BANDIT_KEY_5_COLLECTED,true"]],
                },
                GISIdentifier = "BANDIT_KEY_5_COLLECTED",
                OverrideType =
                    "name=selene;voice=woman,1.05;profile=dancer;speech=SELENE_1;behavior=stand;face_right;ql=SI_FALSE,BANDIT_KEY_5_COLLECTED",
            },
            new Check
            {
                ArchipelagoId = 7676309,
                ObjectIds = ["197"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_BANDIT_5",
                OverrideType =
                    "id=%ItemId%;name=MOON_STONE;collected_GIS=FILE_MARK_SI,MOON_BANDIT_5,true;ql=SI_FALSE,MOON_BANDIT_5",
            },
        },
        ["p1_bandit_lair_watch_tower"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676188,
                ObjectIds = ["40"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_BANDIT_7",
                OverrideType =
                    "name=SHINY_LOOT;type=P1_CHEST_S;ql=SI_FALSE,MOON_BANDIT_7;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_BANDIT_7",
            },
        },
        ["p1_bandit_lair_storeroom"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676311,
                ObjectIds = ["14"],
                IsKeyItem = false,
                GISIdentifier = "bl07b_pear",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_POC$bl07b_pear;ql=POC_ABSENT,bl07b_pear",
            },
            new Check
            {
                ArchipelagoId = 7676312,
                ObjectIds = ["15"],
                IsKeyItem = false,
                GISIdentifier = "bl07b_egg",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_OC$bl07b_egg;ql=OC_ABSENT,bl07b_egg",
            },
            new Check
            {
                ArchipelagoId = 7676313,
                ObjectIds = ["37"],
                IsKeyItem = false,
                GISIdentifier = "BANDIT_STINK_ROOT",
                OverrideType =
                    "name=stink_crate;type=P1_CRATE_WIDE;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$BANDIT_STINK_ROOT",
            },
            new Check
            {
                ArchipelagoId = 7676314,
                ObjectIds = ["9"],
                IsKeyItem = false,
                GISIdentifier = "bl07b_jerky",
                OverrideType =
                    "type=P1_WIDE_WOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_POC$bl07b_jerky;ql=POC_ABSENT,bl07b_jerky",
            },
            new Check
            {
                ArchipelagoId = 7676315,
                ObjectIds = ["22"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_MONEY_4",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_MONEY_4;ql=SI_FALSE,BANDIT_MONEY_4",
            },
            new Check
            {
                ArchipelagoId = 7676316,
                ObjectIds = ["52"],
                IsKeyItem = false,
                GISIdentifier = "AP_BANDIT_MOUSE_3",
                OverrideType =
                    "name=mouse2;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_BANDIT_MOUSE_3;type=p_mouse;instruction=tmx(38/19)",
            },
        },
        ["p1_bandit_lair_balo"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676317,
                ObjectIds = ["5-first win"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_BANDIT_2",
                OverrideType =
                    "FILE_MARK_SI,OXY_BANDIT_2,true|override_npc_anim,gamer,balo_idle|FILE_MARK_OC,just_baloed",
            },
            new Check
            {
                ArchipelagoId = 7676318,
                ObjectIds = ["6-second win"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_BANDIT_4",
                OverrideType =
                    "FILE_MARK_SI,HEART_BANDIT_4,true|override_npc_anim,gamer,balo_idle|FILE_ERASE_OC,balo_flavor_text",
            },
        },
        ["p1_bandit_lair_kitchen"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676319,
                ObjectIds = ["142"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_KEY_4_COLLECTED",
                OverrideType =
                    "name=guardA;type=p1_viking;face_right;initial_behavior=shine;defeated_GIS=FILE_MARK_OC,beat_key_bandit4|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_KEY_4_COLLECTED;ql=SI_FALSE,BANDIT_KEY_4_COLLECTED",
            },
        },
        ["p1_bandit_lair_hatchery"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676320,
                ObjectIds = ["35"],
                IsKeyItem = false,
                GISIdentifier = "hatchery_jerky",
                OverrideType =
                    "type=P1_BANDIT_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_OC$hatchery_jerky;ql=OC_ABSENT,hatchery_jerky",
            },
            new Check
            {
                ArchipelagoId = 7676321,
                ObjectIds = ["117"],
                IsKeyItem = false,
                GISIdentifier = "AP_LUNAR_DRAKE",
                OverrideType =
                    "type=P1_BANDIT_POT_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_LUNAR_DRAKE",
            },
            new Check
            {
                ArchipelagoId = 7676322,
                ObjectIds = ["38"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_MONEY_3",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_MONEY_3;ql=SI_FALSE,BANDIT_MONEY_3",
            },
        },
        ["p1_bandit_lair_09"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676561,
                ObjectIds = ["9-pay up"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2965] = [["CHOICE,SNAKE_HOW_MUCH,SNAKE_NOT_TOUGH,SNAKE_CANCEL", "CHOICE,SNAKE_NOT_TOUGH,SNAKE_CANCEL"],
                              ["How much?||", ""]],
                    [2978] = [["CHOICE,2979,SNAKE_START_FIGHT", "CHOICE,SNAKE_START_FIGHT"], ["How much was it again?||", ""]],
                    [2992] = [["CHOICE,2993,2994", "CHOICE,2994"], ["Don't do it again...||", ""]],
                    [2994] = [["my money", "%APPlayer/my %%APItem%"]],
                },
                GISIdentifier = "AP_BANDIT_SNAKE",
                OverrideType =
                    "FILE_MARK_AP,AP_BANDIT_SNAKE",
            },
        },
        ["p1_bandit_lair_stealth_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676323,
                ObjectIds = ["22"],
                IsKeyItem = true,
                GISIdentifier = "BANDIT_KEY_3_COLLECTED",
                OverrideType =
                    "type=p1_viking;initial_behavior=shine;defeated_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$BANDIT_KEY_3_COLLECTED;ql=SI_FALSE,BANDIT_KEY_3_COLLECTED;alerted_GIS=GIS_PACK,1;face_right",
            },
        },
        ["p1_bandit_lair_lihu"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676324,
                ObjectIds = ["49"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3116] = [["ITEM_add,111,1|", ""]],
                },
                GISIdentifier = "LIHU_KEY_GET",
                OverrideType =
                    "name=lihu;voice=man,1.05;profile=lihu;speech=LIHU,LIHU+1;behavior=stand;ql=SI_TRUE,LIHU_KEY_GET&POC_ABSENT,lihu_vanish",
            },
        },
        ["p1_bandit_lair_atri"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676325,
                ObjectIds = ["16"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3088] = [["ITEM_add,111,1|", ""]],
                },
                GISIdentifier = "ATRI_KEY_GET",
                OverrideType =
                    "voice=woman;name=matri2;profile=matri;speech=line,ATRI_POST_BATTLE,ATRI_POST_BATTLE2,ATRI_POST_BATTLE3;behavior=stand;face_right;ql=SI_FALSE,BIRDY_CAUGHT&SI_FALSE,ATRI_KEY_GET;use_all_bright",
            },
        },
        ["p1_bandit_lair_rala"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676326,
                ObjectIds = ["9"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3206] = [["ITEM_add,111,1|", ""]],
                },
                GISIdentifier = "RALA_KEY_GET",
                OverrideType =
                    "profile=rala;speech=RALA_THE_BANDIT;name=gamer;voice=woman,0.95;behavior=stand;spacing=left,1.5;use_all_bright",
            },
        },
        // ["p1_bandit_lair_shrine2"] = new List<Check> // TODO: Atri checks 7676327-7676329
        // {
        // },
        ["p1_atai_mansion_bedroom"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676557,
                ObjectIds = ["75"],
                IsKeyItem = true,
                GISIdentifier = "AP_MANSION_LETTERS",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_AP,AP_MANSION_LETTERS",
            },
        },
        ["p1_atai_mansion_paintings"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676558,
                ObjectIds = ["31"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [2574] = [["money_adjust,P1_RAI,150|", ""]],
                },
                GISIdentifier = "MAYOR_QUEST_3",
                OverrideType =
                    "name=mikhail;profile=atai_grandpa;voice=man,0.98;speech=MIKHAIL_1;behavior=stand;face_right;floating;use_all_bright",
            },
            new Check
            {
                ArchipelagoId = 7676559,
                ObjectIds = ["3-receive heart"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_ATAI_4",
                OverrideType =
                    "FILE_MARK_SI,HEART_ATAI_4,true",
            },
        },
        ["p1_moonlight_ravine_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676332,
                HintWhenLoaded = true,
                ObjectIds = ["21"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3477] = [["JUMP_TO,FISHPOLE_GET+-1,IF_TRUE|ITEM_HAVE_COUNT,40,1;", ""],
                              ["a <#00ffff>fishing rod</color>", "%APPlayer/our %<#00ffff>%APItem%</color>"]],
                    [3478] = [["stick", "%APItem%"]],
                    [3479] = [["a Fishing Rod", "%APPlayer%%APItem%"]],
                    [3480] = [["ITEM_add,40,1;GO,FISHPOLE_GET", "FILE_MARK_AP,AP_RAVINE_SHOP_POLE|recycle,shop_1"]],
                },
                GISIdentifier = "AP_RAVINE_SHOP_POLE",
                OverrideType =
                    "profile=item,%ItemId%;speech=MERCHANT_MOON_POLE;voice=woman,0.95;spacing=stand;shiny;name=shop_1",
            },
            new Check // TODO: item consists of multiple sprites, remove others
            {
                ArchipelagoId = 7676333,
                HintWhenLoaded = true,
                ObjectIds = ["24"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3466] = [["<#00ffff>Cooked knife krill</color>", "%APPlayer%<#00ffff>%APItem%</color>"]],
                    [3467] = [["a bundle of 3 Cooked Knife Krills", "%APPlayer%%APItem%"]],
                    [3468] = [
                        ["JUMP_TO,MERCHANT_MOON_REJECTED+1,IF_FALSE|ITEM_CAN_ADD,87,3;", ""],
                        ["ITEM_add,87,3", "FILE_MARK_AP,AP_RAVINE_SHOP_KRILL|recycle,shop_2"],
                    ],
                },
                GISIdentifier = "AP_RAVINE_SHOP_KRILL",
                OverrideType =
                    "profile=item,%ItemId%;speech=MERCHANT_MOON_KRILL;spacing=left,0.1;name=shop_2",
            },
            new Check // TODO: item consists of multiple sprites, remove others
            {
                ArchipelagoId = 7676334,
                HintWhenLoaded = true,
                ObjectIds = ["25"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3469] = [["<#00ffff>sushi</color>", "%APPlayer/our %<#00ffff>%APItem%</color>"]],
                    [3470] = [["2 pieces of Sushi", "%APPlayer%%APItem%"]],
                    [3471] = [
                        ["JUMP_TO,MERCHANT_MOON_REJECTED+1,IF_FALSE|ITEM_CAN_ADD,79,2;", ""],
                        ["ITEM_add,79,2", "FILE_MARK_AP,AP_RAVINE_SHOP_SUSHI|recycle,shop_3"],
                    ],
                },
                GISIdentifier = "AP_RAVINE_SHOP_SUSHI",
                OverrideType =
                    "profile=item,%ItemId%;speech=MERCHANT_MOON_SUSHI;spacing=left,0.1;face_right;name=shop_3",
            },
            new Check
            {
                ArchipelagoId = 7676335,
                HintWhenLoaded = true,
                ObjectIds = ["26"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3472] = [["A <#00ffff>fish skewer</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [3473] = [["a Fish Skewer", "%APPlayer%%APItem%"]],
                    [3474] = [
                        ["JUMP_TO,MERCHANT_MOON_REJECTED+1,IF_FALSE|ITEM_CAN_ADD,84,1;", ""],
                        ["ITEM_add,84,1", "FILE_MARK_AP,AP_RAVINE_SHOP_FISH|recycle,shop_4"],
                    ],
                },
                GISIdentifier = "AP_RAVINE_SHOP_FISH",
                OverrideType =
                    "profile=item,%ItemId%;speech=MERCHANT_MOON_FISH;spacing=left,0.1;name=shop_4",
            },
            new Check
            {
                ArchipelagoId = 7676336,
                ObjectIds = ["28"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_RAV_LOOT_1",
                OverrideType =
                    "type=P1_WOOD_S;ql=SI_FALSE,REGEN_RAV_LOOT_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_RAV_LOOT_1",
            },
            new Check
            {
                ArchipelagoId = 7676337,
                ObjectIds = ["219"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3483] = [["GO,GP4", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,MOON_RAVINE_4,true"]]
                },
                GISIdentifier = "MOON_RAVINE_4",
                OverrideType =
                    "profile=panselo_teen_boy;voice=man,1.1;speech=HIDDEN_MAN;behavior=stand;face_right;ql=SI_FALSE,MOON_RAVINE_4",
            },
        },
        ["p1_moonlight_ravine_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676338,
                ObjectIds = ["137"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_02d",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_02d;ql=POC_ABSENT,mkelp_02d",
            },
            new Check
            {
                ArchipelagoId = 7676339,
                ObjectIds = ["134"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_02a",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_02a;ql=POC_ABSENT,mkelp_02a",
            },
            new Check
            {
                ArchipelagoId = 7676340,
                ObjectIds = ["135"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_02b",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_02b;ql=POC_ABSENT,mkelp_02b",
            },
            new Check
            {
                ArchipelagoId = 7676342,
                ObjectIds = ["136"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_02c",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_02c;ql=POC_ABSENT,mkelp_02c",
            },
            new Check
            {
                ArchipelagoId = 7676341,
                ObjectIds = ["34"],
                IsKeyItem = true,
                GISIdentifier = "RAVINE_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$RAVINE_MONEY_1;ql=SI_FALSE,RAVINE_MONEY_1",
            },
        },
        ["p1_moonlight_ravine_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676343,
                ObjectIds = ["124"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_03a",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_03a;ql=POC_ABSENT,mkelp_03a",
            },
            new Check
            {
                ArchipelagoId = 7676344,
                ObjectIds = ["125"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_03b",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_03b;ql=POC_ABSENT,mkelp_03b",
            },
            new Check
            {
                ArchipelagoId = 7676346,
                ObjectIds = ["127"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_03d",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_03d;ql=POC_ABSENT,mkelp_03d",
            },
            new Check
            {
                ArchipelagoId = 7676347,
                ObjectIds = ["126"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_03c",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_03c;ql=POC_ABSENT,mkelp_03c",
            },
            new Check
            {
                ArchipelagoId = 7676345,
                ObjectIds = ["33"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_RAVINE_1",
                OverrideType =
                    "type=P1_ANURI_CERAMIC_POT_S;ql=SI_FALSE,MOON_RAVINE_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_RAVINE_1",
            },
            new Check
            {
                ArchipelagoId = 7676348,
                ObjectIds = ["172"],
                IsKeyItem = false,
                GISIdentifier = "AP_LUNAR_CROWN",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_AP,AP_LUNAR_CROWN",
            },
        },
        ["p1_moonlight_ravine_04"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676349,
                ObjectIds = ["103"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_04a",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_04a;ql=POC_ABSENT,mkelp_04a",
            },
            new Check
            {
                ArchipelagoId = 7676351,
                ObjectIds = ["104"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_04b",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_04b;ql=POC_ABSENT,mkelp_04b",
            },
            new Check
            {
                ArchipelagoId = 7676354,
                ObjectIds = ["105"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_04c",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_04c;ql=POC_ABSENT,mkelp_04c",
            },
            new Check
            {
                ArchipelagoId = 7676355,
                ObjectIds = ["106"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_04d",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_04d;ql=POC_ABSENT,mkelp_04d",
            },
            new Check
            {
                ArchipelagoId = 7676350,
                ObjectIds = ["36"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_RAVINE_2",
                OverrideType =
                    "name=moon_pot;type=P1_ANURI_CERAMIC_POT_S;ql=SI_FALSE,MOON_RAVINE_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_RAVINE_2|particle_emitter,highlighter,stop",
            },
            new Check
            {
                ArchipelagoId = 7676352,
                ObjectIds = ["168"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_RAVINE_3",
                OverrideType =
                    "name=moon_pot2;type=P1_ANURI_CERAMIC_POT_L;ql=SI_FALSE,MOON_RAVINE_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_RAVINE_3|particle_emitter,highlighter2,stop",
            },
            new Check
            {
                ArchipelagoId = 7676353,
                ObjectIds = ["35"],
                IsKeyItem = true,
                GISIdentifier = "RAVINE_MONEY_2",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$RAVINE_MONEY_2;ql=SI_FALSE,RAVINE_MONEY_2",
            },
        },
        ["p1_moonlight_ravine_05"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676356,
                ObjectIds = ["97"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_05a",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_05a;ql=POC_ABSENT,mkelp_05a",
            },
            new Check
            {
                ArchipelagoId = 7676359,
                ObjectIds = ["98"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_05b",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_05b;ql=POC_ABSENT,mkelp_05b",
            },
            new Check
            {
                ArchipelagoId = 7676361,
                ObjectIds = ["99"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_05c",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_05c;ql=POC_ABSENT,mkelp_05c",
            },
            new Check
            {
                ArchipelagoId = 7676362,
                ObjectIds = ["100"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_05d",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_05d;ql=POC_ABSENT,mkelp_05d",
            },
            new Check
            {
                ArchipelagoId = 7676357,
                ObjectIds = ["164"],
                IsKeyItem = false,
                GISIdentifier = "AP_RAVINE_LIZARD_1",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_RAVINE_LIZARD_1;instruction=tmx(18/30),tmx(23/32),tmx(18.875/30);sort=bg_tiles,6",
            },
            new Check
            {
                ArchipelagoId = 7676358,
                ObjectIds = ["163"],
                IsKeyItem = false,
                GISIdentifier = "AP_LUNAR_TRIDENT",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_AP,AP_LUNAR_TRIDENT;angle=180;gravity=0;sort=bg_tiles,14",
            },
            new Check
            {
                ArchipelagoId = 7676360,
                ObjectIds = ["42"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_RAVINE_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_RAVINE_1,true;ql=SI_FALSE,OXY_RAVINE_1;gravity=0",
            },
        },
        ["p1_moonlight_ravine_06"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676363,
                ObjectIds = ["77"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_06c",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_06c;ql=POC_ABSENT,mkelp_06c",
            },
            new Check
            {
                ArchipelagoId = 7676365,
                ObjectIds = ["75"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_06a",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_06a;ql=POC_ABSENT,mkelp_06a",
            },
            new Check
            {
                ArchipelagoId = 7676366,
                ObjectIds = ["76"],
                IsKeyItem = false,
                GISIdentifier = "mkelp_06b",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_POC,mkelp_06b;ql=POC_ABSENT,mkelp_06b",
            },
            new Check // TODO: modify so Bo is always there?
            {
                ArchipelagoId = 7676364,
                ObjectIds = ["09-won race"],
                IsKeyItem = true,
                GISIdentifier = "BO_QUEST_2",
                OverrideType =
                    "FILE_MARK_SI,BO_QUEST_2,true|FILE_MARK_OC,bo_temp",
            },
            new Check
            {
                ArchipelagoId = 7676367,
                ObjectIds = ["73"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_FISH_4",
                OverrideType =
                    "name=moon_fish;initial_behavior=STATIC;type=fish;instruction=FISH_M;defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FISH_4|particle_emitter,highlighter,stop;ql=SI_FALSE,MOON_FISH_4",
            },
            new Check
            {
                ArchipelagoId = 7676368,
                ObjectIds = ["202"],
                IsKeyItem = true,
                GISIdentifier = "RAVINE_MONEY_3",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$RAVINE_MONEY_3;ql=SI_FALSE,RAVINE_MONEY_3",
            },
        },
        ["p1_ex_cave_04"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676426,
                ObjectIds = ["274"],
                IsKeyItem = true,
                GISIdentifier = "DAEA_MONEY_2",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$DAEA_MONEY_2;ql=SI_FALSE,DAEA_MONEY_2",
            },
            new Check
            {
                ArchipelagoId = 7676427,
                ObjectIds = ["273"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_DAEA_4",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_DAEA_4,true;ql=SI_FALSE,OXY_DAEA_4",
            },
        },
        // ["p1_ex_forest_03"] = new List<Check>
        // {
        //     new Check // TODO: needs custom level
        //     {
        //         ArchipelagoId = 7676428,
        //         ObjectIds = ["301"],
        //         IsKeyItem = true,
        //         GISIdentifier = "PERRO_3",
        //         OverrideType =
        //             "id=%ItemId%;collected_GIS=FILE_MARK_SI,PERRO_3,true;ql=AP_SETTING_TRUE,PERRO&SI_FALSE,PERRO_3",
        //     },
        // },
        ["p1_ex_ouroboros_05a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676429,
                ObjectIds = ["154"],
                IsKeyItem = true,
                GISIdentifier = "OURO_SCROLL_5",
                OverrideType =
                    "id=%ItemId%;use_all_bright;collected_GIS=FILE_MARK_SI,OURO_SCROLL_5,true;ql=SI_FALSE,OURO_SCROLL_5",
            },
        },
        ["p1_ex_geo_06d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676430,
                ObjectIds = ["84"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3839] = [["Here's your ticket", "Here's %APPlayer/your %%APItem%"], ["|ITEM_add,140,1", ""]],
                },
                GISIdentifier = "GEO_TICKET_6",
                OverrideType =
                    "name=geo_bot;voice=robot,1;profile=green_robot;behavior=stand;speech=GEO_ROBOT_06+3,GEO_ROBOT_06+5,GEO_ROBOT_06+6",
            },
        },
        ["p1_ex_geo_06"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676431,
                ObjectIds = ["288"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [7390] = [["GO,PLANTO_REWARD+-1", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_AP,AP_PLANTO_3"]],
                },
                GISIdentifier = "AP_PLANTO_3",
                DifferingInGameIdentifier = "PLANTO_3",
                OverrideType =
                    "name=planto;profile=planto;voice=man,0.85;speech=PLANTO_P3;behavior=action_only;ql=SI_FALSE,PLANTO_3;floating;sort=bg_tiles,-1;talk_range=4;spacing=stand",
            },
        },
        ["p1_frans_base"] = new List<Check> // TODO: implement gift checks 7676438 to 7676441 + make non-missable
        {
            new Check
            {
                ArchipelagoId = 7676432,
                ObjectIds = ["393"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [9404] = [["my extremely precious voucher for one free <#00ffff>pocket expansion</color> at Tailoring Tracy's", "%APPlayer/my %extremely precious %APItem%"]],
                    [9405] = [["Tailoring Tracy's is GREAT!<*_>", "%APItem% is GREAT!<*_> And so is Tailoring Tracy's!"]],
                    [9409] = [["use it", "keep %APItem%"]],
                    [9410] = [["GO,9411", "GO,9412"]],
                    [9412] = [["ITEM_add,164,1|", ""], ["voucher", "%APItem%"]],
                },
                GISIdentifier = "FRAN_QUEST_2",
                OverrideType =
                    "name=fran;profile=fran;voice=woman,1;speech=FRAN_2;behavior=path,33,42;use_all_bright;sort=fg_tiles,101",
            },
            new Check
            {
                ArchipelagoId = 7676434,
                ObjectIds = ["411"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [9517] = [["GO,9518", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,FRAN_VOUCHER2,true"]],
                },
                GISIdentifier = "FRAN_VOUCHER2",
                OverrideType =
                    "name=fran;profile=fran;voice=woman,1;speech=FRAN_20_30;behavior=stand;face_right;ql=END_DOOR_ID_EQS,99",
            },
            new Check
            {
                ArchipelagoId = 7676436,
                ObjectIds = ["418"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [9572] = [["the ", "%APPlayer/the %"], ["Moon Crystal", "%APItem%"]],
                    [9574] = [["GO,GP9", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_AP,AP_FRAN_BATCH_4"]],
                },
                GISIdentifier = "AP_FRAN_BATCH_4",
                OverrideType =
                    "name=fran;profile=fran;voice=woman,1;speech=FRAN_40_50;behavior=stand;face_right;ql=END_DOOR_ID_EQS,99",
            },
            new Check
            {
                ArchipelagoId = 7676437,
                ObjectIds = ["422"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [9610] = [["the ", "%APPlayer/the %"], ["Heart Ruby", "%APItem%"]],
                    [9611] = [["Heart Rubies", "of them"]],
                    [9613] = [["Heart Ruby", "of them"], ["GO,GP6", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,HEART_FRAN_2,true|FILE_MARK_OC,turned_50"]],
                },
                GISIdentifier = "HEART_FRAN_2",
                OverrideType =
                    "name=fran;profile=fran;voice=woman,1;speech=FRAN_40_50;face_right;ql=OC_EXISTS,turned_50",
            },
        },
        ["p1_fran_geo_outside"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676433,
                ObjectIds = ["206"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [9494] = [["GO,GP2", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,HEART_FRAN_1,true|black_bars_out"]],
                },
                GISIdentifier = "HEART_FRAN_1",
                OverrideType =
                    "name=fran;profile=fran;voice=woman,1;speech=FRAN_10_20;behavior=stand;face_right;ql=END_DOOR_ID_EQS,99",
            },
            new Check
            {
                ArchipelagoId = 7676435,
                ObjectIds = ["228"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [9543] = [["GO,GP8", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,OXY_FRAN_1,true"]],
                },
                GISIdentifier = "OXY_FRAN_1",
                OverrideType =
                    "name=fran;profile=fran;voice=woman,1;speech=FRAN_30_40;behavior=stand;face_right;ql=END_DOOR_ID_EQS,98",
            },
            new Check
            {
                ArchipelagoId = 7676451,
                ObjectIds = ["212"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_FISH_6",
                OverrideType =
                    "name=moon_fish;face_right;initial_behavior=STATIC;type=fish;instruction=FISH_M;defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FISH_6|particle_emitter,fish_highlighter,stop;ql=ALWAYS_TRUE",
            },
        },
        ["p1_geo_base"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676443,
                HintWhenLoaded = true,
                ObjectIds = ["338"],
                IsKeyItem = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3782] = [["is a most", "is %APPlayer/a %most"], ["golden egg", "%APItem%"]],
                    [3784] = [["a Golden Egg", "%APPlayer%%APItem%"]],
                    [3785] = [["JUMP_TO,GEO_EXCHANGE_NO+4,IF_FALSE|ITEM_CAN_ADD,95,1;", ""],
                              ["GO,GP1;", "GO,%BonusLine%;"]],
                    [-1] = [["GIS,FILE_MARK_SI,GEO_EGG_1,true|recycle,shop_1"]],
                },
                GISIdentifier = "GEO_EGG_1",
                OverrideType =
                    "profile=item,%ItemId%;speech=GEO_EXCHANGE_EGG;spacing=stand;talk_range=0.75;shiny;name=shop_1",
            },
            new Check
            {
                ArchipelagoId = 7676444,
                HintWhenLoaded = true,
                ObjectIds = ["336"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3786] = [["That's a ", "That's %APPlayer/a %"], ["Heart Ruby", "%APItem%"], ["a beautiful red gem ", ""]],
                    [3788] = [["a Heart Ruby", "%APPlayer%%APItem%"]],
                    [3789] = [["GO,GP2;", "GO,%BonusLine%;"]],
                    [-1] = [["GIS,FILE_MARK_SI,HEART_GEO_1,true|recycle,shop_2"]],
                },
                GISIdentifier = "HEART_GEO_1",
                OverrideType =
                    "profile=item,%ItemId%;speech=GEO_EXCHANGE_HEART;spacing=stand;talk_range=0.75;shiny;name=shop_2",
            },
            new Check
            {
                ArchipelagoId = 7676445,
                HintWhenLoaded = true,
                ObjectIds = ["337"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3790] = [["An elegant green", "%APPlayer/An %elegant"], ["Energy Gem", "%APItem%"]],
                    [3792] = [["an Energy Gem", "%APPlayer%%APItem%"]],
                    [3793] = [["GO,GP3;", "GO,%BonusLine%;"]],
                    [-1] = [["GIS,FILE_MARK_SI,OXY_GEO_1,true|recycle,shop_3"]],
                },
                GISIdentifier = "OXY_GEO_1",
                OverrideType =
                    "profile=item,%ItemId%;speech=GEO_EXCHANGE_OXY;spacing=stand;talk_range=0.75;shiny;name=shop_3",
            },
            new Check
            {
                ArchipelagoId = 7676446,
                HintWhenLoaded = true,
                ObjectIds = ["339"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3794] = [["A ", "%APPlayer/A %"], ["GEO jacket", "%APItem%"], ["armor", "item"]],
                    [3796] = [["a GEO Jacket", "%APPlayer%%APItem%"]],
                    [3797] = [["JUMP_TO,GEO_EXCHANGE_NO+2,IF_TRUE|ITEM_HAVE,int_list(13);", ""], ["GEO jacket", "%APItem%"]],
                    [3798] = [["GO,GP4", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_AP,AP_GEO_JACKET|recycle,shop_4"]],
                },
                GISIdentifier = "AP_GEO_JACKET",
                OverrideType =
                    "profile=item,%ItemId%;speech=GEO_EXCHANGE_ARMOR;shiny;spacing=stand;talk_range=0.75;name=shop_4",
            },
            new Check
            {
                ArchipelagoId = 7676449,
                ObjectIds = ["431"],
                GISIdentifier = "REGEN_GEO_1",
                OverrideType =
                    "type=P1_WOOD_S;ql=SI_FALSE,REGEN_GEO_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_GEO_1;use_all_bright",
            },
        },
        // ["p1_geo_head_office"] = new List<Check> // TODO: implement 7676442 (probably needs custom level)
        // {
        //     new Check
        //     {
        //         ArchipelagoId = 7676447,
        //         HintWhenLoaded = true,
        //         ObjectIds = ["330", "340", "325"], // Loot
        //         // ObjectIds = ["343"], // Shelf
        //         IsKeyItem = true,
        //         FillWhenExcluded = FillMode.Always,
        //         IsNpc = true,
        //         DialogReplacements = new Dictionary<int, List<string[]>>
        //         {
        //             [3687] = [["Ask about earrings", "Ask about %APPlayer%%APItem%"]],
        //             [3688] = [["Ask about earrings", "Ask about %APPlayer%%APItem%"],
        //                       ["Trade Antique Pin for earrings", "Trade Antique Pin for %APPlayer%%APItem%"]],
        //             [3689] = [["they", "that item"]],
        //             [3690] = [["They're supposed to be <#00ffff>lucky earrings</color>,<*_> but I don't feel any special resonance from them.", "It's supposed to be lucky <#00ffff>%APItem%</color>,<*_> but I don't feel any special resonance from it."]],
        //             [3691] = [["Do they", "Does it"]],
        //             [3692] = [["these earrings", "%APItem%"]],
        //             [3694] = [["Trade Antique Pin for earrings", "Trade Antique Pin for %APPlayer%%APItem%"]],
        //             [3731] = [["<#00ffff>lucky earrings</color>", "lucky <#00ffff>%APItem%</color>"],
        //                       ["GO,GP8", "GO,%BonusLine%"]],
        //             [-1] = [["GIS,ITEM_remove,141,1|FILE_MARK_AP,AP_LUCKY_EARRINGS,true|black_bars_out|recycle,shelf_npc|DELAY,0.1|ANY_alpha_tween,earrings,0|AT_effect_enable,earring_halo,off|ANY_alpha_tween,earring_halo,0|particle_emitter,highlighter,stop"]],
        //         },
        //         GISIdentifier = "AP_LUCKY_EARRINGS",
        //         OverrideType =
        //             "name=earrings;loot=%ItemId%;sort=bg_tiles,12;use_all_bright", // Loot // TODO: showing the corresponding item doesn't work yet
        //             // "name=shelf_npc;profile=!;voice=woman,1;speech=GEO_SHELF;behavior=stand;spacing=left,0.5;floating", // Shelf
        //     },
        //     new Check
        //     {
        //         ArchipelagoId = 7676448,
        //         ObjectIds = ["343"],
        //         IsKeyItem = true,
        //         FillWhenExcluded = FillMode.StatusUpgrade,
        //         IsNpc = true,
        //         DialogReplacements = new Dictionary<int, List<string[]>>
        //         {
        //             // [3730] = [["JUMP_TO,3732,IF_TRUE|ITEM_HAVE,int_list(26)", ""]], // TODO: how to implement conditional? can only get via conditional
        //             [3732] = [["GO,GP9", "GO,%BonusLine%"]],
        //             [-1] = [["ITEM_remove,141,1|FILE_MARK_SI,HEART_GEO_2,true|black_bars_out"]],
        //         },
        //         GISIdentifier = "HEART_GEO_2",
        //         OverrideType =
        //             "name=shelf_npc;profile=!;voice=woman,1;speech=GEO_SHELF;behavior=stand;spacing=left,0.5;floating",
        //     },
        // },
        ["p1_ex_geo_07a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676450,
                ObjectIds = ["189"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3809] = [["Receive your ticket now", "Receive %APPlayer/your %%APItem% now"]],
                    [3810] = [["|ITEM_add,140,1", ""]],
                },
                GISIdentifier = "GEO_TICKET_7",
                OverrideType =
                    "name=geo_bot;voice=robot,1;profile=green_robot;behavior=stand;speech=GEO_ROBOT_07",
            },
        },
        ["p1_thomas_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676452,
                ObjectIds = ["7"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    // Prevent correct answer until gift is earned
                    [5585] = [["CHOICE,5586,5587,THOMAS_OPEN_1ST||||...||Visiting||Safety inspection||Internship", "CHOICE,5586,5587||||...||Visiting||Safety inspection"]],
                    [5589] = [["money_adjust,P1_RAI,50|", ""]],
                },
                GISIdentifier = "RECEIVED_THOMAS_BRIBE",
                OverrideType =
                    "name=robot;voice=robot,1;profile=arch;speech=ARCH_0;floating;sort=bg_tiles,14;spacing=left,0.25;ql=SI_FALSE,THOMAS_NAPPED",
            },
            // new Check
            // {
            //     ArchipelagoId = 7676466,
            //     ObjectIds = ["7"],
            //     IsNpc = true,
            //     FillWhenExcluded = FillMode.StatusUpgrade,
            //     DialogReplacements = new Dictionary<int, List<string[]>>
            //     {
            //         [5610] = [["shiny blue rock", "mystery item"]],
            //         [5612] = [["GO,GP0", "GO,%BonusLine%"]], // TODO: GP0 calls both GP1 & GP2 which each have a CONTINUE_IF. How to model in dialogue?
            //         [-1] = [["GIS,CONTINUE_IF,OC_EXISTS,exchange_blue|FILE_MARK_SI,MOON_THOMAS_2,true|ITEM_remove,115,1"]],
            //     },
            //     GISIdentifier = "MOON_THOMAS_2",
            //     OverrideType =
            //         "name=robot;voice=robot,1;profile=arch;speech=ARCH_0;floating;sort=bg_tiles,14;spacing=left,0.25;ql=SI_FALSE,THOMAS_NAPPED",
            // },
            // new Check
            // {
            //     ArchipelagoId = 7676467,
            //     ObjectIds = ["7"],
            //     IsNpc = true,
            //     FillWhenExcluded = FillMode.StatusUpgrade,
            //     DialogReplacements = new Dictionary<int, List<string[]>>
            //     {
            //         [5610] = [["shiny blue rock", "mystery item"]],
            //         [5612] = [["GO,GP0", "GO,%BonusLine%"]], // TODO: GP0 calls both GP1 & GP2 which each have a CONTINUE_IF. How to model in dialogue?
            //         [-1] = [["GIS,CONTINUE_IF,OC_EXISTS,exchange_red|FILE_MARK_SI,MOON_THOMAS_1,true|ITEM_remove,116,1"]],
            //     },
            //     GISIdentifier = "MOON_THOMAS_1",
            //     OverrideType =
            //         "name=robot;voice=robot,1;profile=arch;speech=ARCH_0;floating;sort=bg_tiles,14;spacing=left,0.25;ql=SI_FALSE,THOMAS_NAPPED",
            // },
        },
        ["p1_thomas_02x"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676453,
                ObjectIds = ["214"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5652] = [["GO,5653", "GIS,AP_HINT,%APId%;GO,5653"],
                              ["your", "%APPlayer/your %"], ["Calory Slush", "%APItem%"]],
                    [5654] = [["Calory Slush", "%APItem%"]],
                    [5655] = [["Calory Slush", "%APPlayer%%APItem%"]],
                    [5656] = [["GO,GP1;", "GO,%BonusLine%;"]],
                    [-1] = [["GIS,FILE_MARK_AP,AP_CALORY_SLUSH"]],
                },
                GISIdentifier = "AP_CALORY_SLUSH",
                OverrideType =
                    "name=vend_machine;voice=robot,0.75;profile=!;speech=VENDING_1_SLUSH;spacing=auto,0.1",
            },
        },
        ["p1_thomas_song"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676454,
                ObjectIds = ["70"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_THOMAS_1",
                OverrideType =
                    "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_THOMAS_1,true;ql=SI_FALSE,OXY_THOMAS_1",
            },
        },
        ["p1_thomas_test_11"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676455,
                ObjectIds = ["14"],
                IsKeyItem = true,
                GISIdentifier = "THOMAS_BLUE_KEY_1",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,THOMAS_BLUE_KEY_1;collected_GIS=FILE_MARK_SI,THOMAS_BLUE_KEY_1,true;name=KEY_CARD",
            },
        },
        ["p1_thomas_test_12"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676456,
                ObjectIds = ["19"],
                IsKeyItem = true,
                GISIdentifier = "THOMAS_BLUE_KEY_2",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,THOMAS_BLUE_KEY_2;name=KEY_CARD;collected_GIS=FILE_MARK_SI,THOMAS_BLUE_KEY_2,true|GIS_PACK,1",
            },
        },
        ["p1_thomas_test_13"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676457,
                ObjectIds = ["5"],
                IsKeyItem = true,
                GISIdentifier = "THOMAS_BLUE_KEY_3",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,THOMAS_BLUE_KEY_3;collected_GIS=FILE_MARK_SI,THOMAS_BLUE_KEY_3,true|GIS_PACK,1;name=KEY_CARD",
            },
        },
        ["p1_thomas_test_14"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676458,
                ObjectIds = ["8"],
                IsKeyItem = true,
                GISIdentifier = "THOMAS_BLUE_KEY_4",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,THOMAS_BLUE_KEY_4;collected_GIS=FILE_MARK_SI,THOMAS_BLUE_KEY_4,true;name=KEY_CARD",
            },
        },
        ["p1_thomas_test_21"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676459,
                ObjectIds = ["7"],
                IsKeyItem = true,
                GISIdentifier = "THOMAS_RED_KEY_1",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,THOMAS_RED_KEY_1;collected_GIS=FILE_MARK_SI,THOMAS_RED_KEY_1,true;name=KEY_CARD",
            },
        },
        ["p1_thomas_test_22"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676460,
                ObjectIds = ["9"],
                IsKeyItem = true,
                GISIdentifier = "THOMAS_RED_KEY_2",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,THOMAS_RED_KEY_2;name=KEY_CARD;collected_GIS=FILE_MARK_SI,THOMAS_RED_KEY_2,true|GIS_PACK,1",
            },
        },
        ["p1_thomas_test_23"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676461,
                ObjectIds = ["5"],
                IsKeyItem = true,
                GISIdentifier = "THOMAS_RED_KEY_3",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,THOMAS_RED_KEY_3;name=KEY_CARD;collected_GIS=FILE_MARK_SI,THOMAS_RED_KEY_3,true|GIS_PACK,1",
            },
        },
        ["p1_thomas_test_24"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676462,
                ObjectIds = ["8"],
                IsKeyItem = true,
                GISIdentifier = "THOMAS_RED_KEY_4",
                OverrideType =
                    "id=%ItemId%;ql=SI_FALSE,THOMAS_RED_KEY_4;collected_GIS=FILE_MARK_SI,THOMAS_RED_KEY_4,true;name=KEY_CARD",
            },
        },
        ["p1_thomas_speed"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676463,
                ObjectIds = ["73"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_THOMAS_1",
                OverrideType =
                    "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_THOMAS_1,true;ql=SI_FALSE,HEART_THOMAS_1",
            },
        },
        ["p1_thomas_test_32"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676464,
                ObjectIds = ["56"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_MUFFIN",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_MUFFIN;ql=SI_FALSE,REGEN_MUFFIN",
            },
        },
        ["p1_thomas_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676465,
                ObjectIds = ["80"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_SLUSH",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_SLUSH;ql=SI_FALSE,REGEN_SLUSH",
            },
        },
        // ["p1_thomas_boss"] = new List<Check>
        // {
        //     new Check
        //     {
        //         ArchipelagoId = 7676468,
        //         ObjectIds = ["126", "127"], // TODO: the 2 objects have differing spawn conditions in their type
        //         IsKeyItem = true,
        //         FillWhenExcluded = FillMode.StatusUpgrade,
        //         GISIdentifier = "HEART_FLORET_1",
        //         OverrideType =
        //             "name=heart;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_FLORET_1,true;ql=SI_FALSE,HEART_FLORET_1",
        //     },
        // },
        ["p1_museum"] = new List<Check> // TODO: Lunar artifacts aren't removed after selling
        {
            new Check
            {
                ArchipelagoId = 7676469,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4551] = [["40 R", "%APPlayer%%APItem%"]],
                    [4552] = [["40 R", "%APPlayer%%APItem%"]],
                    [4553] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_DRAKE",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676470,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4565] = [["40 R", "%APPlayer%%APItem%"]],
                    [4566] = [["40 R", "%APPlayer%%APItem%"]],
                    [4567] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_COMPASS",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676471,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4577] = [["40 R", "%APPlayer%%APItem%"]],
                    [4578] = [["40 R", "%APPlayer%%APItem%"]],
                    [4579] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_COMB",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676472,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4589] = [["40 R", "%APPlayer%%APItem%"]],
                    [4590] = [["40 R", "%APPlayer%%APItem%"]],
                    [4591] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_WATCH",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676473,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4603] = [["40 R", "%APPlayer%%APItem%"]],
                    [4604] = [["40 R", "%APPlayer%%APItem%"]],
                    [4605] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_GOBLET",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676474,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4618] = [["40 R", "%APPlayer%%APItem%"]],
                    [4619] = [["40 R", "%APPlayer%%APItem%"]],
                    [4620] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_FROG",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676475,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4636] = [["40 R", "%APPlayer%%APItem%"]],
                    [4637] = [["40 R", "%APPlayer%%APItem%"]],
                    [4638] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_VASE",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676476,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4650] = [["40 R", "%APPlayer%%APItem%"]],
                    [4651] = [["40 R", "%APPlayer%%APItem%"]],
                    [4652] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_TRIDENT",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676477,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4666] = [["40 R", "%APPlayer%%APItem%"]],
                    [4667] = [["40 R", "%APPlayer%%APItem%"]],
                    [4668] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_CROWN",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676478,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4684] = [["40 R", "%APPlayer%%APItem%"]],
                    [4685] = [["40 R", "%APPlayer%%APItem%"]],
                    [4686] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_MEDAL",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676479,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4698] = [["40 R", "%APPlayer%%APItem%"]],
                    [4699] = [["40 R", "%APPlayer%%APItem%"]],
                    [4700] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_KEY",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676480,
                ObjectIds = ["109"],
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4712] = [["40 R", "%APPlayer%%APItem%"]],
                    [4713] = [["40 R", "%APPlayer%%APItem%"]],
                    [4714] = [["your money", "%APPlayer/your %%APItem%"], ["money_adjust,P1_RAI,40|", ""]],
                },
                GISIdentifier = "MUSEUM_EGG",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            new Check
            {
                ArchipelagoId = 7676481,
                ObjectIds = ["109"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4721] = [["this Energy Gem", "%APPlayer%%APItem%"], ["GO,GP5", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,OXY_ASTRID_1,true"]],
                },
                GISIdentifier = "OXY_ASTRID_1",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
            // new Check
            // /* TODO:
            // 1. 4719 ITEM_DONT_HAVE,int_list(25) causes repeated dialogue on following checks and prevents 7676483
            // 2. replaced item is not shown properly
            // 3. item reappears on reentering screen
            // */
            // {
            //     ArchipelagoId = 7676482,
            //     HintWhenLoaded = true,
            //     ObjectIds = ["172"],
            //     IsKeyItem = true,
            //     FillWhenExcluded = FillMode.Always,
            //     DialogReplacements = new Dictionary<int, List<string[]>>
            //     {
            //         [4484] = [["an <#00ffff>antique cast iron</color>", "%APPlayer/my %antique <#00ffff>%APItem%</color>"]],
            //         [4488] = [["cast iron", "%APItem%"]],
            //         [4722] = [["this antique cast iron", "%APPlayer%%APItem%"]],
            //         [4724] = [["GO,GP6", "GO,%BonusLine%"]],
            //         [-1] = [["GIS,FILE_MARK_AP,AP_MUSUEM_CAST_IRON,true|ANY_alpha_tween,cast_iron,0,duration$0.25|particle_emitter,highlighter,stop|AT_effect_enable,iron_halo,off|DELAY,0.1|ANY_alpha_tween,iron_halo,0,duration$0.5|recycle,iron_npc"]],
            //     },
            //     GISIdentifier = "AP_MUSUEM_CAST_IRON",
            //     OverrideType =
            //         "name=cast_iron;loot=%ItemId%;sort=bg_tiles,12;use_all_bright",
            // },
            new Check
            {
                ArchipelagoId = 7676483,
                ObjectIds = ["109"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4733] = [["this gift", "%APPlayer%%APItem%"], ["GO,GP7", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,HEART_ASTRID_2,true"]],
                },
                GISIdentifier = "HEART_ASTRID_2",
                OverrideType =
                    "name=collector;profile=moon_scholar;voice=woman,0.98;speech=MEET_ASTRID_1;behavior=stand;spacing=left,0.75",
            },
        },
        ["p1_museum_under"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676484,
                ObjectIds = ["158"],
                IsKeyItem = false,
                GISIdentifier = "AP_MUSEUM_MOUSE_1",
                OverrideType =
                    "name=mouse2;type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_MUSEUM_MOUSE_1;instruction=tmx(36/23)",
            },
            new Check
            {
                ArchipelagoId = 7676485,
                ObjectIds = ["151"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_ASTRID_1",
                OverrideType =
                    "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_ASTRID_1,true;ql=SI_FALSE,HEART_ASTRID_1",
            },
        },
        ["p1_the_wall_bunkrooms"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676486,
                ObjectIds = ["192"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_WALL_S_2",
                OverrideType =
                    "name=moon_box;type=P1_WOOD_S;ql=SI_FALSE,MOON_WALL_S_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_WALL_S_2|particle_emitter,highlighter,stop",
            },
        },
        ["p1_the_wall_dining"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676488,
                ObjectIds = ["155"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_WALL_LOOT_2",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_WALL_LOOT_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_WALL_LOOT_2",
            },
            new Check
            {
                ArchipelagoId = 7676490,
                ObjectIds = ["149"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [7853] = [["GO,GP1", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,HEART_WALL_1,true"]],
                },
                GISIdentifier = "HEART_WALL_1",
                OverrideType =
                    "name=chef;profile=waiter;voice=man,1;speech=WCHEF_02,WCHEF_02+3;behavior=action_only;face_right;use_all_bright",
            },
        },
        ["p1_the_wall_storeroom"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676489,
                ObjectIds = ["53"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_WALL_LOOT_1",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_WALL_LOOT_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_WALL_LOOT_1",
            },
        },
        ["p1_the_wall_01"] = new List<Check>
        {
            new Check // TODO: first wall needs to be opened for this check
            {
                ArchipelagoId = 7676487,
                ObjectIds = ["61"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_WALL_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_WALL_1,true;ql=SI_FALSE,OXY_WALL_1",
            },
            new Check
            {
                ArchipelagoId = 7676491,
                ObjectIds = ["215"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [7872] = [["a rock from her rock collection", "%APPlayer/her %%APItem% from her %APItem% collection"], ["GO,GP3", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,MOON_WALL_S_1,true"]],
                },
                GISIdentifier = "MOON_WALL_S_1",
                OverrideType =
                    "profile=daea_soldierf;voice=woman,1.03;behavior=stand;face_right;speech=KNIGHT_MOM_3,KNIGHT_MOM_3+2;ql=SI_TRUE,KMOM_2&OC_ABSENT,kmom_temp",
            },
        },
        ["p1_daea_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676369,
                ObjectIds = ["2-get emerald"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5064] = [["GO,5065", "GIS,AP_HINT,%APId%;GO,5065"], ["emerald", "%APItem%"]],
                    [5065] = [["his emeralds", "%APPlayer/his %%APItem%"]],
                    [5066] = [["his emeralds", "%APPlayer/his %%APItem%"]],
                    [5069] = [["an emerald", "%APPlayer%%APItem%"]],
                    [5075] = [["emeralds", "%APItem%"]],
                },
                GISIdentifier = "OXY_DAEA_3",
                OverrideType =
                    "FILE_MARK_SI,OXY_DAEA_3,true|recycle,fount_npc|FILE_MARK_OC,JUMP_TO,BIRD_LADY_2,IF_TRUE",
            },
        },
        ["p1_ex_geo_09d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676370,
                ObjectIds = ["109"],
                IsKeyItem = true,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [3818] = [["Here's your ticket", "Here's %APPlayer/your %%APItem%"], ["|ITEM_add,140,1", ""]],
                },
                GISIdentifier = "GEO_TICKET_9",
                OverrideType =
                    "name=geo_bot;voice=robot,1;profile=green_robot;behavior=stand;speech=GEO_ROBOT_09;sort=fg_tiles,1",
            },
        },
        ["p1_daea_windmill_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676549,
                ObjectIds = ["108"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_DAEA_TOWN_7",
                OverrideType =
                    "name=moon_pot;type=P1_BANDIT_POT_S;ql=SI_FALSE,MOON_DAEA_TOWN_7;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_DAEA_TOWN_7|particle_emitter,highlighter,stop",
            },
        },
        ["p1_daea_blacksmith"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676371,
                HintWhenLoaded = true,
                ObjectIds = ["97"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5364] = [["JUMP_TO,LAMP_GET+-1,IF_TRUE|ITEM_HAVE_COUNT,32,1;", ""], ["the <#00ffff>crank lamp</color>", "%APPlayer%<#00ffff>%APItem%</color>"]],
                    [5365] = [["a Crank Lamp", "%APPlayer%%APItem%"]],
                    [5366] = [["ITEM_add,32,1;GO,LAMP_GET", "FILE_MARK_AP,AP_DAEA_BLACKSMITH_LAMP|recycle,shop_lamp"]],
                },
                GISIdentifier = "AP_DAEA_BLACKSMITH_LAMP",
                OverrideType =
                    "profile=item,%ItemId%;speech=DSHOP_LAMP;shiny;use_all_bright;floating;spacing=right,0.1;name=shop_lamp",
            },
            new Check
            {
                ArchipelagoId = 7676372,
                HintWhenLoaded = true,
                ObjectIds = ["85"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5367] = [["JUMP_TO,BAT3_GET+-1,IF_TRUE|ITEM_HAVE,int_list(8);", ""],
                              ["a very strong and powerful <#00ffff>steel bat</color>", "%APPlayer/a %very strong and powerful <#00ffff>%APItem%</color>"]],
                    [5368] = [["a Steel Bat", "%APPlayer%%APItem%"]],
                    [5369] = [["ITEM_add,8,1;GO,BAT3_GET", "FILE_MARK_AP,AP_DAEA_BLACKSMITH_BAT|recycle,shop_bat"]],
                },
                GISIdentifier = "AP_DAEA_BLACKSMITH_BAT",
                OverrideType =
                    "profile=item,%ItemId%;speech=DSHOP_BAT;shiny;use_all_bright;floating;spacing=right,0.1;name=shop_bat",
            },
            new Check
            {
                ArchipelagoId = 7676373,
                HintWhenLoaded = true,
                ObjectIds = ["84"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5370] = [["JUMP_TO,ARMOR3_GET+-1,IF_TRUE|ITEM_HAVE,int_list(12);", ""],
                              ["that <#00ffff>jade hauberk</color>", "%APPlayer%<#00ffff>%APItem%</color>"]],
                    [5371] = [["a Jade Hauberk", "%APPlayer%%APItem%"]],
                    [5372] = [["ITEM_add,12,1;GO,ARMOR3_GET", "FILE_MARK_AP,AP_DAEA_BLACKSMITH_ARMOR|recycle,shop_armor"]],
                },
                GISIdentifier = "AP_DAEA_BLACKSMITH_ARMOR",
                OverrideType =
                    "profile=item,%ItemId%;speech=DSHOP_ARMOR;shiny;use_all_bright;floating;spacing=right,0.1;name=shop_armor",
            },
            new Check
            {
                ArchipelagoId = 7676374,
                HintWhenLoaded = true,
                ObjectIds = ["83"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5373] = [["JUMP_TO,CROSSBOW_GET+-1,IF_TRUE|ITEM_HAVE_COUNT,37,1;", ""],
                              ["a <#00ffff>civilian crossbow</color>", "%APPlayer%<#00ffff>%APItem%</color>"]],
                    [5374] = [["a Civilian Crossbow", "%APPlayer%%APItem%"]],
                    [5375] = [["ITEM_add,37,1;GO,CROSSBOW_GET", "FILE_MARK_AP,AP_DAEA_BLACKSMITH_BOW|recycle,shop_bow"]],
                },
                GISIdentifier = "AP_DAEA_BLACKSMITH_BOW",
                OverrideType =
                    "profile=item,%ItemId%;speech=DSHOP_BOW;shiny;use_all_bright;floating;spacing=right,0.1;name=shop_bow",
            },
            new Check
            {
                ArchipelagoId = 7676375,
                HintWhenLoaded = true,
                ObjectIds = ["86"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5376] = [["JUMP_TO,FISHPOLE_GET+-1,IF_TRUE|ITEM_HAVE_COUNT,40,1;", ""],
                              ["the <#00ffff>fishing rod</color>", "%APPlayer%<#00ffff>%APItem%</color>"]],
                    [5377] = [["a Fishing Rod", "%APPlayer%%APItem%"]],
                    [5378] = [["ITEM_add,40,1;GO,FISHPOLE_GET", "FILE_MARK_AP,AP_DAEA_BLACKSMITH_ROD|recycle,shop_rod"]],
                },
                GISIdentifier = "AP_DAEA_BLACKSMITH_ROD",
                OverrideType =
                    "profile=item,%ItemId%;speech=DSHOP_ROD;shiny;use_all_bright;floating;spacing=right,0.1;name=shop_rod",
            },
        },
        ["p1_daea_house"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676377,
                ObjectIds = ["203"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5206] = [["ITEM_HAVE_COUNT,66,3", "ITEM_HAVE_COUNT,66,3;GIS,AP_HINT,%APId%"],
                              ["60 R", "%APPlayer%%APItem% and a bowl of my scrumptious homemade soup"]],
                    [5208] = [["It seems I don't have 60 R", "It seems I've run out of soup"],
                              ["I've got 40 R", "I've only got %APPlayer%%APItem%"]],
                    [5209] = [["40 R", "%APPlayer%%APItem%"]],
                    [5210] = [["40 R", "%APPlayer%%APItem%"]],
                    [5212] = [["|money_adjust,P1_RAI,40", ""]],
                },
                GISIdentifier = "DAEA_MONEY_5",
                OverrideType =
                    "name=house_lady;profile=daea_woman;voice=woman,1;behavior=path,37,45;sort=fg_tiles,-1;speech=D_HOUSE_QUEST,D_HOUSE_QUEST+1",
            },
            new Check
            {
                ArchipelagoId = 7676378,
                ObjectIds = ["1-MS gift"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4939] = [["rocks", "thingamabobs"]],
                },
                GISIdentifier = "MOON_DAEA_TOWN_5",
                OverrideType =
                    "FILE_MARK_SI,MOON_DAEA_TOWN_5,true",
            },
        },
        ["p1_daea_01_alley"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676379,
                ObjectIds = ["21"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_DAEA_TOWN_1",
                OverrideType =
                    "name=moon_pot;type=P1_BANDIT_POT_S;ql=SI_FALSE,MOON_DAEA_TOWN_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_DAEA_TOWN_1|particle_emitter,highlighter,stop",
            },
            new Check
            {
                ArchipelagoId = 7676380,
                ObjectIds = ["23"],
                IsKeyItem = false,
                GISIdentifier = "AP_DAEA_MOUSE_1",
                OverrideType =
                    "name=mouse2;type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DAEA_MOUSE_1;instruction=tmx(16/22)",
            },
        },
        ["p1_daea_dorm"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676381,
                ObjectIds = ["186"],
                IsKeyItem = true,
                GISIdentifier = "DAEA_MONEY_3",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$DAEA_MONEY_3;ql=SI_FALSE,DAEA_MONEY_3",
            },
        },
        ["p1_daea_storage"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676382,
                ObjectIds = ["156"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_DAEA_1",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_DAEA_1;ql=SI_FALSE,REGEN_DAEA_1",
            },
            new Check
            {
                ArchipelagoId = 7676383,
                ObjectIds = ["157"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_DAEA_2",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_DAEA_2;ql=SI_FALSE,REGEN_DAEA_2",
            },
            new Check
            {
                ArchipelagoId = 7676384,
                ObjectIds = ["159"],
                IsKeyItem = false,
                GISIdentifier = "AP_DAEA_MOUSE_2",
                OverrideType =
                    "name=mouse2;type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DAEA_MOUSE_2;instruction=tmx(-1/13)",
            },
        },
        ["p1_daea_02"] = new List<Check>
        {
            new Check // TODO: modify so Bo is always there?
            {
                ArchipelagoId = 7676385,
                ObjectIds = ["9-won race"],
                IsKeyItem = true,
                GISIdentifier = "BO_QUEST_3",
                OverrideType =
                    "FILE_MARK_SI,BO_QUEST_3,true|FILE_MARK_OC,bo_temp",
            },
            new Check
            {
                ArchipelagoId = 7676393,
                ObjectIds = ["7-troupe heart"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_DAEA_3",
                OverrideType =
                    "FILE_MARK_SI,HEART_DAEA_3,true",
            },
            new Check
            {
                ArchipelagoId = 7676394,
                ObjectIds = ["238"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [1356] = [["money_adjust,P1_RAI,35|", ""]],
                },
                GISIdentifier = "REGEN_TROUPE",
                OverrideType =
                    "name=forte;profile=horn;voice=man,1;speech=FORTE_HARMO_6;behavior=action_only;face_right",
            },
            new Check
            {
                ArchipelagoId = 7676411,
                ObjectIds = ["247"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_DAEA_6",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_DAEA_6;ql=SI_FALSE,REGEN_DAEA_6",
            },
        },
        ["p1_daea_restaurant"] = new List<Check>
        {
            new Check // TODO: 5129 & 5154 dialogue resets for other items after buying one
            {
                ArchipelagoId = 7676386,
                ObjectIds = ["157"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    // Regular
                    [5129] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Deli Sandwich", "%APPlayer%%APItem%"]],
                    [5131] = [["The <#00ffff>deli sandwich</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [5132] = [["a Deli Sandwich", "%APPlayer%%APItem%"]],
                    [5133] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,46,1;", ""],
                        ["ITEM_add,46,1", "FILE_MARK_AP,AP_DAEA_BL_SANDWICH"]
                    ],
                    // Discount
                    [5154] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Deli Sandwich", "%APPlayer%%APItem%"]],
                    [5156] = [["The <#00ffff>deli sandwich</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [5157] = [["a Deli Sandwich", "%APPlayer%%APItem%"]],
                    [5158] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,46,1;", ""],
                        ["ITEM_add,46,1", "FILE_MARK_AP,AP_DAEA_BL_SANDWICH"]
                    ],
                },
                GISIdentifier = "AP_DAEA_BL_SANDWICH",
                OverrideType =
                    "name=bartender;profile=daea_bartender;voice=man,0.95;speech=LOBSTER_MENU+2;behavior=action_only;face_right;floating;spacing=right,0.2;ql=SI_FALSE,BL_DISCOUNT",
            },
            new Check // TODO: 5129 & 5154 dialogue resets for other items after buying one
            {
                ArchipelagoId = 7676387,
                ObjectIds = ["157"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    // Regular
                    [5129] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["House Soup", "%APPlayer%%APItem%"]],
                    [5134] = [["Our <#00ffff>house soup</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [5135] = [["a bottle of House Soup", "%APPlayer%%APItem%"]],
                    [5136] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,167,1;", ""],
                        ["ITEM_add,167,1", "FILE_MARK_AP,AP_DAEA_BL_SOUP"]
                    ],
                    // Discount
                    [5154] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["House Soup", "%APPlayer%%APItem%"]],
                    [5159] = [["Our <#00ffff>house soup</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [5160] = [["a bottle of House Soup", "%APPlayer%%APItem%"]],
                    [5161] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,167,1;", ""],
                        ["ITEM_add,167,1", "FILE_MARK_AP,AP_DAEA_BL_SOUP"]
                    ],
                },
                GISIdentifier = "AP_DAEA_BL_SOUP",
                OverrideType =
                    "name=bartender;profile=daea_bartender;voice=man,0.95;speech=LOBSTER_MENU+2;behavior=action_only;face_right;floating;spacing=right,0.2;ql=SI_FALSE,BL_DISCOUNT",
            },
            new Check // TODO: 5129 & 5154 dialogue resets for other items after buying one
            {
                ArchipelagoId = 7676388,
                ObjectIds = ["157"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    // Regular
                    [5129] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Blue Lobster Special", "%APPlayer%%APItem%"]],
                    [5137] = [["The <#00ffff>Blue Lobster Special</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [5138] = [["a Blue Lobster Special", "%APPlayer%%APItem%"]],
                    [5139] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,153,1;", ""],
                        ["ITEM_add,153,1", "FILE_MARK_AP,AP_DAEA_BL_SPECIAL"]
                    ],
                    // Discount
                    [5154] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Blue Lobster Special", "%APPlayer%%APItem%"]],
                    [5162] = [["The <#00ffff>Blue Lobster Special</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [5163] = [["a Blue Lobster Special", "%APPlayer%%APItem%"]],
                    [5164] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,153,1;", ""],
                        ["ITEM_add,153,1", "FILE_MARK_AP,AP_DAEA_BL_SPECIAL"]
                    ],
                },
                GISIdentifier = "AP_DAEA_BL_SPECIAL",
                OverrideType =
                    "name=bartender;profile=daea_bartender;voice=man,0.95;speech=LOBSTER_MENU+2;behavior=action_only;face_right;floating;spacing=right,0.2;ql=SI_FALSE,BL_DISCOUNT",
            },
            new Check // TODO: 5130 & 5155 dialogue resets for other items after buying one
            {
                ArchipelagoId = 7676389,
                ObjectIds = ["157"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    // Regular
                    [5130] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Milk", "%APPlayer%%APItem%"]],
                    [5140] = [["Fresh <#00ffff>milk</color>", "%APPlayer/Our %fresh <#00ffff>%APItem%</color>"]],
                    [5141] = [["a bottle of Milk", "%APPlayer%%APItem%"]],
                    [5142] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,67,1;", ""],
                        ["ITEM_add,67,1", "FILE_MARK_AP,AP_DAEA_BL_MILK"]
                    ],
                    // Discount
                    [5155] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Milk", "%APPlayer%%APItem%"]],
                    [5165] = [["Fresh <#00ffff>milk</color>", "%APPlayer/Our %fresh <#00ffff>%APItem%</color>"]],
                    [5166] = [["a bottle of Milk", "%APPlayer%%APItem%"]],
                    [5167] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,67,1;", ""],
                        ["ITEM_add,67,1", "FILE_MARK_AP,AP_DAEA_BL_MILK"]
                    ],
                },
                GISIdentifier = "AP_DAEA_BL_MILK",
                OverrideType =
                    "name=bartender;profile=daea_bartender;voice=man,0.95;speech=LOBSTER_MENU+2;behavior=action_only;face_right;floating;spacing=right,0.2;ql=SI_FALSE,BL_DISCOUNT",
            },
            new Check // TODO: 5130 & 5155 dialogue resets for other items after buying one
            {
                ArchipelagoId = 7676390,
                ObjectIds = ["157"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    // Regular
                    [5130] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Honey Brew", "%APPlayer%%APItem%"]],
                    [5143] = [["The <#00ffff>Honey Brew</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [5144] = [["a bottle of Honey Brew", "%APPlayer%%APItem%"]],
                    [5145] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,54,1;", ""],
                        ["ITEM_add,54,1", "FILE_MARK_AP,AP_DAEA_BL_HONEY"]
                    ],
                    // Discount
                    [5155] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Honey Brew", "%APPlayer%%APItem%"]],
                    [5168] = [["The <#00ffff>Honey Brew</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [5169] = [["a bottle of Honey Brew", "%APPlayer%%APItem%"]],
                    [5170] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,54,1;", ""],
                        ["ITEM_add,54,1", "FILE_MARK_AP,AP_DAEA_BL_HONEY"]
                    ],
                },
                GISIdentifier = "AP_DAEA_BL_HONEY",
                OverrideType =
                    "name=bartender;profile=daea_bartender;voice=man,0.95;speech=LOBSTER_MENU+2;behavior=action_only;face_right;floating;spacing=right,0.2;ql=SI_FALSE,BL_DISCOUNT",
            },
            new Check // TODO: 5130 & 5155 dialogue resets for other items after buying one
            {
                ArchipelagoId = 7676391,
                ObjectIds = ["157"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    // Regular
                    [5130] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Grape Juice", "%APPlayer%%APItem%"]],
                    [5146] = [["Fresh <#00ffff>grape juice</color>", "%APPlayer/Our %fresh <#00ffff>%APItem%</color>"]],
                    [5147] = [["a bottle of Grape Juice", "%APPlayer%%APItem%"]],
                    [5148] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,206,1;", ""],
                        ["ITEM_add,206,1", "FILE_MARK_AP,AP_DAEA_BL_GRAPE"]
                    ],
                    // Discount
                    [5155] = [["GIS,", "GIS,AP_HINT,%APId%|"], ["Grape Juice", "%APPlayer%%APItem%"]],
                    [5171] = [["Fresh <#00ffff>grape juice</color>", "%APPlayer/Our %fresh <#00ffff>%APItem%</color>"]],
                    [5172] = [["a bottle of Grape Juice", "%APPlayer%%APItem%"]],
                    [5173] =
                    [
                        ["JUMP_TO,LOBSTER_MENU+1,IF_FALSE|ITEM_CAN_ADD,206,1;", ""],
                        ["ITEM_add,206,1", "FILE_MARK_AP,AP_DAEA_BL_GRAPE"]
                    ],
                },
                GISIdentifier = "AP_DAEA_BL_GRAPE",
                OverrideType =
                    "name=bartender;profile=daea_bartender;voice=man,0.95;speech=LOBSTER_MENU+2;behavior=action_only;face_right;floating;spacing=right,0.2;ql=SI_FALSE,BL_DISCOUNT",
            },
        },
        ["p1_daea_02_alley_i"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676395,
                ObjectIds = ["44"],
                IsKeyItem = false,
                GISIdentifier = "AP_DAEA_MOUSE_3",
                OverrideType =
                    "name=mouse2;type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DAEA_MOUSE_3;instruction=tmx(16/22)",
            },
        },
        ["p1_daea_02_alley_ii"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676396,
                ObjectIds = ["82"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_DAEA_2",
                OverrideType =
                    "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_DAEA_2,true;ql=SI_FALSE,HEART_DAEA_2",
            },
            new Check
            {
                ArchipelagoId = 7676397,
                ObjectIds = ["106"],
                IsKeyItem = false,
                GISIdentifier = "AP_FAUN_FOUNT_OU",
                OverrideType =
                    "ql=SI_FALSE,FAUN_FOUNT_OU;remove;name=song_field;desired_song=0;GIS=common_sfx,150|FILE_MARK_SI,FAUN_FOUNT_OU,true|DELAY,2.5|GIS_PACK,2|DELAY,2.5|SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_FAUN_FOUNT_OU,pos$name(shooter)|cpart,P1_CLOUD,pos$name(shooter),intensity$-1,deviation$vec3(0.7/0.7/0.7),dir$UP,color$ffffff|common_sfx,5,pitch$1.5|DELAY,0.5|GIS_PACK,3|GIS_PACK,4",
            },
            new Check
            {
                ArchipelagoId = 7676398,
                ObjectIds = ["107"],
                IsKeyItem = false,
                GISIdentifier = "AP_FAUN_FOUNT_GE",
                OverrideType =
                    "ql=SI_FALSE,FAUN_FOUNT_GE;remove;name=song_field;desired_song=1;GIS=common_sfx,150|FILE_MARK_SI,FAUN_FOUNT_GE,true|DELAY,2.5|GIS_PACK,2|DELAY,2.5|SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_FAUN_FOUNT_GE,pos$name(shooter)|cpart,P1_CLOUD,pos$name(shooter),intensity$-1,deviation$vec3(0.7/0.7/0.7),dir$UP,color$ffffff|common_sfx,5,pitch$1.5|DELAY,0.5|GIS_PACK,3|GIS_PACK,4",
            },
            new Check
            {
                ArchipelagoId = 7676399,
                ObjectIds = ["108"],
                IsKeyItem = false,
                GISIdentifier = "AP_FAUN_FOUNT_RO",
                OverrideType =
                    "ql=SI_FALSE,FAUN_FOUNT_RO;remove;name=song_field;desired_song=2;GIS=common_sfx,150|FILE_MARK_SI,FAUN_FOUNT_RO,true|DELAY,2.5|GIS_PACK,2|DELAY,2.5|SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_FAUN_FOUNT_RO,pos$name(shooter)|cpart,P1_CLOUD,pos$name(shooter),intensity$-1,deviation$vec3(0.7/0.7/0.7),dir$UP,color$ffffff|common_sfx,5,pitch$1.5|DELAY,0.5|GIS_PACK,3|GIS_PACK,4",
            },
            new Check
            {
                ArchipelagoId = 7676400,
                ObjectIds = ["109"],
                IsKeyItem = false,
                GISIdentifier = "AP_FAUN_FOUNT_PA",
                OverrideType =
                    "ql=SI_FALSE,FAUN_FOUNT_PA;remove;name=song_field;desired_song=3;GIS=common_sfx,150|FILE_MARK_SI,FAUN_FOUNT_PA,true|DELAY,2.5|GIS_PACK,2|DELAY,2.5|SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_FAUN_FOUNT_PA,pos$name(shooter)|cpart,P1_CLOUD,pos$name(shooter),intensity$-1,deviation$vec3(0.7/0.7/0.7),dir$UP,color$ffffff|common_sfx,5,pitch$1.5|DELAY,0.5|GIS_PACK,3|GIS_PACK,4",
            },
            new Check
            {
                ArchipelagoId = 7676401,
                ObjectIds = ["110"],
                IsKeyItem = false,
                GISIdentifier = "AP_FAUN_FOUNT_BA",
                OverrideType =
                    "ql=SI_FALSE,FAUN_FOUNT_BA;remove;name=song_field;desired_song=4;GIS=common_sfx,150|FILE_MARK_SI,FAUN_FOUNT_BA,true|DELAY,2.5|GIS_PACK,2|DELAY,2.5|SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_FAUN_FOUNT_BA,pos$name(shooter)|cpart,P1_CLOUD,pos$name(shooter),intensity$-1,deviation$vec3(0.7/0.7/0.7),dir$UP,color$ffffff|common_sfx,5,pitch$1.5|DELAY,0.5|GIS_PACK,3|GIS_PACK,4",
            },
            new Check
            {
                ArchipelagoId = 7676402,
                ObjectIds = ["111"],
                IsKeyItem = false,
                GISIdentifier = "AP_FAUN_FOUNT_PH",
                OverrideType =
                    "ql=SI_FALSE,FAUN_FOUNT_PH;remove;name=song_field;desired_song=5;GIS=common_sfx,150|FILE_MARK_SI,FAUN_FOUNT_PH,true|DELAY,2.5|GIS_PACK,2|DELAY,2.5|SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_FAUN_FOUNT_PH,pos$name(shooter)|cpart,P1_CLOUD,pos$name(shooter),intensity$-1,deviation$vec3(0.7/0.7/0.7),dir$UP,color$ffffff|common_sfx,5,pitch$1.5|DELAY,0.5|GIS_PACK,3|GIS_PACK,4",
            },
            new Check // TODO: theoretically missable if you leave the room before picking up the item
            {
                ArchipelagoId = 7676403,
                ObjectIds = ["4-final money"],
                IsKeyItem = false,
                GISIdentifier = "AP_DAEA_FOUNTAIN_ALL_SONGS",
                OverrideType =
                    "CONTINUE_IF,SI_ALL_TRUE,FAUN_FOUNT_OU,FAUN_FOUNT_GE,FAUN_FOUNT_RO,FAUN_FOUNT_PA,FAUN_FOUNT_BA,FAUN_FOUNT_PH|SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DAEA_FOUNTAIN_ALL_SONGS,pos$name(shooter)|cpart,P1_CLOUD,pos$name(shooter),intensity$2,deviation$vec3(1/1/1),dir$UP,color$ffffff|common_sfx,5,pitch$1.5|common_sfx,5,pitch$0.7|DELAY,1.5|particle_emitter,highlighter,stop|light_change,faun_light,intensity$0|common_sfx,150",
            },
        },
        ["p1_daea_grocer"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676404,
                HintWhenLoaded = true,
                ObjectIds = ["47"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4964] = [["An apple <#00ffff>puff pastry</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [4965] = [["a Puff Pastry", "%APPlayer%%APItem%"]],
                    [4966] = [["JUMP_TO,DAEA_BAKER,IF_FALSE|ITEM_CAN_ADD,169,1;", ""],
                              ["ITEM_add,169,1", "FILE_MARK_AP,AP_DAEA_BAKERY_PASTRY|recycle,shop_pastry"]],
                },
                GISIdentifier = "AP_DAEA_BAKERY_PASTRY",
                OverrideType =
                    "profile=item,%ItemId%;speech=PUFF_PASTRY;spacing=left,0.2;name=shop_pastry",
            },
            new Check // TODO: item consists of multiple sprites, remove others
            {
                ArchipelagoId = 7676405,
                HintWhenLoaded = true,
                ObjectIds = ["38"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4961] = [["A pair of <#00ffff>strawberry macarons</color>", "%APPlayer/Our %<#00ffff>%APItem%</color>"]],
                    [4962] = [["2 Strawberry Macarons", "%APPlayer%%APItem%"]],
                    [4963] = [["JUMP_TO,DAEA_BAKER,IF_FALSE|ITEM_CAN_ADD,171,2;", ""],
                              ["ITEM_add,171,2", "FILE_MARK_AP,AP_DAEA_BAKERY_MACARON|recycle,shop_macaron"]],
                },
                GISIdentifier = "AP_DAEA_BAKERY_MACARON",
                OverrideType =
                    "profile=item,%ItemId%;speech=SB_MACARON;face_right;spacing=left,0.2;name=shop_macaron",
            },
            new Check
            {
                ArchipelagoId = 7676406,
                HintWhenLoaded = true,
                ObjectIds = ["39"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4958] = [["our famous <#00ffff>grape cake</color>", "%APPlayer/our %famous <#00ffff>%APItem%</color>"]],
                    [4959] = [["a slice of Grape Cake", "%APPlayer%%APItem%"]],
                    [4960] = [["JUMP_TO,DAEA_BAKER,IF_FALSE|ITEM_CAN_ADD,65,1;", ""],
                              ["ITEM_add,65,1", "FILE_MARK_AP,AP_DAEA_BAKERY_CAKE|recycle,shop_cake"]],
                },
                GISIdentifier = "AP_DAEA_BAKERY_CAKE",
                OverrideType =
                    "profile=item,%ItemId%;speech=GRAPE_CAKE;spacing=left,0.2;name=shop_cake",
            },
            new Check // TODO: item consists of multiple sprites, remove others
            {
                ArchipelagoId = 7676407,
                HintWhenLoaded = true,
                ObjectIds = ["37"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [4955] = [["<#00ffff>chocolate</color>", "%APPlayer%<#00ffff>%APItem%</color>"]],
                    [4956] = [["a box of 3 Chocolates", "%APPlayer%%APItem%"]],
                    [4957] = [["JUMP_TO,DAEA_BAKER,IF_FALSE|ITEM_CAN_ADD,68,3;", ""],
                              ["ITEM_add,68,3", "FILE_MARK_AP,AP_DAEA_BAKERY_CHOCOLATE|recycle,shop_chocolate"]],
                },
                GISIdentifier = "AP_DAEA_BAKERY_CHOCOLATE",
                OverrideType =
                    "profile=item,%ItemId%;speech=DAEA_CHOCOLATE;sort=game_objects,41;spacing=left,0.2;name=shop_chocolate",
            },
        },
        ["p1_daea_shooting_gallery"] = new List<Check>
        {
            new Check // TODO: replaced item is not shown properly
            {
                ArchipelagoId = 7676408,
                HintWhenLoaded = true,
                ObjectIds = ["130"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5545] = [["GO,GP8", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_AP,AP_DAEA_ARCHERY_1|AT_scale,duck,vec3(0/0/0),duration$0.25"]],
                },
                GISIdentifier = "AP_DAEA_ARCHERY_1",
                OverrideType =
                    "CustomAnimatedSprite;name=duck;loot=%ItemId%;sort=game_objects,14;color=ffffff",
            },
            new Check // TODO: replaced item is not shown properly
            {
                ArchipelagoId = 7676409,
                HintWhenLoaded = true,
                ObjectIds = ["131"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5547] = [["GO,GP9", "GO,5548"]],
                    [5548] = [["ITEM_add,3,1|", ""]],
                },
                GISIdentifier = "HEART_DAEA_1",
                OverrideType =
                    "CustomAnimatedSprite;name=heart;loot=%ItemId%;sort=game_objects,14;color=ffffff;ql=SI_FALSE,HEART_DAEA_1",
            },
            new Check // TODO: replaced item is not shown properly
            {
                ArchipelagoId = 7676410,
                HintWhenLoaded = true,
                ObjectIds = ["133"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5550] = [["GO,GP10", "GO,5551"]],
                    [5551] = [["ITEM_add,4,1|", ""]],
                },
                GISIdentifier = "OXY_DAEA_2",
                OverrideType =
                    "CustomAnimatedSprite;name=oxy;loot=%ItemId%;sort=game_objects,14;color=ffffff;ql=SI_FALSE,OXY_DAEA_2",
            },
        },
        ["p1_daea_tunnel_01"] = new List<Check>
        {
            // TODO: implement followup check 7676413
            // new Check
            // {
            //     ArchipelagoId = 7676412,
            //     ObjectIds = ["232"],
            //     IsKeyItem = true,
            //     FillWhenExcluded = FillMode.Always,
            //     IsNpc = true,
            //     DialogReplacements = new Dictionary<int, List<string[]>>
            //     {
            //         [5495] = [["JUMP_TO,MASTER_TERAKA,IF_TRUE|ITEM_DONT_HAVE,int_list(16);", ""]], // TODO: what to do about conditional if player has quest reward?
            //         [5491] = [["GO,5492", "GO,%BonusLine%"]],
            //         [-1] = [["GIS,FILE_MARK_AP,AP_DAEA_TERAKA"]],
            //     },
            //     GISIdentifier = "AP_DAEA_TERAKA",
            //     OverrideType =
            //         "name=teraka;profile=daea_dojo_master;speech=loop,TERAKA_AFTER,TERAKA_AFTER+2;voice=man,0.95;behavior=stand;face_right;use_all_bright;spacing=right,0.6",
            // },
            new Check
            {
                ArchipelagoId = 7676414,
                ObjectIds = ["241"],
                IsKeyItem = false,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5400] = [["GO,5401", "GIS,AP_HINT,%APId%;GO,5401"],
                              ["our <*_><i>very hot</i>,<*_> <#00ffff>spicy noodles</color>", "%APPlayer/our %<*_><i>very hot</i>,<*_> <#00ffff>%APItem%</color>"]],
                    [5401] = [["Spicy Noodles", "%APPlayer%%APItem%"]],
                    [5402] =
                    [
                        ["JUMP_TO,NOODLE_SHOP+1,IF_FALSE|ITEM_CAN_ADD,152,1;", ""],
                        ["ITEM_add,152,1", "FILE_MARK_AP,AP_DAEA_NOODLES"]
                    ],
                },
                GISIdentifier = "AP_DAEA_NOODLES",
                OverrideType =
                    "name=noodle_girl;profile=moon_woman;speech=NOODLE_SHOP+5;voice=woman,1.02;behavior=stand;use_all_bright;sort=bg_tiles,3;floating;talk_range=1.25;face_right",
            },
        },
        ["p1_daea_tunnel_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676415,
                ObjectIds = ["166"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_DAEA_3",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_DAEA_3;ql=SI_FALSE,REGEN_DAEA_3",
            },
            new Check
            {
                ArchipelagoId = 7676416,
                ObjectIds = ["167"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_DAEA_4",
                OverrideType =
                    "type=P1_CRATE_FOOD;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_DAEA_4;ql=SI_FALSE,REGEN_DAEA_4",
            },
            new Check
            {
                ArchipelagoId = 7676417,
                ObjectIds = ["160"],
                IsKeyItem = true,
                GISIdentifier = "DAEA_MONEY_4",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$DAEA_MONEY_4;ql=SI_FALSE,DAEA_MONEY_4",
            },
            new Check
            {
                ArchipelagoId = 7676418,
                ObjectIds = ["168"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_DAEA_5",
                OverrideType =
                    "type=P1_WOOD_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_DAEA_5;ql=SI_FALSE,REGEN_DAEA_5",
            },
            new Check
            {
                ArchipelagoId = 7676419,
                ObjectIds = ["1-1st ingredient reward"],
                IsKeyItem = false,
                GISIdentifier = "BASIL_1",
                OverrideType =
                    "CONTINUE_IF,SI_FALSE,BASIL_1|ITEM_remove,86,1|FILE_MARK_SI,BASIL_1,true",
            },
            new Check
            {
                ArchipelagoId = 7676420,
                ObjectIds = ["2-2nd ingredient reward"],
                IsKeyItem = false,
                GISIdentifier = "BASIL_2",
                OverrideType =
                    "CONTINUE_IF,SI_FALSE,BASIL_2|ITEM_remove,180,1|FILE_MARK_SI,BASIL_2,true",
            },
            new Check // NOTE: already implemented but not in apworld yet
            {
                ArchipelagoId = 7676421,
                ObjectIds = ["48"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5027] = [["ITEM_add,5,1|", ""]],
                },
                GISIdentifier = "MOON_DAEA_TOWN_6",
                OverrideType =
                    "name=basil;profile=daea_chef;speech=CHEF_BASIL;behavior=action_talk;spacing=left,0.5;long_talker",
            },
            new Check // NOTE: already implemented but not in apworld yet
            {
                ArchipelagoId = 7676422,
                ObjectIds = ["3-get elixir"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [5040] = [["JUMP_AT_END,5042,IF_FALSE|ITEM_CAN_ADD,187,1", ""]],
                },
                GISIdentifier = "AP_DAEA_BASIL_ELIXIR",
                OverrideType =
                    "FILE_MARK_AP,AP_DAEA_BASIL_ELIXIR|FILE_MARK_SI,BASIL_COOKING,false|DELAY,0.5|common_sfx,162",
            },
        },
        ["p1_daea_tunnel_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676423,
                ObjectIds = ["87"],
                IsKeyItem = true,
                GISIdentifier = "DAEA_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$DAEA_MONEY_1;ql=SI_FALSE,DAEA_MONEY_1",
            },
            new Check
            {
                ArchipelagoId = 7676424,
                ObjectIds = ["7-receive Ms"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_DAEA_TOWN_4",
                OverrideType =
                    "FILE_MARK_SI,MOON_DAEA_TOWN_4,true",
            },
        },
        ["p1_dungeon_10a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676425,
                ObjectIds = ["82"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_BOSS_KATASH",
                OverrideType =
                    "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_BOSS_KATASH,true;ql=SI_FALSE,HEART_BOSS_KATASH",
            },
        },
        ["p1_daea_sewers_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676492,
                ObjectIds = ["18", "19", "20", "21"],
                IsKeyItem = false,
                GISIdentifier = "AP_DAEA_SEWERS_MOUSE_1",
                OverrideType =
                    "type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DAEA_SEWERS_MOUSE_1;instruction=tmx(47/18)",
            },
        },
        ["p1_daea_sewers_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676493,
                ObjectIds = ["33"],
                IsKeyItem = true,
                GISIdentifier = "SEWER_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$SEWER_MONEY_1;ql=SI_FALSE,SEWER_MONEY_1",
            },
        },
        ["p1_daea_sewers_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676494,
                ObjectIds = ["51"],
                IsKeyItem = false,
                GISIdentifier = "AP_DAEA_SEWERS_MOUSE_2",
                OverrideType =
                    "type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DAEA_SEWERS_MOUSE_2;instruction=tmx(38/24)",
            },
            new Check
            {
                ArchipelagoId = 7676495,
                ObjectIds = ["50"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_DAEA_SEWS_1",
                OverrideType =
                    "type=P1_WOOD_S;ql=SI_FALSE,MOON_DAEA_SEWS_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_DAEA_SEWS_1",
            },
        },
        ["p1_daea_sewers_04"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676496,
                ObjectIds = ["38"],
                IsKeyItem = false,
                GISIdentifier = "AP_DAEA_SEWERS_MOUSE_3",
                OverrideType =
                    "type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DAEA_SEWERS_MOUSE_3;instruction=tmx(18/16)",
            },
        },
        ["p1_daea_sewers_05"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676497,
                ObjectIds = ["13", "14", "15", "16"],
                IsKeyItem = false,
                GISIdentifier = "AP_DAEA_SEWERS_MOUSE_4",
                OverrideType =
                    "type=p_mouse;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_DAEA_SEWERS_MOUSE_4;instruction=tmx(10/19)",
            },
            new Check
            {
                ArchipelagoId = 7676498,
                ObjectIds = ["38"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_SEWERS_1",
                OverrideType =
                    "name=heart;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_SEWERS_1,true;ql=SI_FALSE,HEART_SEWERS_1",
            },
        },
        ["p1_daea_sewers_06"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676499,
                ObjectIds = ["3-spawn moonstone"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_DAEA_SEWS_2",
                OverrideType =
                    "CONTINUE_IF,SI_FALSE,MOON_DAEA_SEWS_2|SPAWN_loot,%ItemId%,pos$name(slime1),loot_GIS_MARK_SI$MOON_DAEA_SEWS_2",
            },
        },
        ["p1_daea_sewers_09"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676500,
                ObjectIds = ["21"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_DAEA_SEWS_3",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,MOON_DAEA_SEWS_3,true;ql=SI_FALSE,MOON_DAEA_SEWS_3",
            },
        },
        ["p1_dungeon_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676501,
                ObjectIds = ["94"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_JAIL_2",
                OverrideType =
                    "name=SHINY_LOOT;type=P1_WOOD_S;ql=SI_FALSE,MOON_JAIL_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_JAIL_2",
            },
            new Check
            {
                ArchipelagoId = 7676502,
                ObjectIds = ["99"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_JAIL_LOOT_1",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_JAIL_LOOT_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_JAIL_LOOT_1",
            },
        },
        ["p1_dungeon_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676503,
                ObjectIds = ["9"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_C_1",
                OverrideType =
                    "voice=woman,1.0;profile=atai_soldierf;speech=SOLDIER_C_HELP;behavior=stand;name=soldierC;face_right;ql=SI_FALSE,SOLDIER_C_PLACED",
            },    
            new Check
            {
                ArchipelagoId = 7676504,
                ObjectIds = ["9"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_C_2",
                OverrideType =
                    "voice=woman,1.0;profile=atai_soldierf;speech=SOLDIER_C_HELP;behavior=stand;name=soldierC;face_right;ql=SI_FALSE,SOLDIER_C_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676505,
                ObjectIds = ["9"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_C_3",
                OverrideType =
                    "voice=woman,1.0;profile=atai_soldierf;speech=SOLDIER_C_HELP;behavior=stand;name=soldierC;face_right;ql=SI_FALSE,SOLDIER_C_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676506,
                ObjectIds = ["9"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_C_4",
                OverrideType =
                    "voice=woman,1.0;profile=atai_soldierf;speech=SOLDIER_C_HELP;behavior=stand;name=soldierC;face_right;ql=SI_FALSE,SOLDIER_C_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676507,
                ObjectIds = ["9"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_C_5",
                OverrideType =
                    "voice=woman,1.0;profile=atai_soldierf;speech=SOLDIER_C_HELP;behavior=stand;name=soldierC;face_right;ql=SI_FALSE,SOLDIER_C_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676508,
                ObjectIds = ["12"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_B_1",
                OverrideType =
                    "voice=man,1.0;profile=atai_soldierm;speech=SOLDIER_B_HELP;behavior=stand;name=soldierB;face_right;ql=SI_FALSE,SOLDIER_B_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676509,
                ObjectIds = ["12"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_B_2",
                OverrideType =
                    "voice=man,1.0;profile=atai_soldierm;speech=SOLDIER_B_HELP;behavior=stand;name=soldierB;face_right;ql=SI_FALSE,SOLDIER_B_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676510,
                ObjectIds = ["12"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_B_3",
                OverrideType =
                    "voice=man,1.0;profile=atai_soldierm;speech=SOLDIER_B_HELP;behavior=stand;name=soldierB;face_right;ql=SI_FALSE,SOLDIER_B_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676511,
                ObjectIds = ["12"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_B_4",
                OverrideType =
                    "voice=man,1.0;profile=atai_soldierm;speech=SOLDIER_B_HELP;behavior=stand;name=soldierB;face_right;ql=SI_FALSE,SOLDIER_B_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676512,
                ObjectIds = ["12"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_B_5",
                OverrideType =
                    "voice=man,1.0;profile=atai_soldierm;speech=SOLDIER_B_HELP;behavior=stand;name=soldierB;face_right;ql=SI_FALSE,SOLDIER_B_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676513,
                ObjectIds = ["15"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_A_1",
                OverrideType =
                    "voice=woman,1.0;profile=soldierf;speech=SOLDIER_A_HELP;behavior=stand;name=soldierA;face_right;ql=SI_FALSE,SOLDIER_A_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676514,
                ObjectIds = ["15"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_A_2",
                OverrideType =
                    "voice=woman,1.0;profile=soldierf;speech=SOLDIER_A_HELP;behavior=stand;name=soldierA;face_right;ql=SI_FALSE,SOLDIER_A_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676515,
                ObjectIds = ["15"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_A_3",
                OverrideType =
                    "voice=woman,1.0;profile=soldierf;speech=SOLDIER_A_HELP;behavior=stand;name=soldierA;face_right;ql=SI_FALSE,SOLDIER_A_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676516,
                ObjectIds = ["15"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_A_4",
                OverrideType =
                    "voice=woman,1.0;profile=soldierf;speech=SOLDIER_A_HELP;behavior=stand;name=soldierA;face_right;ql=SI_FALSE,SOLDIER_A_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676517,
                ObjectIds = ["15"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "AP_KEYCARD_A_5",
                OverrideType =
                    "voice=woman,1.0;profile=soldierf;speech=SOLDIER_A_HELP;behavior=stand;name=soldierA;face_right;ql=SI_FALSE,SOLDIER_A_PLACED",
            },
            new Check
            {
                ArchipelagoId = 7676518,
                ObjectIds = ["85"],
                IsKeyItem = true,
                GISIdentifier = "JAIL_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$JAIL_MONEY_1;ql=SI_FALSE,JAIL_MONEY_1",
            },
            new Check
            {
                ArchipelagoId = 7676519,
                ObjectIds = ["87"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_JAIL_1",
                OverrideType =
                    "type=P1_CHEST_S;ql=SI_FALSE,MOON_JAIL_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_JAIL_1",
            },
            new Check
            {
                ArchipelagoId = 7676520,
                ObjectIds = ["86"],
                IsKeyItem = true,
                GISIdentifier = "JAIL_MONEY_2",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$JAIL_MONEY_2;ql=SI_FALSE,JAIL_MONEY_2",
            },
        },
        ["p1_dungeon_03a1"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676521,
                ObjectIds = ["84"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_JAIL_LOOT_3",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_JAIL_LOOT_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_JAIL_LOOT_3",
            },
        },
        ["p1_dungeon_03a2"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676522,
                ObjectIds = ["93"],
                IsKeyItem = true,
                GISIdentifier = "JAIL_MONEY_3",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$JAIL_MONEY_3;ql=SI_FALSE,JAIL_MONEY_3",
            },
        },
        ["p1_dungeon_03c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676523,
                ObjectIds = ["10"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_JAIL_LOOT_2",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_JAIL_LOOT_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_JAIL_LOOT_2",
            },
        },
        ["p1_dungeon_04a1"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676524,
                ObjectIds = ["103"],
                IsKeyItem = false,
                GISIdentifier = "p1d_04a1egg",
                OverrideType =
                    "type=P1_WOOD_S;ql=OC_ABSENT,p1d_04a1egg;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_OC$p1d_04a1egg",
            },
            new Check
            {
                ArchipelagoId = 7676525,
                ObjectIds = ["99"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_JAIL_3",
                OverrideType =
                    "type=P1_WOOD_S;ql=SI_FALSE,MOON_JAIL_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_JAIL_3",
            },
        },
        ["p1_dungeon_04c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676526,
                ObjectIds = ["93"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_JAIL_LOOT_4",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_JAIL_LOOT_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_JAIL_LOOT_4",
            },
            new Check
            {
                ArchipelagoId = 7676527,
                ObjectIds = ["55"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_JAIL_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_JAIL_1,true;ql=SI_FALSE,OXY_JAIL_1;gravity=0",
            },
        },
        ["p1_dungeon_05d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676528,
                ObjectIds = ["25"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                IsNpc = true,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [6391] = [["the ''<#00ffff>Sonic Spear</color>''", "%APPlayer/the %''<#00ffff>%APItem%</color>''"]],
                    [6396] = [["GO,6397", "GO,%BonusLine%"]],
                    [-1] = [["GIS,FILE_MARK_SI,DUNGEON_ARC_OVER,true|black_bars_out"]]
                },
                GISIdentifier = "DUNGEON_ARC_OVER",
                OverrideType =
                    "name=thomas;voice=man,1;profile=thomas;speech=line,THOMAS_JAIL_1,THOMAS_JAIL_2;face_right",
            },
        },
        ["p1_dungeon_10b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676529,
                ObjectIds = ["63"],
                IsKeyItem = false,
                GISIdentifier = "AP_TOWER_LOOT_1A",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_TOWER_LOOT_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_TOWER_LOOT_1A",
            },
            new Check
            {
                ArchipelagoId = 7676530,
                ObjectIds = ["61"],
                IsKeyItem = false,
                GISIdentifier = "AP_TOWER_LOOT_1B",
                OverrideType =
                    "type=P1_CRATE_FOOD;ql=SI_FALSE,REGEN_TOWER_LOOT_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_TOWER_LOOT_1B",
            },
            new Check
            {
                ArchipelagoId = 7676531,
                ObjectIds = ["77"],
                IsKeyItem = false,
                GISIdentifier = "AP_TOWER_LIZARD_1",
                OverrideType =
                    "type=p_lizard;GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_TOWER_LIZARD_1;instruction=tmx(41/39),tmx(48/42),tmx(47.875/39)",
            },
        },
        ["p1_towers_00"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676532,
                ObjectIds = ["1-got guards wich"],
                IsKeyItem = false,
                DialogReplacements = new Dictionary<int, List<string[]>>
                {
                    [6448] = [["&ITEM_CAN_ADD,46,1", ""]],
                    [6449] = [["my sandwich", "%APPlayer/my %%APItem%"]],
                },
                GISIdentifier = "GOT_GUARD_WICH",
                OverrideType =
                    "FILE_MARK_SI,GOT_GUARD_WICH,true",
            },
        },
        ["p1_towers_00_ex"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676533,
                ObjectIds = ["127"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_TOWER_2",
                OverrideType =
                    "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_TOWER_2,true;ql=SI_FALSE,HEART_TOWER_2",
            },
        },
        ["p1_towers_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676534,
                ObjectIds = ["89"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_TOWER_1",
                OverrideType =
                    "type=P1_TOWER_POT_S;ql=SI_FALSE,MOON_TOWER_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_TOWER_1;use_all_bright",
            },
            new Check
            {
                ArchipelagoId = 7676535,
                ObjectIds = ["293"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_TOWER_LOOT_2",
                OverrideType =
                    "type=P1_CRATE_FOOD;use_all_bright;ql=SI_FALSE,REGEN_TOWER_LOOT_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_TOWER_LOOT_2",
            },
        },
        ["p1_towers_03"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676536,
                ObjectIds = ["277"],
                IsKeyItem = true,
                GISIdentifier = "p1_t3_r5",
                OverrideType =
                    "type=P1_TOWER_POT_L;use_all_bright;ql=OC_ABSENT,p1_t3_r5;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_OC$p1_t3_r5",
            },
            new Check
            {
                ArchipelagoId = 7676537,
                ObjectIds = ["107"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_TOWER_4",
                OverrideType =
                    "type=CHANDELIER;name=chandelier3;ql=SI_FALSE,MOON_TOWER_4;GIS=DELAY,1|SPAWN_loot,%ItemId%,pos$tmx(80.5/32),loot_GIS_MARK_SI$MOON_TOWER_4",
            },
            new Check
            {
                ArchipelagoId = 7676538,
                ObjectIds = ["286"],
                IsKeyItem = true,
                GISIdentifier = "TOWER_MONEY_1",
                OverrideType =
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$TOWER_MONEY_1;ql=SI_FALSE,TOWER_MONEY_1",
            },
            new Check
            {
                ArchipelagoId = 7676539,
                ObjectIds = ["94"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "OXY_TOWER_1",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_TOWER_1,true;ql=SI_FALSE,OXY_TOWER_1",
            },
            new Check
            {
                ArchipelagoId = 7676540,
                ObjectIds = ["285"],
                IsKeyItem = false,
                GISIdentifier = "REGEN_TOWER_LOOT_3",
                OverrideType =
                    "type=P1_TOWER_POT_S;use_all_bright;ql=SI_FALSE,REGEN_TOWER_LOOT_3;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$REGEN_TOWER_LOOT_3",
            },
        },
        ["p1_towers_04"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676541,
                ObjectIds = ["109"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "HEART_TOWER_1",
                OverrideType =
                    "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_TOWER_1,true;ql=SI_FALSE,HEART_TOWER_1",
            },
            new Check
            {
                ArchipelagoId = 7676542,
                ObjectIds = ["111"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_TOWER_2",
                OverrideType =
                    "id=%ItemId%;collected_GIS=FILE_MARK_SI,MOON_TOWER_2,true;ql=SI_FALSE,MOON_TOWER_2",
            },
            new Check
            {
                ArchipelagoId = 7676543,
                ObjectIds = ["296"],
                IsKeyItem = true,
                GISIdentifier = "TOWER_MONEY_2",
                OverrideType =
                    "type=P1_CHEST_S;use_all_bright;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$TOWER_MONEY_2;ql=SI_FALSE,TOWER_MONEY_2",
            },
        },
        ["p1_towers_05"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676544,
                ObjectIds = ["300"],
                IsKeyItem = true,
                GISIdentifier = "TOWER_MONEY_3",
                OverrideType =
                    "type=P1_TOWER_POT_L;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$TOWER_MONEY_3;ql=SI_FALSE,TOWER_MONEY_3;use_all_bright",
            },
            new Check
            {
                ArchipelagoId = 7676545,
                ObjectIds = ["291"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.StatusUpgrade,
                GISIdentifier = "MOON_TOWER_3",
                OverrideType =
                    "name=e4;type=p1_kobold;instruction=tmx(79.5/25),tmx(23/26),tmx(27/43),tmx(79.5/43);defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_TOWER_3|particle_emitter,moon_highlighter,stop",
            },
        },
        ["p1_tower_boss"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676546,
                ObjectIds = ["261"],
                IsKeyItem = false,
                GISIdentifier = "AP_TOWER_LOOT_4A",
                OverrideType =
                    "type=P1_CRATE_FOOD;use_all_bright;ql=SI_FALSE,REGEN_TOWER_LOOT_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_TOWER_LOOT_4A",
            },
            new Check
            {
                ArchipelagoId = 7676547,
                ObjectIds = ["260"],
                IsKeyItem = false,
                GISIdentifier = "AP_TOWER_LOOT_4B",
                OverrideType =
                    "type=P1_CRATE_FOOD;use_all_bright;ql=SI_FALSE,REGEN_TOWER_LOOT_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_TOWER_LOOT_4B",
            },
            new Check
            {
                ArchipelagoId = 7676548,
                ObjectIds = ["262"],
                IsKeyItem = false,
                GISIdentifier = "AP_TOWER_LOOT_4C",
                OverrideType =
                    "type=P1_CRATE_FOOD;use_all_bright;ql=SI_FALSE,REGEN_TOWER_LOOT_4;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_TOWER_LOOT_4C",
            },
            new Check
            {
                ArchipelagoId = 1,
                ObjectIds = [],
                IsKeyItem = true,
                GISIdentifier = "DEFEATED_KATASH", // TODO: not releasing
                OverrideType =
                    "",
            },
        },
    };
}