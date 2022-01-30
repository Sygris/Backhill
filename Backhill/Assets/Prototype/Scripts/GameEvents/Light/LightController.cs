using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.instance.ToggleLightOn += LightsOff;
        GameEvents.instance.ToggleLightOff += LightsOn;
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
