using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake() { instance = this; }

    public event Action<int> TriggerDoorOpen;
    public void DoorTriggerOpen(int id)
    {
        if (TriggerDoorOpen != null)
            TriggerDoorOpen(id);
    }

    public event Action<int> TriggerDoorClose;
    public void DoorTriggerClose(int id)
    {
        if (TriggerDoorClose != null)
            TriggerDoorClose(id);
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
