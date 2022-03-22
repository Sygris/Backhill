using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEvent : MonoBehaviour
{
    [Tooltip("Disable game event when completed")]
    [SerializeField] private bool _destroyOnExit;
    private ToggleEventManager _eventManager;

    private void Start()
    {
        _eventManager = GetComponent<ToggleEventManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        _eventManager.ExecuteToggleEvent();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_destroyOnExit)
            gameObject.SetActive(false);
    }
}
