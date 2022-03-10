using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNotState : Node
{
    private EnemyAI _agent;
    private AIStates _targetState;

    public CheckNotState(EnemyAI agent, AIStates targetState)
    {
        _agent = agent;
        _targetState = targetState;
    }

    public override NodeState Decision()
    {
        if (_agent.CurrentState != _targetState)
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }
}
