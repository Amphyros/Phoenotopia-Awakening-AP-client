using HarmonyLib;

namespace PhoA_AP_client.patches;

[HarmonyPatch]
public class APDeathLinkPatches
{
    [HarmonyPatch(typeof(SaveFile), "GoToGameOverScreen")]
    [HarmonyPrefix]
    private static void GoToGameOverScreenPrefix()
    {
        PT2.director.CloseAllDialoguers();
        PhoaAPClient.APConnection.DeathLinkHandler.SendDeathLink();
    }
}