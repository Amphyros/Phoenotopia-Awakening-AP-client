using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Packets;

namespace PhoA_AP_client.util;

internal static class APHelpers
{
    public static bool IsConnectedToAP()
    {
        return PhoaAPClient.APConnection.Session?.RoomState?.Seed != null;
    }

    public static void SendGoalCompletedPacket()
    {
        PhoaAPClient.APConnection.Session.Socket.SendPacket(new StatusUpdatePacket
        {
            Status = ArchipelagoClientState.ClientGoal
        });
    }
}