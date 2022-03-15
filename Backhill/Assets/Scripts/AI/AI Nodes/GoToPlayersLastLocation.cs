using UnityEngine;

public class GoToPlayersLastLocation : Node
{
    private EnemyAI _agent;
    private float _attackDistance;

    public GoToPlayersLastLocation(EnemyAI agent, float attackDistance)
    {
        _agent = agent;
        _attackDistance = attackDistance;
    }

    public override NodeState Decision()
    {
        if (_agent.GetPlayerLastPosition() != null)
        {
            float distance = Vector3.Distance(_agent.GetPlayerLastPosition().position, _agent.transform.position); // Get player current pos
            if (distance > _attackDistance) // If you're further than min distance move to the target
            {
                _agent.MoveTo(_agent.GetPlayerLastPosition().gameObject);
                return NodeState.RUNNING;
            }
            else
                return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }
}
