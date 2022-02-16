using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class EventAction
//{
//    [SerializeReference] public List<Event> events = new List<Event>();
//    [SerializeField] public bool complete = false;
//}

public class EventManager : MonoBehaviour
{
    //[SerializeReference] public List<EventAction> actions = new List<EventAction>();

    private GameObject _emptyObject;

    [Header("Trigger Animation")]
    [SerializeField] private string _name;
    [SerializeField] private Vector3 _location;

    public void MakeTriggerCollider()
    {
        GameObject _collider = new GameObject(_name);
        _collider.transform.parent = transform;
        _collider.AddComponent<BoxCollider>();
        _collider.GetComponent<BoxCollider>().transform.position = _location;
        _collider.GetComponent<BoxCollider>().isTrigger = true;
        _collider.AddComponent<TriggerAnimation>();
    }

    public void MakeToggleCollider()
    {

    }
}
