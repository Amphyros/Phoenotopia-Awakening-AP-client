using System.Collections.Generic;
using Archipelago.MultiClient.Net.Models;

namespace PhoA_AP_client.util;

public enum FillMode
{
    Never,
    StatusUpgrade,
    Always,
}

public class Check
{
    public long ArchipelagoId { get; set; }
    public string[] ObjectIds { get; set; }
    public bool IsKeyItem { get; set; }
    public FillMode FillWhenExcluded { get; set; } = FillMode.Never;
    public bool IsNpc { get; set; }
    public int? CompletionDialogId { get; set; }
    public Dictionary<int, List<string[]>> DialogReplacements { get; set; }
    public string GISIdentifier { get; set; }
    public string DifferingInGameIdentifier { get; set; }
    public string OverrideType { get; set; }
    public ScoutedItemInfo ItemInfo { get; set; }
}