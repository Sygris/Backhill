using UnityEngine;

public class GoToLocation : Node
{
    private EnemyAI _agent;
    private float _minWaypointDistance;
    private bool _isPaused;

    public GoToLocation(EnemyAI agent, float minWaypointDistnace, bool isPaused)
    {
        _agent = agent;
        _minWaypointDistance = minWaypointDistnace;
        _isPaused = isPaused;
    }

    public override NodeState Decision()
    {
        float distance = Vector3.Distance(_agent.GetWaypointPosition().position, _agent.transform.position);
        if (distance > _minWaypointDistance) // If you're further than min distance move to the target
        {
            _agent.MoveTo(_agent.GetWaypointPosition().gameObject);
            return NodeState.RUNNING;
        }
        else
        {
            if (!_isPaused)
            {
                _agent.AtNode();
                return NodeState.SUCCESS;
            }
            else
                return NodeState.RUNNING;
        }
    }
}
