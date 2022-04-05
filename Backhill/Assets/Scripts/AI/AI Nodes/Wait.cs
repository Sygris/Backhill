using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Node
{
    private EnemyAI _agent;

    public Wait(EnemyAI agent)
    {
        _agent = agent;
    }

    public override NodeState Decision()
    {
        if (!_agent.GetIsPausedStatus())
        {
            _agent.AtNode();
            return NodeState.SUCCESS;
        }
        else
            return NodeState.RUNNING;
    }
}
