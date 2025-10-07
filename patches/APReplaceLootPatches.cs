using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
                ""),
            CreateItemDef("Useful Archipelago Item", FindSpriteIdByName("apSpriteUseful"), "An item from another world",
                ""),
            CreateItemDef("Filler Archipelago Item", FindSpriteIdByName("apSpriteFiller"), "An item from another world",
                ""),
        ];

        ItemGridLogic.ItemOrToolDef[] originalItemOrToolDef = DB.ITEM_DEFS;
        ItemGridLogic.ItemOrToolDef[] extendedItemOrToolDef =
            new ItemGridLogic.ItemOrToolDef[originalItemOrToolDef.Length + apItems.Length];

        Array.Copy(originalItemOrToolDef, extendedItemOrToolDef, originalItemOrToolDef.Length);

        for (int i = 0; i < apItems.Length; i++) extendedItemOrToolDef[originalItemOrToolDef.Length + i] = apItems[i];

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
    private static bool Create2DPolygonColliderPrefix(ref XmlReader reader)
    {
        return HandlePossibleAPReplacementForObject(ref reader);
    }

    private static bool HandlePossibleAPReplacementForObject(ref XmlReader reader)
    {
        if (PhoaAPClient.APConnection.LocalAllLocations == null) return true;

        string activeLevelName = LevelBuildLogic.level_name;

        if (!LocationMapping.LocationMap.TryGetValue(activeLevelName, out List<Check> checks)) return true;

        string objectId = reader.GetAttribute("id");
        
        // Remove Bart's head to prevent story progression
        if (activeLevelName.ToLower() == "p1_anuri_temple_01d" && objectId == "132") return false;

        foreach (Check check in checks)
        {
            if (check.ObjectId != objectId) continue;

            if (!PhoaAPClient.APConnection.LocalAllLocations.Contains(check.ArchipelagoId)) return true;
            if (PhoaAPClient.APConnection.LocalAllLocationsChecked.Contains(check.ArchipelagoId))
                return !check.IsKeyItem;

            reader = ReplaceReader(reader, check.OverrideType);
            return true;
        }

        return true;
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPostfix] // Patch to modify check values in level GIS PACK
    private static void LoadLevelGISPackReplacementPostfix(string new_level_name)
    {
        if (!LocationMapping.LocationMap.TryGetValue(new_level_name.ToLower(), out List<Check> checks)) return;

        foreach (Check check in checks)
        {
            if (int.TryParse(check.ObjectId, out int number)) continue;

            string[] identifierArray = check.ObjectId.Split('-');
            PT2.level_builder._GIS_PAK_instruction_map[int.Parse(identifierArray[0])] = check.OverrideType;
        }
    }

    [HarmonyPatch(typeof(ItemGenerator), "SpawnLoot")]
    [HarmonyPrefix] // Patch to switch around some values in case moonstone physics apply to either the location or item
    private static bool SpawnLootMoonSwitchPrefix(ref int item_id, string collected_GIS, ref int __state)
    {
        __state = -1;

        if (collected_GIS.IsNullOrEmpty()) return true;

        if (collected_GIS.Contains("MOON") && item_id != 5)
        {
            __state = item_id;
            item_id = 5;
            return true;
        }

        if (!collected_GIS.Contains("MOON") && item_id == 5)
        {
            __state = item_id;
            item_id = 3;
        }

        return true;
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
    [HarmonyPrefix] // Patch to handle the FILE_MARK_AP instruction
    private static void GISHandleSpawnLootPrefix(ref string[] args, Vector3 spawn_position)
    {
        for (int i = 2; i < args.Length; i++)
        {
            string[] instructionArray = args[i].Split('$');
            if (instructionArray[0] != "loot_GIS_MARK_AP") continue;

            _spawnLootAPCollectedGis = "FILE_MARK_AP," + instructionArray[1] + ",true";

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
}