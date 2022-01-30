using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectStatusController : MonoBehaviour
{
    [SerializeField] private int _objectID;
    [SerializeField] private List<GameObject> _targetObject;
    void Start()
    {
        GameEvents.Instance.TriggerGameObjectTrue += ActivateObject;
        GameEvents.Instance.TriggerGameObjectFalse += DeactivateObject;
    }

    private void ActivateObject(int id)
    {
        if (id == _objectID)
        {
            foreach (GameObject target in _targetObject)
                target.SetActive(true);
        }
    }

    private void DeactivateObject(int id)
    {
        if (id == _objectID)
            foreach (GameObject target in _targetObject)
                target.SetActive(false);
    }
}
