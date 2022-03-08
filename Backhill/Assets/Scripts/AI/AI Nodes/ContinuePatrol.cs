using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePatrol : Node
{
    private EnemyAI _agent;

    public ContinuePatrol(EnemyAI agent)
    {
        _agent = agent;
    }

    public override NodeState Decision()
    {
        float distance = Vector3.Distance(_agent.GetWaypointPosition().position, _agent.transform.position);
        if (distance > _agent.MinWaypointDistance) // If you're further than min distance move to the target
        {
            _agent.MoveTo(_agent.GetWaypointPosition().gameObject);
            return NodeState.RUNNING;
        }
        else
        {
            if (!_agent.IsPaused)
            {
                _agent.AtNode();
                return NodeState.SUCCESS;
            }
            else
                return NodeState.RUNNING;
        }
    }
}
