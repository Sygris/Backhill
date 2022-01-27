using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.current.ToggleLightOn += LightsOff;
        GameEvents.current.ToggleLightOff += LightsOn;
    }

    private void LightsOff()
    {
        gameObject.SetActive(false);
    }

    private void LightsOn()
    {
        gameObject.SetActive(true);
    }
}
