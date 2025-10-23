using System;
using System.Threading;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using PhoA_AP_client.util;

namespace PhoA_AP_client.AP;

public class APConnection(string host, int port, string slot, string password)
{
    public APSessionContext SessionContext { get; private set; }
    public DeathLinkHandler DeathLinkHandler { get; private set; }
    public ItemHandler ItemHandler { get; private set; }
    private Thread _connectionThread;
    private bool _keepTrying;

    public bool Connect()
    {
        PhoaAPClient.Logger.LogDebug("Connect() called");
        if (APHelpers.IsConnectedToAP()) return false;
        try
        {
            ArchipelagoSession session = ArchipelagoSessionFactory.CreateSession(host, port);

            LoginResult result =
                session.TryConnectAndLogin(
                    "Phoenotopia: Awakening",
                    slot,
                    ItemsHandlingFlags.AllItems,
                    password: password
                );
            if (!result.Successful)
            {
                var failure = (LoginFailure)result;
                foreach (var error in failure.Errors)
                    PhoaAPClient.Logger.LogError($"Failed to connect: {error}. Retrying in 5s...");
                return false;
            }

            var loginSuccess = (LoginSuccessful)result;
            PhoaAPClient.Logger.LogInfo($"Succesfully connected to AP server as slot: {loginSuccess.Slot}");

            SessionContext = new APSessionContext(session, loginSuccess);
            SessionContext.Session.Socket.SocketClosed += OnSocketClosed;
            DeathLinkHandler = new DeathLinkHandler(SessionContext);
            ItemHandler = new ItemHandler(SessionContext);

            MainThreadDispatcher.RunOnMainThread(() =>
            {
                PT2.sound_g.PlayGlobalCommonSfx(126, 1f, 1f, 2);
                PT2.display_messages.DisplayMessage("Connected to Archipelago!",
                    DisplayMessagesLogic.MSG_TYPE.GALE_PLUS_STATUS);
            });

            return true;
        }
        catch (Exception ex)
        {
            PhoaAPClient.Logger.LogError($"Could not connect: {ex.Message}. Retrying in 5s...");
        }

        return false;
    }
    
    private void ConnectAsync()
    {
        EndConnectionProcess();
        _keepTrying = true;
        _connectionThread = new Thread(() =>
        {
            while (_keepTrying)
            {
                if (Connect())
                    return;

                try
                {
                    Thread.Sleep(5000);
                }
                catch (ThreadInterruptedException)
                {
                    return;
                }
            }
        });

        _connectionThread.IsBackground = true;
        _connectionThread.Start();
    }

    private void OnSocketClosed(string reason)
    {
        MainThreadDispatcher.RunOnMainThread(() =>
        {
            PT2.sound_g.PlayGlobalCommonSfx(157, 1f, 1f, 2);
            PT2.display_messages.DisplayMessage("Lost connection with a AP server",
                DisplayMessagesLogic.MSG_TYPE.GALE_MINUS_STATUS);
        });
        PhoaAPClient.Logger.LogWarning($"Lost connection with the AP server: {reason}. Trying to Reconnect...");
        Disconnect();
        ConnectAsync();
    }

    public void Disconnect()
    {
        _keepTrying = false;
        if (SessionContext?.Session == null) return;

        ItemHandler.RemoveEventHandlers();
        ItemHandler = null;
        DeathLinkHandler.RemoveEventHandlers();
        DeathLinkHandler = null;
        SessionContext.Session.Socket.Disconnect();
        SessionContext.Session.Socket.SocketClosed -= OnSocketClosed;
        SessionContext = null;
    }

    public void EndConnectionProcess()
    {
        _keepTrying = false;
        if (_connectionThread is { IsAlive: true })
        {
            _connectionThread.Interrupt();
            _connectionThread.Join();
        }

        _connectionThread = null;
    }
}