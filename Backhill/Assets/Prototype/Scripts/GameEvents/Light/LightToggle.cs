using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.instance.LightToggleOn();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.instance.LightToggleOff();
    }
}
