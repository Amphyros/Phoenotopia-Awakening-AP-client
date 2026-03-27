using System.Collections.Generic;

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
                GISIdentifier = "clem_gave_potato",
                OverrideType =
                    "name=clem;profile=digger;voice=man,1;speech=CLEM_CUSTOM;behavior=action_only",
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
        },
        ["p1_panselo_house_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676068,
                ObjectIds = ["31"],
                IsKeyItem = true,
                IsNpc = true,
                GISIdentifier = "NANA_MUFFIN",
                OverrideType =
                    "all_bright;name=nana;voice=woman,0.94;profile=nana;behavior=action_talk;spacing=left,0.5;sort=fg_tiles,4;speech=NANA_CUSTOM,NANA",
            },
            new Check
            {
                ArchipelagoId = 7676077,
                ObjectIds = ["30"],
                IsKeyItem = true,
                IsNpc = true,
                GISIdentifier = "GOT_KITER_LEFTOVERS",
                OverrideType =
                    "name=kiter;profile=kiter;speech=KITER_CUSTOM;behavior=action_talk;spacing=right,0.5;face_right",
            },
            new Check
            {
                ArchipelagoId = 7676078,
                ObjectIds = ["30"],
                IsKeyItem = true,
                IsNpc = true,
                GISIdentifier = "HELPED_KITER",
                OverrideType =
                    "name=kiter;profile=kiter;speech=KITER_CUSTOM;behavior=action_talk;spacing=right,0.5;face_right",
            },
            new Check
            {
                ArchipelagoId = 7676090,
                ObjectIds = ["69"],
                IsKeyItem = true,
                IsNpc = true,
                GISIdentifier = "KID_LUNCH",
                OverrideType =
                    "name=amanda;voice=woman,1.1;profile=amanda;behavior=path,25,22;speech=AMANDA_2A_CUSTOM,AMANDA_2A+6;sort=fg_tiles,-1",
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
                GISIdentifier = "TAO_PRESENT",
                OverrideType =
                    "profile=tao;name=merchant;voice=man,1.02;speech=TAO,TAO_CUSTOM;behavior=stand",
            },
            new Check
            {
                ArchipelagoId = 7676072,
                ObjectIds = ["50"],
                IsKeyItem = false,
                GISIdentifier = "PANSELO_SHOP_EGG",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_1;speech=MERCHANT_TAO_EGG_CUSTOM",
            },
            new Check
            {
                ArchipelagoId = 7676073,
                ObjectIds = ["48"],
                IsKeyItem = false,
                GISIdentifier = "PANSELO_SHOP_MILK",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_2;speech=MERCHANT_TAO_MILK_CUSTOM",
            },
            new Check
            {
                ArchipelagoId = 7676074,
                ObjectIds = ["52"],
                IsKeyItem = false,
                GISIdentifier = "PANSELO_SHOP_POTATO",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_3;speech=MERCHANT_TAO_POTATO_CUSTOM",
            },
            // TODO: GISIdentifiers of the following checks are not unique
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
                GISIdentifier = "shelby_gave_herb",
                OverrideType =
                    "name=shelby;voice=WOMAN,1.15;profile=shelby;behavior=stand;spacing=auto,0.25;speech=SHELBY_FOREST_CUSTOM;all_bright",
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
                    "type=P1_ANURI_CERAMIC_POT_S;destroyed_GIS=SPAWN_loot,,%ItemId%,loot_GIS_MARK_SI$REGEN_LAST,true;ql=SI_FALSE,REGEN_LAST",
            },
            new Check
            {
                ArchipelagoId = 7676008,
                ObjectIds = ["130"],
                IsKeyItem = true,
                FillWhenExcluded = FillMode.Always,
                IsNpc = true,
                GISIdentifier = "AP_DOKI_ALEX_GIFT",
                OverrideType =
                    "name=alex2;face_right;spacing=left,0.5;voice=man,1.1;profile=alex;behavior=action_only;speech=ALEX_GIVES_SLINGSHOT_CUSTOM",
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
                GISIdentifier = "seth_liz",
                OverrideType =
                    "name=seth;face_right;voice=man,1.15;profile=seth;behavior=stand;speech=SETH_FOREST_CUSTOM,SETH_FOREST",
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
                GISIdentifier = "GEO_TICKET_1",
                OverrideType =
                    "name=geo_bot;voice=robot,1;profile=green_robot;behavior=stand;speech=GEO_ROBOT_01_CUSTOM",
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
                ArchipelagoId = 1,
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
                GISIdentifier = "AP_PLANTO_2",
                OverrideType =
                    "name=planto;profile=planto;voice=man,0.85;speech=PLANTO_P2_CUSTOM;sort=bg_tiles,-1;behavior=action_only;ql=SI_FALSE,PLANTO_2",
            },
        },
        ["p1_sunflower_road_02a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676106,
                ObjectIds = ["63"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "HONEY_SHOP_BUN",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_1;floating;use_all_bright;speech=HONEY_BUN_CUSTOM;spacing=right,0.1",
            },
            new Check
            {
                ArchipelagoId = 7676107,
                ObjectIds = ["58"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "HONEY_SHOP_BREW",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_2;floating;use_all_bright;speech=HONEY_BREW_CUSTOM;spacing=right,0.1",
            },
            new Check
            {
                ArchipelagoId = 7676108,
                ObjectIds = ["64"],
                IsKeyItem = false,
                IsNpc = true,
                GISIdentifier = "HONEY_SHOP_DROP",
                OverrideType =
                    "profile=item,%ItemId%;name=shop_3;floating;use_all_bright;speech=HONEY_DROP_CUSTOM;spacing=right,0.1",
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
                GISIdentifier = "GEO_TICKET_2",
                OverrideType =
                    "name=geo_bot;voice=robot,1;profile=green_robot;behavior=stand;speech=GEO_ROBOT_02_CUSTOM;sort=fg_tiles,1",
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
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$FILE_MARK_SI,ATELO_MONEY_1;ql=SI_FALSE,ATELO_MONEY_1",
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
                    "type=P1_CHEST_S;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$FILE_MARK_OC,ATELO_TEMP_1;ql=OC_ABSENT,ATELO_TEMP_1",
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
            }
        }
    };
}