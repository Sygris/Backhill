using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class EventControllers
{
    public abstract void TriggerEvent();
    public abstract void TriggerEvent(int ID);
}

[System.Serializable]
public class TriggerAniamtion : EventControllers
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _id;
    [SerializeField] private string _parameterName;
    public override void TriggerEvent() {   throw new System.NotImplementedException();    }

    public override void TriggerEvent(int ID)
    {
        if (ID == _id)
            _animator.SetTrigger(_parameterName);
    }
}
