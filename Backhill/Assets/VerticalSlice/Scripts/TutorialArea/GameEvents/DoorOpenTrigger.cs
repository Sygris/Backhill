using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] private int _triggerID;
    [SerializeField] private AudioClip _sfxTitle;
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlaySound(_sfxTitle, transform.position, 0.5f);

        GameEvents.Instance.DoorTriggerOpen(_triggerID);

        gameObject.SetActive(false);
    }
}
