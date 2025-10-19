using System.Collections.Generic;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using PhoA_AP_client.util;

namespace PhoA_AP_client.AP;

public class DeathLinkHandler
{
    private DeathLinkService _deathLinkService;
    private bool _receivedDeathLink;
    private bool _deathLinkEnabled;

    public void CreateDeathLinkService(ArchipelagoSession session, Dictionary<string, object> slotData)
    {
        _deathLinkService = session.CreateDeathLinkService();
        _deathLinkEnabled = slotData.TryGetValue("DeathLink", out var deathLink) && (long)deathLink == 1;
        
        if (!_deathLinkEnabled) return;
        
        _deathLinkService.EnableDeathLink();
        _deathLinkService.OnDeathLinkReceived += ReceiveDeathLink;
    }

    public void DisableDeathLinkService()
    {
        _deathLinkService.OnDeathLinkReceived -= ReceiveDeathLink;
        _deathLinkService.DisableDeathLink();
    }

    public void SendDeathLink()
    {
        PhoaAPClient.Logger.LogDebug($"SendDeathLink() called: {_receivedDeathLink}");
        if (!_deathLinkEnabled) return;
        if (_receivedDeathLink)
        {
            _receivedDeathLink = false;
            return;
        }
        _deathLinkService.SendDeathLink(new DeathLink(PhoaAPClient.APConnection.Session.Players.ActivePlayer.Name));
    }

    private void ReceiveDeathLink(DeathLink deathLink)
    {
        PhoaAPClient.Logger.LogDebug("ReceiveDeathLink() called");
        if (!_deathLinkEnabled) return;
        
        if (LevelBuildLogic.level_name.Equals("game_start")) return;
        if (LevelBuildLogic.level_name.StartsWith("cutscene")) return;
        
        _receivedDeathLink = true;
        MainThreadDispatcher.RunOnMainThread(() =>
        {
            PT2.save_file.GoToGameOverScreen();
        });
    }
}