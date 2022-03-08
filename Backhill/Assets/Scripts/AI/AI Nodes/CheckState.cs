using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckState : Node
{
    private AIStates _currentState;
    private AIStates _targetState;

    public CheckState(AIStates currentState, AIStates targetState)
    {
        _currentState = currentState;
        _targetState = targetState;
    }

    public override NodeState Decision()
    {
        if (_currentState != _targetState)
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }
}
