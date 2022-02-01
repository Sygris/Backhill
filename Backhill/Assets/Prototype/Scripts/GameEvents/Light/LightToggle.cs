using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.Instance.LightToggleOff();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.Instance.LightToggleOn();
        GetComponent<BoxCollider>().enabled = false;
    }
}
