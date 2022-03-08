using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLocation : Node
{
    private EnemyAI _agent;
    private GameObject _target;

    public GoToLocation(EnemyAI agent, GameObject target)
    {
        _agent = agent;
        _target = target;
    }

    public override NodeState Decision()
    {
        if (_target != null) // If theres no target then this node failes
        {
            float distance = Vector3.Distance(_target.transform.position, _agent.transform.position);
            if (distance > _agent.MinDistance) // If you're further than min distance move to the target
            {
                _agent.MoveTo(_target);
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
                {
                    return NodeState.RUNNING;
                }
            }
        }
        else
            return NodeState.FAILURE;
    }
}
