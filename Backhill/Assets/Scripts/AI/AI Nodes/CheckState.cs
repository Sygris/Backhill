public class CheckState : Node
{
    private EnemyAI _agent;
    private AIStates _targetState;

    public CheckState(EnemyAI agent, AIStates targetState)
    {
        _agent = agent;
        _targetState = targetState;
    }

    public override NodeState Decision()
    {
        if (_agent.GetAIState() == _targetState)
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }
}
