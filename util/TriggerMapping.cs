using System.Collections.Generic;

namespace PhoA_AP_client.util;

public class TriggerMapping
{
    public static readonly Dictionary<string, List<int>> TriggerMap = new()
    {
        ["p1_duri_forest_06"] = new List<int>
        {
            6, // Zoom out on Anuri Temple
            124, // Alex star hunt cutscene
            134, // Leave trigger during Alex's cutscene
            //254, // Alex's gear ring explaination (Turns out this trigger is triggers a level state)
        },
        ["p1_anuri_temple_boss"] = new List<int> // Not triggers technically but these are the twigs above century toad
        {
            15,
            16,
            17,
            18,
            19,
            20,
            21,
            22,
            23,
            24,
            25,
        }
    };
}