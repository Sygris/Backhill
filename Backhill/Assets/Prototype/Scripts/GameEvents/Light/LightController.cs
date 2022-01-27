using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.current.onLightTriggerEnter += LightsOff;
        GameEvents.current.onLightTriggerExit += LightsOn;
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
