using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.LightToggleOn();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.current.LightToggleOff();
    }
}
