public class UpdateState : Node
{
    private EnemyAI _agent;
    private AIStates _targetState;

    public UpdateState(EnemyAI agent, AIStates targetState)
    {
        _agent = agent;
        _targetState = targetState;
    }

    public override NodeState Decision()
    {
        _agent.UpdateState(_targetState);
        return NodeState.SUCCESS;
    }
}
