using UnityEngine;

public class PlayerInChaseDistance : Node
{
    private EnemyAI _agent;
    private float _detectionRange;

    public PlayerInChaseDistance(EnemyAI agent, float detectionRange)
    {
        _agent = agent;
        _detectionRange = detectionRange;
    }

    public override NodeState Decision()
    {
        float distance = Vector3.Distance(_agent.GetPlayerPosition().position, _agent.transform.position);
        if (distance > _detectionRange) // If you're further than min distance move to the target
        {
            _agent.MoveTo(_agent.GetPlayerPosition().gameObject);
            return NodeState.RUNNING;
        }
        else
            return NodeState.SUCCESS;
    }
}
