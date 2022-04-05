using UnityEngine;

public class ContinuePatrol : Node
{
    private EnemyAI _agent;
    private float _waypointMinDistance;

    public ContinuePatrol(EnemyAI agent, float waypointMinDistance)
    {
        _agent = agent;
        _waypointMinDistance = waypointMinDistance;
    }

    public override NodeState Decision()
    {
        if (!_agent.GetIsPausedStatus())
        {
            float distance = Vector3.Distance(_agent.GetWaypointPosition().position, _agent.transform.position);
            if (distance > _waypointMinDistance) // If you're further than min distance move to the target
            {
                _agent.MoveTo(_agent.GetWaypointPosition().gameObject);
                return NodeState.RUNNING;
            }
            else
                return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }
}
