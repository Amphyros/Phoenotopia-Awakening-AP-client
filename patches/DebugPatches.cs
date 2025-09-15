using HarmonyLib;
using UnityEngine;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class DebugPatches
{
    [HarmonyPatch(typeof(ItemGenerator), "SpawnLoot")]
    [HarmonyPostfix]
    private static void SpawnLootPostFixDebug(int item_id)
    {
        PhoaAPClient.Logger.LogDebug("Loot was spawned: "+ item_id);
    }
    
    [HarmonyPatch(typeof(LootLogic), "SetAttributes")]
    [HarmonyPrefix]
    private static bool SetAttributesPrefix(int set_item_tool_id)
    {
        PhoaAPClient.Logger.LogDebug(DB.ITEM_DEFS[set_item_tool_id].item_name); 
        return true;
    }
    
    [HarmonyPatch(typeof(GaleInteracter), "_AttemptGrabbingLoot")]
    [HarmonyPrefix]
    private static bool Prefix(Collider2D loot_collider)
    {
        var component = loot_collider.GetComponent<LootLogic>();
        if (component == null) return true;
        
        PhoaAPClient.Logger.LogDebug($"{component.item_tool_id}");

        return true;
    }
    
    [HarmonyPatch(typeof(GaleInteracter), "_AttemptGrabbingLoot")]
    [HarmonyPostfix]
    private static void Postfix(Collider2D loot_collider)
    {
        var component = loot_collider.GetComponent<LootLogic>();
        if (component == null) return;

        var field = AccessTools.Field(typeof(LootLogic), "_collected_GIS_cmd");
        var locationName = (string)field.GetValue(component);
        
        PhoaAPClient.Logger.LogDebug($"Location name - old: {locationName}");
    }
    
    [HarmonyPatch(typeof(SaveDataHandler), "save")]
    [HarmonyPostfix]
    public static void Postfix(string dataToSave, string filename)
    {
        PhoaAPClient.Logger.LogDebug(dataToSave);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPostfix]
    private static void LoadLevelPostfix(string new_level_name)
    {
        PhoaAPClient.Logger.LogDebug($"Level loaded: {new_level_name}");
    }
}