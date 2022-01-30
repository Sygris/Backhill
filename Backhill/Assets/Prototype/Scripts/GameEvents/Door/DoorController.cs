using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int ID;
    private Animator _myAnim;
    private void Start()
    {
        _myAnim = GetComponent<Animator>();

        GameEvents.instance.TriggerDoorOpen += OpenDoor;
        GameEvents.instance.TriggerDoorClose += CloseDoor;
    }

    private void OpenDoor(int id)
    {
        if (id == this.ID)
        {
            AudioManager.instance.PlaySound("DoorOpen", transform.position, 0.5f);
            _myAnim.SetTrigger("OpenDoor");
        }
    }

    private void CloseDoor(int id)
    {
        if (id == this.ID)
        {
            AudioManager.instance.PlaySound("DoorClose", transform.position, 0.5f);
            _myAnim.SetTrigger("CloseDoor");
        }
    }
}
