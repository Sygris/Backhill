using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public enum AIStates
{
    Idle,
    Patrol,
    Search,
    Aggro,
    Attack
};

public class EnemyAI : MonoBehaviour
{
    #region Variables
    [Header("Movement Information")]
    [SerializeField] private float _patrolSpeed;
    [SerializeField] private float _aggroSpeed;
    [SerializeField] private float _waypointPauseTime;
    [SerializeField] private float _searchPauseTime;
    [SerializeField] private List<Transform> _listOfNodes = new List<Transform>();

    [Header("Detection Information")]
    [SerializeField] private float _minWaypointDistance;
    [SerializeField] private float _detectionRadius;
    [Range(0, 360)]
    [SerializeField] private float _fovAngle;
    [SerializeField] private float _searchingDetectionRadius;
    [Range(0, 360)]
    [SerializeField] private float _searchingFOVAngle;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackPauseTime;
    [SerializeField] private string _playerTag;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _obstructionLayer;

    [Header("Animation Information")]
    [SerializeField] private string _idleAnimationName;
    [SerializeField] private string _patrolAnimationName;
    [SerializeField] private string _searchAnimationName;
    [SerializeField] private string _aggroAnimationName;
    [SerializeField] private string _attackAnimationName;

    private AIStates _currentState;
    private Node _rootNode;
    private NavMeshAgent _agent;
    private GameObject _player;
    private Vector3 _lastPlayerPosition;
    private Animator _aiAnimator;
    private BoxCollider _aiCollider;

    private int _currentNode;
    private bool _isAttacking, _isPaused, _canSeePlayer, _isSearching = false;
    private float _origionalDectectonRaduis, _origionalFOVAngle;
    #endregion

    #region GettersAndSetters
    public AIStates GetAIState() { return _currentState; }

    public void SetAIState(AIStates state) { _currentState = state; }

    public Transform GetWaypointPosition() { return _listOfNodes[_currentNode]; }
    public Transform GetPlayerCurrentPosition() { return _player.transform; }
    public Vector3 GetPlayerLastPosition() { return _lastPlayerPosition; }

    public bool GetIsPausedStatus() { return _isPaused; }
    public bool GetCanSeePlayerStatus() { return _canSeePlayer; }
    public bool GetIsAttackingStatus() { return _isAttacking; }
    public bool GetIsSeachingStatus() { return _isSearching; }

    public void SetWaypointPosition(int nodeValue) { _currentNode = nodeValue; }
    public void SetLastPlayerPosition() { _lastPlayerPosition = _player.transform.position; }

    public void SetIsPausedStatus(bool status) { _isPaused = status; }
    public void SetIsAttackingStatus(bool status) { _isAttacking = status; }
    public void SetIsCanSeePlayerStatus(bool status) { _canSeePlayer = status; }
    #endregion

    void Start()
    {
        BuildBehaviourTree();
        _player = GameObject.FindGameObjectWithTag(_playerTag);
        _agent = GetComponent<NavMeshAgent>();
        _aiAnimator = GetComponent<Animator>();
        _aiCollider = GetComponent<BoxCollider>();
        _origionalDectectonRaduis = _detectionRadius;
        _origionalFOVAngle = _fovAngle;
        _currentState = AIStates.Patrol;
        StateChange();
    }

    void Update()
    {
        _rootNode.Decision();
    }

    private void BuildBehaviourTree()
    {
        #region Nodes
        ContinuePatrol goToNextWaypoint = new ContinuePatrol(this, _minWaypointDistance);

        Wait pauseAtWaypoint = new Wait(this);

        GoToPlayersLastLocation goToLastPositon = new GoToPlayersLastLocation(this, _attackDistance);

        CheckState checkIdleState = new CheckState(this, AIStates.Idle);
        CheckState checkPatrolState = new CheckState(this, AIStates.Patrol);
        CheckState checkSearchState = new CheckState(this, AIStates.Search);
        CheckState checkAggroState = new CheckState(this, AIStates.Aggro);
        CheckState checkAttackState = new CheckState(this, AIStates.Attack);

        UpdateState updateStateToIdle = new UpdateState(this, AIStates.Idle);
        UpdateState updateStateToPatrol = new UpdateState(this, AIStates.Patrol);
        UpdateState updateStateToSearch = new UpdateState(this, AIStates.Search);
        UpdateState updateStateToAggro = new UpdateState(this, AIStates.Aggro);
        UpdateState updateStateToAttack = new UpdateState(this, AIStates.Attack);

        PlayerInChaseDistance playerWithinAttackingDistance = new PlayerInChaseDistance(this, _attackDistance);

        PlayerDetection detectPlayer = new PlayerDetection(this, _detectionRadius, _fovAngle, _playerLayer, _obstructionLayer);

        SetPlayerPosition updatePlayerPosition = new SetPlayerPosition(this);

        AttackPlayer attack = new AttackPlayer(this);

        SearchForPlayer playerSearch = new SearchForPlayer(this);
        #endregion

        Inverter invertDetectPlayer = new Inverter(detectPlayer);

        #region ParentNodes
        Sequence GetPlayerData = new Sequence(new List<Node> { detectPlayer, updateStateToAggro, updatePlayerPosition });
        Sequence SearchForPlayer = new Sequence(new List<Node> { checkSearchState, goToLastPositon, playerSearch, updateStateToPatrol });
        Sequence AttackPlayer = new Sequence(new List<Node> { checkAttackState, playerWithinAttackingDistance, attack });
        Sequence ChasePlayer = new Sequence(new List<Node> { GetPlayerData, goToLastPositon, updateStateToAttack });
        Sequence Wait = new Sequence(new List<Node> { checkIdleState, pauseAtWaypoint, updateStateToPatrol});
        Sequence Patrol = new Sequence(new List<Node> { checkPatrolState, goToNextWaypoint, updateStateToIdle });
        Sequence FindPlayer = new Sequence(new List<Node> { checkAggroState, invertDetectPlayer, updateStateToSearch });
        #endregion

        _rootNode = new Selector(new List<Node> { FindPlayer, SearchForPlayer, AttackPlayer, ChasePlayer, Patrol, Wait });
    }

    #region AIFunctionality
    public void AtNode()
    {
        StartCoroutine(WaypointPause(_waypointPauseTime));
    }

    public void SearchForPlayer()
    {
        StartCoroutine(SearchPause(_searchPauseTime));
    }

    public void AttackPlayer()
    {
        StartCoroutine(AttackPause(_attackPauseTime));
    }

    private void UpdateWaypoint()
    {
        if (_listOfNodes.Count == 0) return;

        _agent.destination = _listOfNodes[_currentNode].position;
        ++_currentNode;

        if (_currentNode == _listOfNodes.Capacity)
            _currentNode = _currentNode % _listOfNodes.Count;

        GetWaypointPosition();

        _isPaused = false;

        StateChange();
    }

    public void MoveTo(GameObject target)
    {
        _agent.destination = target.transform.position;
    }

    public void MoveTo(Vector3 target)
    {
        _agent.destination = target;
    }

    private IEnumerator WaypointPause(float delay)
    {
        _aiAnimator.SetTrigger(_idleAnimationName);
        _agent.speed = 0.0f;
        _isPaused = true;
        yield return new WaitForSeconds(delay);
        _agent.speed = _patrolSpeed;
        UpdateWaypoint();
    }

    public void UpdateState(AIStates targetState)
    {
        _currentState = targetState;
    }

    private IEnumerator AttackPause(float delay)
    {
        _aiAnimator.SetTrigger(_attackAnimationName);
        _agent.speed = 0.0f;
        _aiCollider.enabled = true;
        yield return new WaitForSeconds(delay);
        _aiCollider.enabled = false;
        _currentState = AIStates.Patrol;
        StateChange();
    }

    private IEnumerator SearchPause(float delay)
    {
        _aiAnimator.SetTrigger(_idleAnimationName);
        _agent.speed = 0.0f;
        _detectionRadius = _searchingDetectionRadius;
        _fovAngle = _searchingFOVAngle;
        _isSearching = true;
        yield return new WaitForSeconds(delay);
        _detectionRadius = _origionalDectectonRaduis;
        _fovAngle = _origionalFOVAngle;
        _isSearching = false;
        StateChange();
    }

    public void StateChange()
    {
        switch (_currentState)
        {
            case AIStates.Idle:
                _agent.speed = 0.0f;
                _aiAnimator.SetTrigger(_idleAnimationName);
                break;
            case AIStates.Patrol:
                _agent.speed = _patrolSpeed;
                _aiAnimator.SetTrigger(_patrolAnimationName);
                break;
            case AIStates.Search:
                _agent.speed = _patrolSpeed;
                _aiAnimator.SetTrigger(_searchAnimationName);
                break;
            case AIStates.Aggro:
                _agent.speed = _aggroSpeed;
                _aiAnimator.SetTrigger(_aggroAnimationName);
                break;
            case AIStates.Attack:
                _aiAnimator.SetTrigger(_attackAnimationName);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_playerTag))
            SceneManager.LoadScene(4);
    }
    #endregion
}
