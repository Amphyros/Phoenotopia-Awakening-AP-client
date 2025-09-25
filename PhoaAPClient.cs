using BepInEx;
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
    internal static new ManualLogSource Logger;
    private static Harmony _harmony;
    public static APConnection APConnection { get; private set; }
    
    private int counter = 0;

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
        APConnection.Connect();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PT2.sound_g.PlayGlobalCommonSfx(counter, 1f, 1f, 2);
            Logger.LogDebug($"Sound played: {counter}");
            counter++;
        }
    }

    private void OnDestroy()
    {
        APConnection.Disconnect();
    }
}