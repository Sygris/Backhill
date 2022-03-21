public class AttackPlayer : Node
{
    private EnemyAI _agent;

    public AttackPlayer(EnemyAI agent)
    {
        _agent = agent;
    }

    public override NodeState Decision()
    {
        if (_agent.GetCanSeePlayerStatus())
        {
            _agent.AttackPlayer();
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }
}
