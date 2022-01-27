using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.LigtTriggerEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.current.LigtTriggerExit();
    }
}
