using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameObjectDeactive : MonoBehaviour
{
    [SerializeField] private int _triggerID;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.Instance.DeactivateGameObject(_triggerID);

        gameObject.SetActive(false);
    }
}
