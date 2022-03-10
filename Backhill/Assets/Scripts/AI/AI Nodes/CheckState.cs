public class CheckState : Node
{
    private EnemyAI _agent;
    private AIStates _currentState;
    private AIStates _targetState;

    public CheckState(EnemyAI agent, AIStates currentState, AIStates targetState)
    {
        _agent = agent;
        _currentState = currentState;
        _targetState = targetState;
    }

    public override NodeState Decision()
    {
        if (_currentState == _targetState)
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }
}
