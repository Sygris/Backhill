using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [Tooltip("Disable game event when completed")]
    [SerializeField] private bool _destroyOnExit;
    private TriggerEventManager[] _eventManagers;

    private void Start()
    {
        _eventManagers = gameObject.GetComponents<TriggerEventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _eventManagers.Length; i++)
            _eventManagers[i].ExecuteTriggerEvent();

        if (_destroyOnExit)
            gameObject.SetActive(false);
    }
}
