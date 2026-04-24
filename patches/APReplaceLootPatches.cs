using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using HarmonyLib;
using PhoA_AP_client.util;
using UnityEngine;
using WebSocketSharp;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class APReplaceLootPatches
{
    private static string _spawnLootAPCollectedGis;
    private static List<string> _ExtractedPuzzleGisCmds = [];
    private static readonly string[] _levelsWithItemDisplays = ["p1_atai_shooting_gallery"];

    [HarmonyPatch(typeof(PT2), "Initialize")]
    [HarmonyPostfix] // Patch to add AP item sprite
    private static void InitializePostfix()
    {
        Sprite[] sprites =
        [
            LoadSpriteFromResource("apSprite.png"),
            LoadSpriteFromResource("apSpriteUseful.png"),
            LoadSpriteFromResource("apSpriteFiller.png"),
        ];

        Sprite[] originalSpriteLib = PT2.sprite_lib.all_item_sprites;
        Sprite[] extendedSpriteLib = new Sprite[originalSpriteLib.Length + sprites.Length];

        Array.Copy(originalSpriteLib, extendedSpriteLib, originalSpriteLib.Length);

        for (int i = 0; i < sprites.Length; i++) extendedSpriteLib[originalSpriteLib.Length + i] = sprites[i];

        PT2.sprite_lib.all_item_sprites = extendedSpriteLib;
    }

    [HarmonyPatch(typeof(DB), "_LoadItemDefinitions")]
    [HarmonyPostfix] // Patch to add AP item to item DB
    private static void LoadItemDefinitionsPostfix()
    {
        ItemGridLogic.ItemOrToolDef[] apItems =
        [
            CreateItemDef("Progressive Archipelago Item", FindSpriteIdByName("apSprite"), "An item from another world",
                "FREE"),
            CreateItemDef("Useful Archipelago Item", FindSpriteIdByName("apSpriteUseful"), "An item from another world",
                "FREE"),
            CreateItemDef("Filler Archipelago Item", FindSpriteIdByName("apSpriteFiller"), "An item from another world",
                "FREE"),
        ];

        ItemGridLogic.ItemOrToolDef[] originalItemOrToolDef = DB.ITEM_DEFS;
        ItemGridLogic.ItemOrToolDef[] extendedItemOrToolDef =
            new ItemGridLogic.ItemOrToolDef[originalItemOrToolDef.Length + apItems.Length];

        Array.Copy(originalItemOrToolDef, extendedItemOrToolDef, originalItemOrToolDef.Length);

        for (int i = 0; i < apItems.Length; i++) extendedItemOrToolDef[originalItemOrToolDef.Length + i] = apItems[i];

        extendedItemOrToolDef = ConvertToKeyItems(extendedItemOrToolDef);

        DB.ITEM_DEFS = extendedItemOrToolDef;
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_HandleLoot")]
    [HarmonyPrefix] // Patch to replace loot items with the items placed by AP
    private static bool HandleLootPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_HandleLiftableObject")]
    [HarmonyPrefix] // Patch to replace values of liftable items to spawn AP items
    private static bool HandleLiftableObjectPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_HandleEnemy")]
    [HarmonyPrefix] // Patch to replace values of enemies to spawn AP items
    private static bool HandleEnemyPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_HandleAONC")]
    [HarmonyPrefix]
    private static bool HandleAONCPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_CreateRectangleCollider")]
    [HarmonyPrefix]
    private static bool CreateRectangleColliderPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_HandlePuzzleObject")]
    [HarmonyPrefix]
    private static bool HandlePuzzleObjectPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_HandleNPC")]
    [HarmonyPrefix]
    private static bool HandleNPCPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_HandleTrigger")]
    [HarmonyPrefix]
    private static bool HandleTriggerPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_CreateSongField")]
    [HarmonyPrefix]
    private static bool CreateSongFieldPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    private static bool HandlePossibleAPReplacementForObject(ref XmlReader reader)
    {
        if (PhoaAPClient.APConnection.ItemHandler?.LocalAllLocations == null) return true;

        string activeLevelName = LevelBuildLogic.level_name;

        if (!LocationMapping.LocationMap.TryGetValue(activeLevelName, out List<Check> checks)) return true;

        string objectId = reader.GetAttribute("id");

        foreach (Check check in checks)
        {
            if (!check.ObjectIds.Contains(objectId)) continue;

            if (!PhoaAPClient.APConnection.ItemHandler.LocalAllLocations.Contains(check.ArchipelagoId) &&
                check.FillWhenExcluded < PhoaAPClient.APConnection.ItemHandler.FillMode)
                return true;

            bool isChecked =
                PhoaAPClient.APConnection.ItemHandler.LocalAllLocationsChecked.Contains(check.ArchipelagoId);
            bool isNpcOrStateDependentCheck = check.IsNpc || check.OverrideType.Contains("profile=WEAK_ROCK");

            switch (isChecked)
            {
                case true when isNpcOrStateDependentCheck && check.IsKeyItem:
                    PT2.GIS_ProcessInstructions($"FILE_MARK_SI,{check.GISIdentifier},true", Vector3.zero);
                    continue; // Continues to check if the npc has more checks
                // BUG: This breaks when an NPC holds another check that's not a key item.
                case true:
                    return !check.IsKeyItem;
                default:
                    reader = ReplaceReader(reader, check.OverrideType);
                    return true;
            }
        }

        return true;
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "__CreateAnimatedTile")]
    [HarmonyPrefix] // Patch to manually replace the sprite of item displays related to checks
    private static void CreateAnimatedTilePrefix(ref XmlReader reader)
    {
        string activeLevelName = LevelBuildLogic.level_name;
        if (!_levelsWithItemDisplays.Contains(activeLevelName)) return;

        if (!LocationMapping.LocationMap.TryGetValue(activeLevelName.ToLower(), out List<Check> checks)) return;

        foreach (Check check in checks)
        {
            if (!check.ObjectIds.Contains(reader.GetAttribute("id"))) continue;

            reader = ReplaceLootIdInReader(reader, check.ItemInfo.ItemId);
        }
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPostfix] // Patch to modify check values in level GIS PACK
    private static void LoadLevelGISPackReplacementPostfix(string new_level_name)
    {
        if (PhoaAPClient.APConnection.ItemHandler?.LocalAllLocations == null) return;
        if (!LocationMapping.LocationMap.TryGetValue(new_level_name.ToLower(), out List<Check> checks)) return;

        foreach (Check check in checks)
        {
            if (!PhoaAPClient.APConnection.ItemHandler.LocalAllLocations.Contains(check.ArchipelagoId)) continue;
            if (PhoaAPClient.APConnection.ItemHandler.LocalAllLocationsChecked.Contains(check.ArchipelagoId)) continue;

            foreach (string objectId in check.ObjectIds)
            {
                if (int.TryParse(objectId, out _)) continue;

                string[] identifierArray = objectId.Split('-');
                PT2.level_builder._GIS_PAK_instruction_map[int.Parse(identifierArray[0])] = check.OverrideType;
            }
        }
    }

    [HarmonyPatch(typeof(ItemGenerator), "SpawnLoot")]
    [HarmonyPrefix] // Patch to spawn the appropriate version of an upgradable item
    private static void SpawnLootUpgradableItemPrefix(ref int item_id)
    {
        if (item_id is >= 293 and <= 299)
        {
            item_id = (int)PhoaAPClient.APConnection.ItemHandler.HandleUpgradableItems(item_id);
            PhoaAPClient.Logger.LogDebug($"New id: {item_id}");
        }
    }

    [HarmonyPatch(typeof(NpcLogic), "InitializeNpc")]
    [HarmonyPrefix] // Patch to render the appropriate sprite of an upgradable item in shops
    private static void InitializeNpcUpgradableItemPrefix(ref string profile)
    {
        if (!profile.Contains("item,")) return;

        string[] splittedProfile = profile.Split(',');
        if (!profile.Contains("item,") && splittedProfile.Length == 2) return;

        int item_id = int.Parse(splittedProfile[1]);
        if (item_id is < 293 or > 299) return;

        item_id = (int)PhoaAPClient.APConnection.ItemHandler.HandleUpgradableItems(item_id);
        profile = $"item,{item_id}";
    }

    [HarmonyPatch(typeof(ItemGenerator), "SpawnLoot")]
    [HarmonyPrefix] // Patch to switch around some values in case moonstone physics apply to either the location or item
    private static void SpawnLootMoonSwitchPrefix(ref int item_id, string collected_GIS, ref int __state)
    {
        __state = -1;

        if (collected_GIS.IsNullOrEmpty()) return;

        bool vanillaItemHasHurtbox = collected_GIS.Contains("MOON") || collected_GIS.Contains("ANURI_KEY") ||
                                     collected_GIS.Contains("BANDIT_KEY") ||
                                     collected_GIS.Contains("THOMAS_BLUE_KEY") ||
                                     collected_GIS.Contains("THOMAS_RED_KEY") || collected_GIS.Contains("MONEY");
        bool itemToSpawnHasHurtbox = item_id is 5 or 98 or 108 or 111 or 115 or 116;

        // If vanilla item is moonstone, but item to be spawned is not a moonstone
        if (vanillaItemHasHurtbox && !itemToSpawnHasHurtbox)
        {
            __state = item_id;
            item_id = 5;
            return;
        }

        // If vanilla items is NOT moonstone, but item to spawn IS a moonstone
        if (!vanillaItemHasHurtbox && itemToSpawnHasHurtbox)
        {
            __state = item_id;
            item_id = 3;
        }
    }

    [HarmonyPatch(typeof(ItemGenerator), "SpawnLoot")]
    [HarmonyPostfix] // Postfix follow-up of SpawnLootPrefix()
    private static void SpawnLootMoonSwitchPostfix(ref LootLogic __result, int __state)
    {
        if (__state == -1) return;

        __result.item_tool_id = __state;
        __result._sprite.sprite = PT2.sprite_lib.all_item_sprites[DB.ITEM_DEFS[__state].graphic_id];
        PhoaAPClient.Logger.LogDebug("A moon switch occured");
    }

    [HarmonyPatch(typeof(PT2), "_GIS_HandleSpawnLoot")]
    [HarmonyPrefix] // Patch to handle different FILE_MARK_ instructions for spawned loot
    private static void GISHandleSpawnLootPrefix(ref string[] args, Vector3 spawn_position)
    {
        for (int i = 2; i < args.Length; i++)
        {
            string[] instructionArray = args[i].Split('$');
            string type = instructionArray[0];

            if (!type.StartsWith("loot_GIS_MARK_")) continue;

            string suffix = type.Substring(type.LastIndexOf('_') + 1);

            _spawnLootAPCollectedGis = $"FILE_MARK_{suffix},{instructionArray[1]},true";

            string nonRefArg = args[i];
            args = args.Where(item => item != nonRefArg).ToArray();
        }
    }

    [HarmonyPatch(typeof(ItemGenerator), "SpawnLoot")]
    [HarmonyPrefix] // Follow-up patch of GISHandleSpawnLootPrefix() to handle FILE_MARK_AP instruction
    private static void SpawnLootAPGISPrefix(ref string collected_GIS)
    {
        if (_spawnLootAPCollectedGis.IsNullOrEmpty()) return;

        collected_GIS = _spawnLootAPCollectedGis;
        _spawnLootAPCollectedGis = null;
    }

    [HarmonyPatch(typeof(AnimalLifeSmallLogic), "_Lizard_AttackResult")]
    [HarmonyPrefix]
    private static void LizardAttackResultPrefix(AnimalLifeSmallLogic __instance)
    {
        ProcessAPItemAnimalLifeSmall(__instance);
    }

    [HarmonyPatch(typeof(AnimalLifeSmallLogic), "_Mouse_AttackResult")]
    [HarmonyPrefix]
    private static void MouseAttackResultPrefix(AnimalLifeSmallLogic __instance)
    {
        ProcessAPItemAnimalLifeSmall(__instance);
    }

    [HarmonyPatch(typeof(AnimalLifeSmallLogic), "_Scorp_AttackResult")]
    [HarmonyPrefix]
    private static void ScorpAttackResultPrefix(AnimalLifeSmallLogic __instance)
    {
        ProcessAPItemAnimalLifeSmall(__instance);
    }

    private static void ProcessAPItemAnimalLifeSmall(AnimalLifeSmallLogic __instance)
    {
        var traverse = Traverse.Create(__instance);
        string gisCmd = traverse.Field<string>("_GIS_cmd").Value;

        if (gisCmd.IsNullOrEmpty() || (!gisCmd.Contains("loot_GIS_MARK_AP") && !gisCmd.Contains("FILE_MARK_AP")))
            return;

        string[] instructionArray = gisCmd.Split('|');
        StringBuilder strippedInstructions = new StringBuilder();
        List<string> extractedGisCmds = [];
        foreach (string instruction in instructionArray)
        {
            if (instruction.Contains("loot_GIS_MARK_AP"))
            {
                extractedGisCmds.Add(instruction);
                continue;
            }

            if (instruction.Contains("SPAWN_pickup") || instruction.Contains("FILE_MARK_AP"))
            {
                extractedGisCmds.Add(instruction);
                continue;
            }

            strippedInstructions.Append(instruction);
        }

        _ExtractedPuzzleGisCmds.Add(string.Join("|", extractedGisCmds.ToArray()));

        traverse.Field<string>("_GIS_cmd").Value = strippedInstructions.ToString();
    }

    [HarmonyPatch(typeof(CarcassLogic), "_Exit")]
    [HarmonyPrefix]
    private static void CarcassLogicExitPrefix(CarcassLogic __instance)
    {
        if (_ExtractedPuzzleGisCmds.Count <= 0) return;

        var traverse = Traverse.Create(__instance);
        var transform = traverse.Field<Transform>("_transform").Value;
        traverse.Field<string>("_loot_drop_string").Value = null;
        PT2.GIS_ProcessInstructions(_ExtractedPuzzleGisCmds[0], transform.position);
        _ExtractedPuzzleGisCmds.RemoveAt(0);
    }

    private static Sprite LoadSpriteFromResource(string resourceName, float pixelsPerUnit = 16f)
    {
        string resourceNameFromAssembly = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceNames()
            .FirstOrDefault(n => n.EndsWith(resourceName));

        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceNameFromAssembly);

        if (stream == null) return null;

        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);

        Texture2D texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        texture.LoadImage(buffer);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.Apply();

        Sprite sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            pixelsPerUnit
        );
        sprite.name = resourceName.Split('.')[0];

        return sprite;
    }

    private static int FindSpriteIdByName(string spriteName)
    {
        Sprite[] sprites = PT2.sprite_lib.all_item_sprites;
        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i] != null && sprites[i].name == spriteName) return i;
        }

        return -1;
    }

    private static ItemGridLogic.ItemOrToolDef CreateItemDef(string name, int graphicId, string flavorText,
        string commands)
    {
        ItemGridLogic.ItemOrToolDef itemDef = default(ItemGridLogic.ItemOrToolDef);
        itemDef.item_name = name;
        itemDef.graphic_id = graphicId;
        itemDef.flavor_text = flavorText;
        itemDef.classification = ItemGridLogic.ITEM_CLASS.ITEM;
        itemDef.commands = commands;
        itemDef.hold_limit = 999;
        itemDef.price = 0;
        return itemDef;
    }

    private static ItemGridLogic.ItemOrToolDef[] ConvertToKeyItems(
        ItemGridLogic.ItemOrToolDef[] extendedItemOrToolDef)
    {
        int[] lunarArtifactIds = [88, 92, 99, 100, 144, 145, 155, 156, 157, 158, 159, 160];

        foreach (int lunarArtifactId in lunarArtifactIds)
        {
            extendedItemOrToolDef[lunarArtifactId].commands += ";FREE;NO_DISCARD";
        }

        return extendedItemOrToolDef;
    }

    private static XmlReader ReplaceReader(XmlReader originalXmlReader, string newType)
    {
        string outerXml = originalXmlReader.ReadOuterXml();
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(outerXml);
        XmlElement elem = doc.DocumentElement;
        elem.SetAttribute("type", newType);
        XmlReader newReader = new XmlNodeReader(elem);
        newReader.Read();
        return newReader;
    }

    private static XmlReader ReplaceLootIdInReader(XmlReader originalXmlReader, long lootId)
    {
        string outerXml = originalXmlReader.ReadOuterXml();
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(outerXml);
        XmlElement elem = doc.DocumentElement;
        string type = elem.GetAttribute("type");

#pragma warning disable Harmony003
        string updatedType = System.Text.RegularExpressions.Regex.Replace(type, @"(?<=loot=)\d+", lootId.ToString());
#pragma warning restore Harmony003
        elem.SetAttribute("type", updatedType);

        XmlReader newReader = new XmlNodeReader(elem);
        newReader.Read();

        return newReader;
    }
}