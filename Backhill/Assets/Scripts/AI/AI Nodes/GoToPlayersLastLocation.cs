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
        float distance = Vector3.Distance(_agent.GetPlayerPosition().position, _agent.transform.position);
        if (distance > _attackDistance) // If you're further than min distance move to the target
        {
            _agent.MoveTo(_agent.GetPlayerPosition().gameObject);
            return NodeState.RUNNING;
        }
        else
            return NodeState.SUCCESS;
    }
}
