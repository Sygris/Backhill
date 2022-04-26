using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    private void Awake() { Instance = this; }

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

    public event Action<int> TriggerGameObjectTrue;
    public void ActivateGameObject(int id)
    {
        if (TriggerGameObjectTrue != null)
            TriggerGameObjectTrue(id);
    }

    public event Action<int> TriggerGameObjectFalse;
    public void DeactivateGameObject(int id)
    {
        if (TriggerGameObjectFalse != null)
            TriggerGameObjectFalse(id);
    }

    public event Action TriggerNewScene;
    public void NewScene()
    {
        if (TriggerNewScene != null)
            TriggerNewScene();
    }

    public event Action TriggerSkyboxChange;
    public void ChangeScene()
    {
        if (TriggerSkyboxChange != null)
            TriggerSkyboxChange();
    }
}
