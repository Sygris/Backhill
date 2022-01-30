using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseTrigger : MonoBehaviour
{
    public int ID;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.instance.DoorTriggerClose(ID);
    }
}
