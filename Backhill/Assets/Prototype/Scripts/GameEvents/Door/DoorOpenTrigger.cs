using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    public int ID;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.instance.DoorTriggerOpen(ID);
    }
}
