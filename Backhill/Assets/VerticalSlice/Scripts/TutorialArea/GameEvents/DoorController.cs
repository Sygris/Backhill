using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private int _doorID;
    private Animator _myAnim;
    private void Start()
    {
        _myAnim = GetComponent<Animator>();

        GameEvents.Instance.TriggerDoorOpen += OpenDoor;
        GameEvents.Instance.TriggerDoorClose += CloseDoor;
    }

    private void OpenDoor(int id)
    {
        if (id == _doorID)
            _myAnim.SetTrigger("OpenDoor");
    }

    private void CloseDoor(int id)
    {
        if (id == _doorID)
            _myAnim.SetTrigger("CloseDoor");
    }
}
