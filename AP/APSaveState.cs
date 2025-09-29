using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace PhoA_AP_client.AP;

public static class APSaveState
{
    public static List<long> CollectedItems { get; private set; } = new();

    public static void LoadFromSaveString([CanBeNull] string apitemsString)
    {
        PhoaAPClient.Logger.LogDebug("LoadFromSaveString called.");
        if (string.IsNullOrEmpty(apitemsString))
        {
            CollectedItems.Clear();
            return;
        }

        CollectedItems = apitemsString
            .Replace("APITEMS|", "")
            .Split('|')
            .Where(x => long.TryParse(x, out _))
            .Select(long.Parse)
            .ToList();
    }
}