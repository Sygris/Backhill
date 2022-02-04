using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameObjectActive : MonoBehaviour
{
    [SerializeField] private int _triggerID;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.Instance.ActivateGameObject(_triggerID);

        gameObject.SetActive(false);
    }
}
