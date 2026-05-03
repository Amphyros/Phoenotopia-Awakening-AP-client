using HarmonyLib;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class DebugPatches
{
    // private static string _message = "";

    [HarmonyPatch(typeof(ItemGenerator), "SpawnLoot")]
    [HarmonyPostfix]
    private static void SpawnLootPostFixDebug(int item_id)
    {
        PhoaAPClient.Logger.LogDebug("Loot was spawned: " + item_id);
    }

    [HarmonyPatch(typeof(LootLogic), "SetAttributes")]
    [HarmonyPostfix]
    private static void SetAttributesPrefix(int set_item_tool_id)
    {
        if (set_item_tool_id >= DB.ITEM_DEFS.Length)
            return;
        PhoaAPClient.Logger.LogDebug(DB.ITEM_DEFS[set_item_tool_id].item_name);
    }

    [HarmonyPatch(typeof(LevelBuildLogic), "_LoadLevel")]
    [HarmonyPostfix]
    private static void LoadLevelPostfix(string new_level_name)
    {
        PhoaAPClient.Logger.LogDebug($"Level loaded: {new_level_name}");
    }

    // [HarmonyPatch(typeof(DirectorLogic), "Update")]
    // [HarmonyPrefix]
    // private static void UpdatePrefix(DirectorLogic __instance)
    // {
    //     string newMessage = $"goto_id: {__instance.goto_id}";
    //     if (newMessage == _message) return;
    //     _message = newMessage;
    //     PhoaAPClient.Logger.LogDebug(_message);
    // }
}