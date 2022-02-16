using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventAction
{
    [SerializeReference] public List<Event> events = new List<Event>();
    [SerializeField] public bool complete = false;
}
public class EventManager : MonoBehaviour
{
    [SerializeReference] public List<EventAction> actions = new List<EventAction>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
