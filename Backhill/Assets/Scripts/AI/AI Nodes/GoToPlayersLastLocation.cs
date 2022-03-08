using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayersLastLocation : Node
{
    public EnemyAI _agent;

    public GoToPlayersLastLocation(EnemyAI agent)
    {
        _agent = agent;
    }

    public override NodeState Decision()
    {
        float distance = Vector3.Distance(_agent.GetPlayerPosition().position, _agent.transform.position);
        if (distance > _agent.AttackDistance) // If you're further than min distance move to the target
        {
            _agent.MoveTo(_agent.GetPlayerPosition().gameObject);
            return NodeState.RUNNING;
        }
        else
            return NodeState.SUCCESS;
    }
}
