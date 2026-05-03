using System.Collections.Generic;
using Archipelago.MultiClient.Net.Models;

namespace PhoA_AP_client.util;

public class DialogPatch
{
    public Dictionary<int, List<string[]>> DialogReplacements { get; set; }
    public long ArchipelagoId { get; set; }
    public ScoutedItemInfo ScoutedItem { get; set; }
    public bool IsFromThisWorld { get; set; }
    public int? PostCompletionDialogId { get; set; }
}