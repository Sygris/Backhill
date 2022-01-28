using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorOpenTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.FinalDoorTriggerOpen();
    }
}
