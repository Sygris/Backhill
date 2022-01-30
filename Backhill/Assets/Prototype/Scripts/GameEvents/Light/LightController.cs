using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.Instance.ToggleLightOn += LightsOff;
        GameEvents.Instance.ToggleLightOff += LightsOn;
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
