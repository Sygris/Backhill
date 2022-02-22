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
    private GameObject _emptyObject;

    public void MakeEventCollider()
    {
        GameObject _collider = new GameObject(ColliderType.ToString() + ": " + _eventName);
        _collider.transform.parent = transform;
        _collider.AddComponent<BoxCollider>();
        _collider.GetComponent<BoxCollider>().isTrigger = true;

        switch (ColliderType)
        {
            case ColliderMenu.Trigger:
                _collider.AddComponent<TriggerEventManager>();
                _collider.AddComponent<TriggerEvent>();
                break;
            case ColliderMenu.Toggle:
                _collider.AddComponent<ToggleEventManager>();
                _collider.AddComponent<ToggleEvent>();
                break;
            default:
                break;
        }
    }
}
