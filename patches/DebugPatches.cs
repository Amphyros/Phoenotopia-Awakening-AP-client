using HarmonyLib;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class DebugPatches
{
    [HarmonyPatch(typeof(ItemGenerator), "SpawnLoot")]
    [HarmonyPostfix]
    private static void SpawnLootPostFixDebug(int item_id)
    {
        PhoaAPClient.Logger.LogDebug("Loot was spawned: " + item_id);
    }

    [HarmonyPatch(typeof(LootLogic), "SetAttributes")]
    [HarmonyPrefix]
    private static bool SetAttributesPrefix(int set_item_tool_id)
    {
        PhoaAPClient.Logger.LogDebug(DB.ITEM_DEFS[set_item_tool_id].item_name);
        return true;
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