using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action TriggerDoorOpen;
    public void DoorTriggerOpen()
    {
        if (TriggerDoorOpen != null)
            TriggerDoorOpen();
    }

    public event Action TriggerDoorClose;
    public void DoorTriggerClose()
    {
        if (TriggerDoorClose != null)
            TriggerDoorClose();
    }

    public event Action TriggerFinalDoorOpen;
    public void FinalDoorTriggerOpen()
    {
        if (TriggerFinalDoorOpen != null)
            TriggerFinalDoorOpen();
    }

    public event Action TriggerFinalDoorClose;
    public void FinalDoorTriggerClose()
    {
        if (TriggerFinalDoorClose != null)
            TriggerFinalDoorClose();
    }

    public event Action ToggleLightOn;
    public void LightToggleOn()
    {
        if (ToggleLightOn != null)
            ToggleLightOn();
    }

    public event Action ToggleLightOff;
    public void LightToggleOff()
    {
        if (ToggleLightOff != null)
            ToggleLightOff();
    }


}
