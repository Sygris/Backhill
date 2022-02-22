using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] private bool _destroyOnExit;
    private TriggerEventManager _eventManager;

    private void Start()
    {
        _eventManager = GetComponent<TriggerEventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _eventManager.ExecuteTriggerEvent();

        if (_destroyOnExit)
            gameObject.SetActive(false);
    }
}
