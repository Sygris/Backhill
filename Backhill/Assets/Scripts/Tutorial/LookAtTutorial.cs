using UnityEngine;

public class LookAtTutorial : Tutorial
{
    [Header("Target Settings")]
    [SerializeField] private GameObject _target;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _minDistance;

    public override void CheckStatus()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, _minDistance, _targetLayer))
        {
            if (hit.collider.gameObject == _target)
            {
                TutorialManager.Instance.CompletedTutorial();
            }
        }
    }
}
