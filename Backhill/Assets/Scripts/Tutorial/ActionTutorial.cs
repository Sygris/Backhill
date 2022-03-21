using UnityEngine;
using UnityEngine.InputSystem;

public class ActionTutorial : Tutorial
{
    [SerializeField] private InputActionReference _inputAction;
    private bool _wasInteractionPressed = false;

    private void Start()
    {
        _inputAction.action.performed += ctx => _wasInteractionPressed = true;
        _inputAction.action.canceled += ctx => _wasInteractionPressed = true;
    }

    public override void CheckStatus()
    {
        if (_wasInteractionPressed)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }

    private void OnEnable()
    {
        _inputAction.action.Enable();
    }

    private void OnDisable()
    {
        _inputAction.action.Disable();
    }
}
