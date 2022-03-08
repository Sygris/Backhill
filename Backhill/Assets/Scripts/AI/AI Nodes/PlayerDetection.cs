using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : Node
{
    private EnemyAI _agent;

    public PlayerDetection(EnemyAI agent)
    {
        _agent = agent;
    }

    public override NodeState Decision()
    {
        Collider[] detectionCheck = Physics.OverlapSphere(_agent.transform.position, _agent.DetectionRadius, _agent._playerLayer);

        if (detectionCheck.Length != 0)
        {
            Transform target = detectionCheck[0].transform;
            Vector3 directionOfTarget = (target.position - _agent.transform.position).normalized;

            if (Vector3.Angle(_agent.transform.position, directionOfTarget) < _agent.FOVAngle / 2)
            {
                float distanceOfTarget = Vector3.Distance(_agent.transform.position, target.position);

                if (!Physics.Raycast(_agent.transform.position, directionOfTarget, distanceOfTarget, _agent._obstructionLayer))
                {
                    _agent.CanSeePlayer = true;
                    return NodeState.SUCCESS;
                }
                else
                {
                    _agent.CanSeePlayer = false;
                    return NodeState.FAILURE;
                }
            }
            else
            {
                _agent.CanSeePlayer = false;
                return NodeState.FAILURE;
            }
        }
        else
        {
            _agent.CanSeePlayer = false;
            return NodeState.FAILURE;
        }
    }
}
