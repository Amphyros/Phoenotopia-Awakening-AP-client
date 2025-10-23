using Archipelago.MultiClient.Net;

namespace PhoA_AP_client.AP;

public class APSessionContext(ArchipelagoSession session, LoginSuccessful login)
{
    public ArchipelagoSession Session { get; } = session;
    public LoginSuccessful Login { get; } = login;
}