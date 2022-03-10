using UnityEngine;

public class PlayerDetection : Node
{
    private EnemyAI _agent;
    private float _detectionRange;
    private float _fovAngle;
    private LayerMask _playerLayer;
    private LayerMask _obstructionLayer;

    public PlayerDetection(EnemyAI agent, float detectionRange, float fovAngle, LayerMask playerLayer, LayerMask obstructionLayer)
    {
        _agent = agent;
        _detectionRange = detectionRange;
        _fovAngle = fovAngle;
        _playerLayer = playerLayer;
        _obstructionLayer = obstructionLayer;
    }

    public override NodeState Decision()
    {
        Collider[] detectionCheck = Physics.OverlapSphere(_agent.transform.position, _detectionRange, _playerLayer);

        if (detectionCheck.Length != 0)
        {
            Transform target = detectionCheck[0].transform;
            Vector3 directionOfTarget = (target.position - _agent.transform.position).normalized;

            if (Vector3.Angle(_agent.transform.forward, directionOfTarget) < _fovAngle / 2)
            {
                float distanceOfTarget = Vector3.Distance(_agent.transform.position, target.position);

                if (!Physics.Raycast(_agent.transform.position, directionOfTarget, distanceOfTarget, _obstructionLayer))
                {
                    _agent.SetIsCanSeePlayerStatus(true);
                    return NodeState.SUCCESS;
                }
                else
                {
                    _agent.SetIsCanSeePlayerStatus(false);
                    return NodeState.FAILURE;
                }
            }
            else
            {
                _agent.SetIsCanSeePlayerStatus(false);
                return NodeState.FAILURE;
            }
        }
        else
        {
            _agent.SetIsCanSeePlayerStatus(false);
            return NodeState.FAILURE;
        }
    }
}
