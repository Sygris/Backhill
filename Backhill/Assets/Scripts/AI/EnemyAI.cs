using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIStates
{
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
    [SerializeField] private float _pauseTime;
    [SerializeField] private List<Transform> _listOfNodes = new List<Transform>();

    [Header("Detection Information")]
    [SerializeField] private float _minWaypointDistance;
    [SerializeField] private float _detectionRadius;
    [Range(0, 360)]
    [SerializeField] private float _fovAngle;
    [SerializeField] private float _attackDistance;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _obstructionLayer;

    public AIStates _currentState;
    private Node _rootNode;
    private NavMeshAgent _agent;
    private GameObject _player;
    private Transform _lastPlayerPosition;
    private Animator _aiAnimator;

    private int _currentNode;
    private bool _isAttacking, _isPaused, _canSeePlayer;
    #endregion

    #region GettersAndSetters
    public AIStates GetAIState() { return _currentState; }

    public void SetAIState(AIStates state) { _currentState = state; }

    public Transform GetWaypointPosition() { return _listOfNodes[_currentNode]; }
    public Transform GetPlayerPosition() { return _player.transform; }

    public bool GetIsPausedStatus() { return _isPaused; }
    public bool GetCanSeePlayerStatus() { return _canSeePlayer; }
    public bool GetIsAttackingStatus() { return _isAttacking; }

    public void SetWaypointPosition(int nodeValue) { _currentNode = nodeValue; }
    public void SetLastPlayerPosition() { _lastPlayerPosition = GetPlayerPosition(); }

    public void SetIsPausedStatus(bool status) { _isPaused = status; }
    public void SetIsAttackingStatus(bool status) { _isAttacking = status; }
    public void SetIsCanSeePlayerStatus(bool status) { _canSeePlayer = status; }
    #endregion

    void Start()
    {
        BuildBehaviourTree();
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        _aiAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        _rootNode.Decision();

        if (_currentState == AIStates.Aggro)
            _agent.speed = _aggroSpeed;
        else
            _agent.speed = _patrolSpeed;
    }

    private void BuildBehaviourTree()
    {
        #region Nodes
        ContinuePatrol goToNextWaypoint = new ContinuePatrol(this, _minWaypointDistance);

        GoToPlayersLastLocation goToLastPositon = new GoToPlayersLastLocation(this, _attackDistance);

        CheckState checkPatrolState = new CheckState(this, GetAIState(), AIStates.Patrol);
        CheckState checkSearchState = new CheckState(this, GetAIState(), AIStates.Search);
        CheckState checkAggroState = new CheckState(this, GetAIState(), AIStates.Aggro);
        CheckState checkAttackState = new CheckState(this, GetAIState(), AIStates.Attack);

        UpdateState updateStateToPatrol = new UpdateState(this, AIStates.Patrol);
        UpdateState updateStateToSearch = new UpdateState(this, AIStates.Search);
        UpdateState updateStateToAggro = new UpdateState(this, AIStates.Aggro);
        UpdateState updateStateToAttack = new UpdateState(this, AIStates.Attack);

        PlayerInChaseDistance playerWithinAttackingDistance = new PlayerInChaseDistance(this, _attackDistance);

        PlayerDetection detectPlayer = new PlayerDetection(this, _detectionRadius, _fovAngle, _playerLayer, _obstructionLayer);

        SetPlayerPosition updatePlayerPosition = new SetPlayerPosition(this);

        AttackPlayer attack = new AttackPlayer(this);
        #endregion

        #region ParentNodes
        Sequence SearchForPlayer = new Sequence(new List<Node> { checkAggroState, updateStateToSearch, goToLastPositon });
        Sequence AttackPlayer = new Sequence(new List<Node> { checkAttackState, playerWithinAttackingDistance, attack });
        Sequence ChasePlayer = new Sequence(new List<Node> { detectPlayer, updateStateToAggro, updatePlayerPosition, goToLastPositon, updateStateToAttack });
        Sequence Patrol = new Sequence(new List<Node> { updateStateToPatrol, goToNextWaypoint });
        Sequence GetPlayerData = new Sequence(new List<Node> { detectPlayer, updateStateToAggro, updatePlayerPosition });
        Selector FindPlayer = new Selector(new List<Node> { GetPlayerData, SearchForPlayer });
        #endregion

        _rootNode = new Selector(new List<Node> { AttackPlayer, ChasePlayer, Patrol });
    }

    #region AIFunctionality
    public void AtNode()
    {
        StartCoroutine(WaypointPause(_pauseTime));
    }

    private void UpdateWaypoint()
    {
        if (_listOfNodes.Count == 0) return;

        _agent.destination = _listOfNodes[_currentNode].position;
        ++_currentNode;

        if (_currentNode == _listOfNodes.Capacity)
            _currentNode = _currentNode % _listOfNodes.Count;

        GetWaypointPosition();
    }

    public void MoveTo(GameObject target)
    {
        _agent.destination = target.transform.position;
    }

    private IEnumerator WaypointPause(float delay)
    {
        _agent.speed = 0.0f;
        _isPaused = true;
        yield return new WaitForSeconds(delay);
        _agent.speed = _patrolSpeed;
        _isPaused = false;
        UpdateWaypoint();
    }

    public void UpdateState(AIStates targetState)
    {
        _currentState = targetState;
    }

    public void AttackAnimation()
    {
        _aiAnimator.SetTrigger("Attack");
    }

    private IEnumerator PauseWhileAttack(Animation animation)
    {
        do
        {
            if (animation.isPlaying)
            {
                _agent.speed = 0.0f;
                _isAttacking = true;
            }
            else
            {
                _agent.speed = _patrolSpeed;
                _isAttacking = false;
            }
            yield return null;
        } while (!_isAttacking);
    }
    #endregion
}
