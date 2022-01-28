using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _myAnim;
    private void Start()
    {
        GameEvents.current.TriggerDoorOpen += OpenDoor;
        GameEvents.current.TriggerDoorClose += CloseDoor;
        _myAnim = GetComponent<Animator>();
    }

    private void OpenDoor()
    {
        _myAnim.SetTrigger("OpenDoor");
    }

    private void CloseDoor()
    {
        _myAnim.SetTrigger("CloseDoor");
    }
}
