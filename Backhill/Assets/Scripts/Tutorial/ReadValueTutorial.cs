using UnityEngine;
using UnityEngine.InputSystem;

public class ReadValueTutorial : Tutorial
{
    [SerializeField] private InputActionReference _inputAction;

    public override void CheckStatus()
    {
        if (_inputAction.action.ReadValue<Vector2>() != Vector2.zero)
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
