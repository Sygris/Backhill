using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIStates
{
    Patrol,
    Search,
    Aggro
};

public class EnemyAI : MonoBehaviour
{
    public AIStates _currentState;

    private Node _rootNode;
    private NavMeshAgent _agent;
    private GameObject _player;
    private Transform _lastPlayerPosition;

    [SerializeField] private float _speed;
    [SerializeField] private float _pauseTime;
    [SerializeField] private List<Transform> _listOfNodes = new List<Transform>();

    public float MinDistance;
    public int CurrentNode;
    public bool IsPaused;
    public float MinPlayerDistance;

    void Start()
    {
        BuildBehaviourTree();
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _rootNode.Decision();
    }

    private void BuildBehaviourTree()
    {
        GoToLocation goToWaypoint = new GoToLocation(this, GetWaypointPosition().gameObject);
        GoToLocation goToPlayer = new GoToLocation(this, GetPlayerPosition().gameObject);

        CheckState checkPatrolState = new CheckState(_currentState, AIStates.Patrol);
        CheckState checkSearchState = new CheckState(_currentState, AIStates.Search);
        CheckState checkAggroState = new CheckState(_currentState, AIStates.Aggro);

        UpdateState updateStateToPatrol = new UpdateState(this, AIStates.Patrol);
        UpdateState updateStateToSearch = new UpdateState(this, AIStates.Search);
        UpdateState updateStateToAggro = new UpdateState(this, AIStates.Aggro);

        _rootNode = new Selector(new List<Node> { goToWaypoint });
    }

    public void AtNode()
    {
        StartCoroutine(Pause(_pauseTime));
    }

    private void UpdateWaypoint()
    {
        if (_listOfNodes.Count == 0) return;

        _agent.destination = _listOfNodes[CurrentNode].position;
        ++CurrentNode;

        if (CurrentNode == _listOfNodes.Capacity)
            CurrentNode = CurrentNode % _listOfNodes.Count;
    }

    public void MoveTo(GameObject target)
    {
        _agent.destination = target.transform.position;
    }

    private IEnumerator Pause(float delay)
    {
        _agent.speed = 0.0f;
        IsPaused = true;
        yield return new WaitForSeconds(delay);
        _agent.speed = _speed;
        IsPaused = false;
        UpdateWaypoint();
    }

    public void UpdateState(AIStates targetState)
    {
        _currentState = targetState;
    }

    public Transform GetWaypointPosition() { return _listOfNodes[CurrentNode]; }
    public Transform GetPlayerPosition() { return _player.transform; }
    public void SetLastPlayerPosition() { _lastPlayerPosition = _player.transform; }
}
