using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [Header("Node Information")]
    [SerializeField] private List<Transform> _listOfNodes = new List<Transform>();

    [Header("Node Behaviour Information")]
    [SerializeField] private float _pauseTime;
    [SerializeField] private float _patrolSpeed;
    [SerializeField] private float _minimumDistance;

    private int _currentNode;
    protected bool IsPaused;

    protected Rigidbody MyRigid;
    protected NavMeshAgent Agent;

    protected virtual void Start()
    {
        _currentNode = 0;

        IsPaused = false;

        MyRigid = GetComponent<Rigidbody>();
        Agent = GetComponent<NavMeshAgent>();

        Agent.speed = _patrolSpeed;

    }

    protected void ContinuePatrol()
    {
        if (Agent.enabled && _listOfNodes.Count > 0)
        {
            if ((!Agent.pathPending && Agent.remainingDistance < _minimumDistance) && !IsPaused)
                StartCoroutine(Pause(_pauseTime));
        }
    }

    protected void NextNode()
    {
        if (_listOfNodes.Count == 0) return;

        Agent.destination = _listOfNodes[_currentNode].position;
        ++_currentNode;

        if (_currentNode == _listOfNodes.Capacity)
            _currentNode = _currentNode % _listOfNodes.Count;
    }

    private IEnumerator Pause(float delay)
    {
        Agent.speed = 0.0f;
        IsPaused = true;
        yield return new WaitForSeconds(delay);
        Agent.speed = _patrolSpeed;
        IsPaused = false;
        NextNode();
    }
}
