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
    public AIStates CurrentState;

    private Node _rootNode;

    private NavMeshAgent _agent;
    private GameObject _player;
    private Transform _lastPlayerPosition;

    [SerializeField] private float _speed;
    [SerializeField] private float _pauseTime;
    [SerializeField] private List<Transform> _listOfNodes = new List<Transform>();

    public float MinWaypointDistance;
    public float MinPlayerDistance;
    public int CurrentNode;
    public bool IsPaused;
    public bool CanSeePlayer;

    public float DetectionRadius;
    [Range(0, 360)]
    public float FOVAngle;

    public float AttackDistance;

    public LayerMask _playerLayer;
    public LayerMask _obstructionLayer;

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
        ContinuePatrol goToNextWaypoint = new ContinuePatrol(this);

        GoToPlayersLastLocation goToLastPositon = new GoToPlayersLastLocation(this);

        //GoToLocation goToPlayer = new GoToLocation(this, GetPlayerPosition().gameObject);

        CheckState checkPatrolState = new CheckState(this, AIStates.Patrol);
        CheckState checkSearchState = new CheckState(this, AIStates.Search);
        CheckState checkAggroState = new CheckState(this, AIStates.Aggro);

        UpdateState updateStateToPatrol = new UpdateState(this, AIStates.Patrol);
        UpdateState updateStateToSearch = new UpdateState(this, AIStates.Search);
        UpdateState updateStateToAggro = new UpdateState(this, AIStates.Aggro);

        PlayerInChaseDistance playerWithinDistance = new PlayerInChaseDistance(this);

        PlayerDetection detectPlayer = new PlayerDetection(this);

        SetPlayerPosition updatePlayerPosition = new SetPlayerPosition(this);

        AttackPlayer attack = new AttackPlayer(this);

        Selector SearchForPlayer = new Selector(new List<Node> { updateStateToSearch, goToLastPositon });
        Sequence AttackPlayer = new Sequence(new List<Node> { checkAggroState, attack });
        Sequence ChasePlayer = new Sequence(new List<Node> { checkAggroState, playerWithinDistance });
        Sequence Patrol = new Sequence(new List<Node> { checkPatrolState, goToNextWaypoint });
        Sequence GetPlayerData = new Sequence(new List<Node> { detectPlayer, updateStateToAggro, updatePlayerPosition });
        Sequence FindPlayer = new Sequence(new List<Node> { checkAggroState, SearchForPlayer });

        _rootNode = new Selector(new List<Node> { ChasePlayer, Patrol });
    }

    public void AtNode()
    {
        StartCoroutine(WaypointPause(_pauseTime));
    }

    private void UpdateWaypoint()
    {
        if (_listOfNodes.Count == 0) return;

        _agent.destination = _listOfNodes[CurrentNode].position;
        ++CurrentNode;

        if (CurrentNode == _listOfNodes.Capacity)
            CurrentNode = CurrentNode % _listOfNodes.Count;

        GetWaypointPosition();
    }

    public void MoveTo(GameObject target)
    {
        _agent.destination = target.transform.position;
    }

    private IEnumerator WaypointPause(float delay)
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
        CurrentState = targetState;
    }

    public Transform GetWaypointPosition() { return _listOfNodes[CurrentNode]; }
    public Transform GetPlayerPosition() { return _player.transform; }
    public void SetLastPlayerPosition() { _lastPlayerPosition = GetPlayerPosition(); }
}
