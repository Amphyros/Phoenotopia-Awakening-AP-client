using HarmonyLib;
using PhoA_AP_client.util;
using WebSocketSharp;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
internal sealed class APConnectionManagementPatches
{
    private static string _sessionId;

    [HarmonyPatch(typeof(OpeningMenuLogic), "Initialize")]
    [HarmonyPrefix]
    private static void OpeningLevelLogicInitializePrefix()
    {
        PhoaAPClient.Logger.LogDebug("Opening menu");
        SaveFile.file_0_string_data = null;
        SaveFile.file_1_string_data = null;
        SaveFile.file_2_string_data = null;
        SaveFile.file_3_string_data = null;

        if (!APHelpers.IsConnectedToAP())
        {
            _sessionId = null;
            PhoaAPClient.Logger.LogDebug("No active connection found... Trying to establish connection");
            PhoaAPClient.APConnection.EndConnectionProcess();
            PhoaAPClient.APConnection.Connect();
        }

        if (!APHelpers.IsConnectedToAP())
        {
            PhoaAPClient.Logger.LogWarning("Unable to connect. Loading default saves");
            return;
        }

        _sessionId =
            $"P{PhoaAPClient.APConnection.Session.ConnectionInfo.Slot}-{PhoaAPClient.APConnection.Session.RoomState.Seed}";
    }

    [HarmonyPatch(typeof(SaveFile), "_NS_LoadData")]
    [HarmonyPrefix]
    private static void NSLoadDataPrefix(ref string file_name)
    {
        PhoaAPClient.Logger.LogDebug("Loading save data");
        if (_sessionId.IsNullOrEmpty()) return;

        if (file_name.Contains("file_"))
            file_name = _sessionId + file_name;

        PhoaAPClient.Logger.LogDebug($"New file_name: {file_name}");
    }

    [HarmonyPatch(typeof(SaveDataHandler), "save")]
    [HarmonyPrefix]
    private static void SavePrefix(string dataToSave, ref string filename)
    {
        if (_sessionId.IsNullOrEmpty()) return;
        if (!filename.Contains("file_")) return;

        if (filename == "file_0") SaveFile.file_0_string_data = dataToSave;
        if (filename == "file_1") SaveFile.file_1_string_data = dataToSave;
        if (filename == "file_2") SaveFile.file_2_string_data = dataToSave;
        if (filename == "file_3") SaveFile.file_3_string_data = dataToSave;

        filename = _sessionId + filename;
    }
}