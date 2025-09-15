using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhoA_AP_client.util;

public class MainThreadDispatcher : MonoBehaviour
{
    private static readonly Queue<Action> actions = new();

    public static void RunOnMainThread(Action action)
    {
        lock (actions)
            actions.Enqueue(action);
    }

    private void Update()
    {
        lock (actions)
        {
            while (actions.Count > 0)
                actions.Dequeue().Invoke();
        }
    }
}