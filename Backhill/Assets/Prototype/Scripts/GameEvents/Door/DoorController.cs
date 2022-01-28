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
        AudioManager.instance.PlaySound("DoorOpen", transform.position, 0.5f);
        _myAnim.SetTrigger("OpenDoor");
    }

    private void CloseDoor()
    {
        AudioManager.instance.PlaySound("DoorClose", transform.position, 0.5f);
        _myAnim.SetTrigger("CloseDoor");
    }
}
