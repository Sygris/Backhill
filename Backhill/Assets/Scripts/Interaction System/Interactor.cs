using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] private LayerMask _interactableLayerMask;
    [SerializeField] private float _raycastDistance = 2f;

    [Header("Interaction Settings")]
    [SerializeField] private InputActionReference _interact;
    private bool _wasInteractionPressed = false;

    private Interactable _lastInteractable;

    private void Start()
    {
        _interact.action.performed += ctx => _wasInteractionPressed = true;
        _interact.action.canceled += ctx => _wasInteractionPressed = false;
    }

    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, _raycastDistance, _interactableLayerMask))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable)
            {
                if (_wasInteractionPressed)
                {
                    interactable.onInteract.Invoke();
                }

                _lastInteractable = interactable;
            }
        }
    }

    private void OnEnable()
    {
        _interact.action.Enable();
    }

    private void OnDisable()
    {
        _interact.action.Disable();
    }
}
