using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhoA_AP_client.util;

public class MainThreadDispatcher : MonoBehaviour
{
    private static readonly Queue<Action> Actions = new();
    private static readonly Queue<Action> NonMapLevelActions = new();
    private static readonly Queue<Action> PerFrameActions = new();
    private static Action _stalledSaveAction;

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

    public static void SetStalledSaveAction(Action action)
    {
        _stalledSaveAction = action;
    }

    public static int ActionsLeftInPerFrameQueue()
    {
        lock (PerFrameActions)
            return PerFrameActions.Count;
    }

    private void Update()
    {
        RunQueuedActions();
        RunNonMapLevelActions();
        ProcessPerFrameQueue();
    }

    private static void RunQueuedActions()
    {
        lock (Actions)
        {
            while (Actions.Count > 0)
                Actions.Dequeue().Invoke();
        }
    }

    private static void RunNonMapLevelActions()
    {
        lock (NonMapLevelActions)
        {
            while (!LevelBuildLogic.level_name.ToLower().Contains("world_map") && NonMapLevelActions.Count > 0)
                NonMapLevelActions.Dequeue().Invoke();
        }
    }

    private static void ProcessPerFrameQueue()
    {
        lock (PerFrameActions)
        {
            if (PerFrameActions.Count > 0)
            {
                PerFrameActions.Dequeue().Invoke();
                return;
            }

            if (_stalledSaveAction == null) return;

            Action stalledSave = _stalledSaveAction;
            _stalledSaveAction = null;
            stalledSave.Invoke();
        }
    }
}