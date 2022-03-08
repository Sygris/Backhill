using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : Node
{
    private EnemyAI _agent;

    public SetPlayerPosition(EnemyAI agent)
    {
        _agent = agent;
    }

    public override NodeState Decision()
    {
        _agent.SetLastPlayerPosition();
        return NodeState.SUCCESS;
    }
}
