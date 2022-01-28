using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorCloseTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.FinalDoorTriggerClose();
    }
}
