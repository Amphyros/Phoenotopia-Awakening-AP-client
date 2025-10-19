using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using PhoA_AP_client.AP;
using PhoA_AP_client.util;
using UnityEngine;

namespace PhoA_AP_client;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, "PhoA AP client", MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("PhoenotopiaAwakening.exe")]
public class PhoaAPClient : BaseUnityPlugin
{
    internal new static ManualLogSource Logger;
    private static Harmony _harmony;
    public static APConnection APConnection { get; private set; }

    private ConfigEntry<string> _host;
    private ConfigEntry<int> _port;
    private ConfigEntry<string> _slot;
    private ConfigEntry<string> _password;

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        _host = Config.Bind("Archipelago", "host", "localhost",
            "AP server host. Usually either archipelago.gg or multiworld.gg unless hosted locally.");
        _port = Config.Bind("Archipelago", "port", 38281, "Port number.");
        _slot = Config.Bind("Archipelago", "slot", "Player", "Slot/Player name.");
        _password = Config.Bind("Archipelago", "password", "", "Optional password.");

        var dispatcherObj = new GameObject("MainThreadDispatcher");
        DontDestroyOnLoad(dispatcherObj);
        dispatcherObj.AddComponent<MainThreadDispatcher>();

        APConnection = new APConnection(_host.Value, _port.Value, _slot.Value, _password.Value);

        _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        _harmony.PatchAll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }

    private void OnDestroy()
    {
        APConnection.Disconnect();
    }
}