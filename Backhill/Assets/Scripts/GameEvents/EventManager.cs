using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public enum ColliderMenu
    {
        Trigger,
        Toggle
    }; public ColliderMenu ColliderType;

    [SerializeField] private string _eventName;
    [SerializeField] private GameObject _eventLocation;

    public void MakeEventCollider()
    {
        GameObject _collider = new GameObject(ColliderType.ToString() + ": " + _eventName);

        if (_eventLocation != null)
            _collider.transform.position = _eventLocation.transform.position;

        _collider.transform.parent = transform;
        _collider.AddComponent<BoxCollider>();
        _collider.GetComponent<BoxCollider>().isTrigger = true;

        switch (ColliderType)
        {
            case ColliderMenu.Trigger:
                _collider.AddComponent<TriggerEvent>();
                _collider.AddComponent<TriggerEventManager>();
                break;
            case ColliderMenu.Toggle:
                _collider.AddComponent<ToggleEvent>();
                _collider.AddComponent<ToggleEventManager>();
                break;
            default:
                break;
        }
    }
}
