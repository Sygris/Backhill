using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : Node
{
    private EnemyAI _agent;

    public SearchForPlayer(EnemyAI agent)
    {
        _agent = agent;
    }

    public override NodeState Decision()
    {
        if (!_agent.GetIsSeachingStatus())
        {
            _agent.SearchForPlayer();
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.RUNNING;
        }
    }
}
