using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhoA_AP_client.util;

public class MainThreadDispatcher : MonoBehaviour
{
    private static readonly Queue<Action> Actions = new();
    private static readonly Queue<Action> NonMapLevelActions = new();
    private static readonly Queue<Action> PerFrameActions = new();

    public static void RunOnMainThread(Action action)
    {
        lock (Actions)
            Actions.Enqueue(action);
    }

    public static void EnqueueNonMapLevelAction(Action action)
    {
        lock (NonMapLevelActions)
            NonMapLevelActions.Enqueue(action);
    }

    public static void RunPerFrameActionOnMainThread(Action action)
    {
        lock (PerFrameActions)
            PerFrameActions.Enqueue(action);
    }

    private void Update()
    {
        lock (Actions)
        {
            while (Actions.Count > 0)
                Actions.Dequeue().Invoke();
        }

        lock (NonMapLevelActions)
        {
            while (!LevelBuildLogic.level_name.ToLower().Contains("world_map") && NonMapLevelActions.Count > 0)
                NonMapLevelActions.Dequeue().Invoke();
        }

        lock (PerFrameActions)
        {
            if (PerFrameActions.Count > 0)
                PerFrameActions.Dequeue().Invoke();
        }
    }
}