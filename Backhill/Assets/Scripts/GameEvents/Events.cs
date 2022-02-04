using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Events
{
    public abstract void TriggerEvent();
    [HideInInspector] public bool IsComplete = false;
    public bool ReplayOnload = false;
}

[System.Serializable]
public class TiggerAnimation : Events
{
    public override void TriggerEvent()
    {
        IsComplete = true;
    }

    [SerializeReference] public bool lockDoor;
}

