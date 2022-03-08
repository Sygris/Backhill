using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : Node
{
    private EnemyAI _agent;

    public AttackPlayer(EnemyAI agent)
    {
        _agent = agent;
    }

    public override NodeState Decision()
    {
        if (_agent.CanSeePlayer)
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }
}
