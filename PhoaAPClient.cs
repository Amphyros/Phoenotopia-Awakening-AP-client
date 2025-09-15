using System;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using PhoA_AP_client.AP;
using PhoA_AP_client.util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhoA_AP_client;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, "PhoA AP client", MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("PhoenotopiaAwakening.exe")]
public class PhoaAPClient : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    private static Harmony _harmony;
    public static APConnection APConnection { get; private set; }

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        var dispatcherObj = new GameObject("MainThreadDispatcher");
        DontDestroyOnLoad(dispatcherObj);
        dispatcherObj.AddComponent<MainThreadDispatcher>();

        _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        _harmony.PatchAll();
    }

    private void Start()
    {
        APConnection = new APConnection();
        APConnection.Connect("localhost", 38281, "Lenamphy");
    }

    private void OnDestroy()
    {
        APConnection.Disconnect();
    }
}