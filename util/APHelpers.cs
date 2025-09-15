namespace PhoA_AP_client.util;

internal static class APHelpers
{
    public static bool IsConnectedToAP()
    {
        if (PhoaAPClient.APConnection?.Session == null ||
            !PhoaAPClient.APConnection.Session.Socket.Connected) return false;
        return true;
    }
}