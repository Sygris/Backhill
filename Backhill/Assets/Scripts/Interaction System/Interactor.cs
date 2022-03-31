using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] private LayerMask _interactableLayerMask;
    [SerializeField] private float _raycastDistance = 2f;

    [Header("Interaction Settings")]
    [SerializeField] private InputActionReference _interact;
    [SerializeField] private float _interactionDelay = 1f;
    private bool _wasInteractionPressed = false;
    private bool _isInteracting = false;

    [Header("Interaction UI")]
    [SerializeField] private Image _interactImage;
    [SerializeField] private Sprite _defaultIcon;
    [SerializeField] private Vector2 _defaultIconSize;
    [SerializeField] private Sprite _defaultInteractIcon;
    [SerializeField] private Vector2 _defaultInteractIconSize;

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

            // If interactable is not null
            if (interactable)
            {
                // If the last interactable is null set last interactable to the current interactable
                if (_lastInteractable == null)
                {
                    _lastInteractable = interactable;
                }

                // If interactable does not have a icon set the interact image to the interactable's icon else use the default values
                if (interactable.InteractionIcon != null)
                {
                    _interactImage.sprite = interactable.InteractionIcon;

                    // If the interactable's icon size is not set set it to default else use the interactable's icon size
                    if (interactable.IconSize == Vector2.zero)
                        _interactImage.rectTransform.sizeDelta = _defaultInteractIconSize;
                    else
                        _interactImage.rectTransform.sizeDelta = interactable.IconSize;
                }
                else
                {
                    _interactImage.sprite = _defaultInteractIcon;
                    _interactImage.rectTransform.sizeDelta = _defaultInteractIconSize;
                }

                // If the player pressed the interact key while looking to the interactable trigger its function
                if (_wasInteractionPressed && !_isInteracting)
                {
                    _isInteracting = true;
                    interactable.onInteract?.Invoke();
                    StartCoroutine(Delay());
                }
            }
        }
        else
        {
            // Clear the last interactable value
            _lastInteractable = null;

            // If the player is not currently looking to an interactable and the interact image is not the default set it to default
            if (_interactImage.sprite != _defaultIcon)
            {
                _interactImage.sprite = _defaultIcon;
                _interactImage.rectTransform.sizeDelta = _defaultIconSize;
            }
        }

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(_interactionDelay);
        _isInteracting = false;
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
