using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _myAnim;
    private void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        _myAnim = GetComponent<Animator>();
    }

    private void OnDoorwayOpen()
    {
        _myAnim.SetTrigger("OpenDoor");
    }
}
