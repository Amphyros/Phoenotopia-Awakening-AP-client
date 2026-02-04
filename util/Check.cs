using Archipelago.MultiClient.Net.Models;

namespace PhoA_AP_client.util;

public class Check
{
    public long ArchipelagoId { get; set; }
    public string[] ObjectIds { get; set; }
    public bool IsKeyItem { get; set; }
    public bool IsNpc { get; set; }
    public string GISIdentifier { get; set; }
    public string OverrideType { get; set; }
    public ScoutedItemInfo ItemInfo { get; set; }
}