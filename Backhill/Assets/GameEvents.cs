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

    public event Action onDoorwayTriggerEnter;
    public void DoorwayTriggerEnter()
    {
        if (onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter();
        }
    }

    public event Action onLightTriggerEnter;
    public void LigtTriggerEnter()
    {
        if (onLightTriggerEnter != null)
        {
            onLightTriggerEnter();
        }
    }

    public event Action onLightTriggerExit;
    public void LigtTriggerExit()
    {
        if (onLightTriggerExit != null)
        {
            onLightTriggerExit();
        }
    }
}
