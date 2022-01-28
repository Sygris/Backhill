using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : MonoBehaviour
{
    private Animator _myAnim;
    private void Start()
    {
        GameEvents.current.TriggerFinalDoorOpen += FinalDoorOpen;
        GameEvents.current.TriggerFinalDoorClose += FinalDoorClose;
        _myAnim = GetComponent<Animator>();
    }

    private void FinalDoorOpen()
    {
        _myAnim.SetTrigger("DoorOpen");
    }

    private void FinalDoorClose()
    {
        _myAnim.SetTrigger("DoorClose");
    }
}
