using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLocation : Node
{
    private AI _agent;
    private GameObject _target;

    public GoToLocation(AI agent, GameObject target)
    {
        _agent = agent;
        _target = target;
    }

    public override NodeState Decision()
    {
        //if (_target != null) // If theres no target then this node failes
        //{
        //    float distance = Vector3.Distance(_target.transform.position, _agent.transform.position);
        //    if (distance > /*BlackBoard._minDistance*/) // If you're further than min distance move to the target
        //    {
        //        //_agentActions.MoveTo(_target.transform.position);
        //        return NodeState.RUNNING;
        //    }
        //    else
        return NodeState.SUCCESS;
        //}
        //else
        //    return NodeState.FAILURE;
    }
}
