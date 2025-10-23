using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using PhoA_AP_client.util;

namespace PhoA_AP_client.AP;

public class DeathLinkHandler
{
    private readonly APSessionContext _sessionContext;
    private DeathLinkService _deathLinkService;
    private bool _receivedDeathLink;
    private bool _deathLinkEnabled;

    public DeathLinkHandler(APSessionContext sessionContext)
    {
        _sessionContext = sessionContext;
        CreateDeathLinkService();
    }

    public void RemoveEventHandlers()
    {
        _deathLinkService.DisableDeathLink();
        _deathLinkService.OnDeathLinkReceived -= ReceiveDeathLink;
    }

    private void CreateDeathLinkService()
    {
        _deathLinkService = _sessionContext.Session.CreateDeathLinkService();
        _deathLinkEnabled = _sessionContext.Login.SlotData.TryGetValue("DeathLink", out var deathLink) && (long)deathLink == 1;
        
        if (!_deathLinkEnabled) return;
        
        _deathLinkService.EnableDeathLink();
        _deathLinkService.OnDeathLinkReceived += ReceiveDeathLink;
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
        _deathLinkService.SendDeathLink(new DeathLink(_sessionContext.Session.Players.ActivePlayer.Name));
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