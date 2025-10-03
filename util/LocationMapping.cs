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
                ObjectId = "55",
                IsKeyItem = true,
                GISIdentifier = "HEART_PANSELO_1",
                OverrideType = "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_PANSELO_1,true;ql=SI_FALSE,HEART_PANSELO_1",
            },
        },
        ["p1_panselo_house_ruth"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676001,
                ObjectId = "142",
                IsKeyItem = true,
                GISIdentifier = "HEART_PANSELO_2",
                OverrideType = "id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_PANSELO_2,true;ql=SI_FALSE,HEART_PANSELO_2",
            },
        },
        ["p1_ex_forest_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676002,
                ObjectId = "138",
                IsKeyItem = true,
                GISIdentifier = "OXY_FOREST_1",
                OverrideType = "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,OXY_FOREST_1,true;ql=SI_FALSE,OXY_FOREST_1",
            },
        },
        ["p1_ex_forest_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676003,
                ObjectId = "67",
                IsKeyItem = true,
                GISIdentifier = "MOON_FIELD_1",
                OverrideType = "type=P1_BANDIT_POT_S;ql=SI_FALSE,MOON_FIELD_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FIELD_1",
            },
        },
        ["p1_ex_fields_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676004,
                ObjectId = "54",
                IsKeyItem = true,
                GISIdentifier = "MOON_FIELD_2",
                OverrideType = "type=P1_BANDIT_POT_S;ql=SI_FALSE,MOON_FIELD_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FIELD_2;name=pot",
            },
        },
        ["biome_flowers_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676005,
                ObjectId = "41",
                IsKeyItem = true,
                GISIdentifier = "MOON_MAP_2",
                OverrideType = "name=beez;type=p1_bee;instruction=tmx(-1/14),tmx(128/14);defeated_GIS=particle_emitter,bee_highlighter,stop|common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_MAP_2",
            },
        },
        ["p1_duri_forest_03a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676006,
                ObjectId = "204",
                IsKeyItem = true,
                GISIdentifier = "MOON_DOKI_1",
                OverrideType = "type=P1_WOOD_S;ql=SI_FALSE,MOON_DOKI_1;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_DOKI_1",
            },
        },
        ["p1_duri_forest_06"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676007,
                ObjectId = "257",
                IsKeyItem = true,
                GISIdentifier = "D_FOREST_MONEY_3",
                OverrideType = "name=scale_fish;instruction=FISH_M;type=fish;defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$D_FOREST_MONEY_3|particle_emitter,highlighter2,stop;ql=ALWAYS_TRUE"
            },
            new Check
            {
                ArchipelagoId = 7676008,
                ObjectId = "4-Alex gives slingshot",
                IsKeyItem = true,
                GISIdentifier = "AP_DOKI_ALEX_GIFT",
                OverrideType = "FILE_MARK_AP,AP_DOKI_ALEX_GIFT"
            },
        },
        ["p1_anuri_temple_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676009,
                ObjectId = "36",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_1_COLLECTED",
                OverrideType = "name=SHINY_BONE1;type=P1_ANURI_CORPSE;GIS=particle_emitter,highlighter,stop|SPAWN_loot,%ItemId%,loot_GIS_PACK$5;ql=SI_FALSE,ANURI_KEY_1_COLLECTED;hp=4",
            },
        },
        ["p1_anuri_temple_02a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676010,
                ObjectId = "16",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_3_COLLECTED",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_3_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_3_COLLECTED,true;name=SHINY_LOOT",
            },
        },
        ["p1_anuri_temple_02c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676011,
                ObjectId = "37",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_5_COLLECTED",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_5_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_5_COLLECTED,true;name=SHINY_LOOT",
            },
        },
        ["p1_anuri_temple_04d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676012,
                ObjectId = "25",
                IsKeyItem = true,
                GISIdentifier = "OXY_ANURI_1",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,OXY_ANURI_1;collected_GIS=FILE_MARK_SI,OXY_ANURI_1,true",
            },
        },
        ["p1_anuri_temple_04c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676013,
                ObjectId = "42",
                IsKeyItem = true,
                GISIdentifier = "MOON_ANURI_6",
                OverrideType = "type=P1_ANURI_CERAMIC_POT_S;ql=SI_FALSE,MOON_ANURI_6;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ANURI_6",
            },
        },
        ["p1_anuri_temple_04b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676014,
                ObjectId = "13",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_7_COLLECTED",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_7_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_7_COLLECTED,true|light_change,pearlstone_light,intensity$0;name=FOCUS_PT",
            },
        },
        ["p1_anuri_temple_01b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676015,
                ObjectId = "51",
                IsKeyItem = true,
                GISIdentifier = "HEART_ANURI_1",
                OverrideType = "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_SI,HEART_ANURI_1,true;ql=SI_FALSE,HEART_ANURI_1",
            },
        },
        ["p1_anuri_temple_01a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676016,
                ObjectId = "64",
                IsKeyItem = true,
                GISIdentifier = "AP_ANURI_1",
                OverrideType = "type=P1_ANURI_CERAMIC_POT_L;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_AP$AP_ANURI_1",
            },
        },
        ["p1_anuri_temple_03b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676017,
                ObjectId = "61",
                IsKeyItem = true,
                GISIdentifier = "MOON_ANURI_2",
                OverrideType = "type=P1_ANURI_CERAMIC_POT_L;ql=SI_FALSE,MOON_ANURI_2;destroyed_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_ANURI_2",
            },
        },
        ["p1_anuri_temple_03c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676018,
                ObjectId = "22",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_4_COLLECTED",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_4_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_4_COLLECTED,true;name=SHINY_LOOT",
            },
        },
        ["p1_anuri_temple_03a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676019,
                ObjectId = "5",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_2_COLLECTED",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_2_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_2_COLLECTED,true;name=SHINY_LOOT",
            },
        },
        ["p1_anuri_temple_05"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676022,
                ObjectId = "98",
                IsKeyItem = true,
                GISIdentifier = "MOON_ANURI_1",
                OverrideType = "ql=SI_FALSE,MOON_ANURI_1;profile=WEAK_ROCK;layers_to_erase=3,5;destroyed_by_bombs;particle_color=c3bb77;tiles_to_erase=tmx(48/30),tmx(50/31);destroyed_GIS=common_sfx,150|SPAWN_loot,%ItemId%,pos$tmx(49/31),loot_GIS_PACK$3"
            },
            new Check
            {
                ArchipelagoId = 7676023,
                ObjectId = "57",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_10_COLLECTED",
                OverrideType = "name=slime1;type=p1_slimeboss;defeated_GIS=SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$ANURI_KEY_10_COLLECTED|particle_emitter,highlighter,stop;ql=SI_FALSE,ANURI_KEY_10_COLLECTED"
            },
        },
        ["p1_anuri_temple_05a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676020,
                ObjectId = "25",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_6_COLLECTED",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_6_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_6_COLLECTED,true;name=SHINY_LOOT",
            },
        },
        ["p1_anuri_temple_05b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676021,
                ObjectId = "84",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_9_COLLECTED",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_9_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_9_COLLECTED,true;name=SHINY_LOOT",
            },
        },
        ["p1_anuri_temple_01c"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676024,
                ObjectId = "12",
                IsKeyItem = true,
                GISIdentifier = "MOON_ANURI_3",
                OverrideType = "id=%ItemId%;name=MOON_STONE;collected_GIS=FILE_MARK_SI,MOON_ANURI_3,true;ql=SI_FALSE,MOON_ANURI_3"
            },
        },
        ["p1_anuri_temple_01d"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676025,
                ObjectId = "191",
                IsKeyItem = true,
                GISIdentifier = "MOON_FISH_3",
                OverrideType = "name=moon_fish;face_right;initial_behavior=STATIC;type=fish;instruction=FISH_M;defeated_GIS=common_sfx,150|SPAWN_loot,%ItemId%,loot_GIS_MARK_SI$MOON_FISH_3|particle_emitter,fish_highlighter,stop;ql=ALWAYS_TRUE",
            }, // Check somehow doesn't appear. Even in vanilla
        },
        ["p1_anuri_temple_06a"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676026,
                ObjectId = "71",
                IsKeyItem = true,
                GISIdentifier = "ANURI_KEY_8_COLLECTED",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,ANURI_KEY_8_COLLECTED;collected_GIS=FILE_MARK_SI,ANURI_KEY_8_COLLECTED,true;name=FOCUS_PT",
            },
        },
        ["p1_anuri_temple_06b"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676027,
                ObjectId = "68",
                IsKeyItem = true,
                GISIdentifier = "AP_ANURI_2",
                OverrideType = "name=FOCUS_PT;id=%ItemId%;collected_GIS=FILE_MARK_AP,AP_ANURI_2,true",
            },
        },
        ["p1_panselo_village_01"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676028,
                ObjectId = "21",
                IsKeyItem = false,
                GISIdentifier = "P1_PV_dandy1",
                OverrideType = "id=%ItemId%;ql=OC_ABSENT,P1_PV_dandy1;collected_GIS=FILE_MARK_OC,P1_PV_dandy1;gravity=0"
            }
        },
        ["p1_panselo_village_02"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 7676029,
                ObjectId = "9",
                IsKeyItem = false,
                GISIdentifier = "P1_PV_dandy2",
                OverrideType = "id=%ItemId%;ql=OC_ABSENT,P1_PV_dandy2;collected_GIS=FILE_MARK_OC,P1_PV_dandy2;gravity=0"
            }
        },
        ["p1_anuri_temple_pod"] = new List<Check>
        {
            new Check
            {
                ArchipelagoId = 1,
                ObjectId = "233",
                IsKeyItem = true,
                GISIdentifier = "GOT_ANURI_POD",
                OverrideType = "id=%ItemId%;ql=SI_FALSE,GOT_ANURI_POD;collected_GIS=FILE_MARK_SI,GOT_ANURI_POD,true|light_change,urn_light,intensity$0,t$2|common_sfx,186",
            },
        },
    };
}