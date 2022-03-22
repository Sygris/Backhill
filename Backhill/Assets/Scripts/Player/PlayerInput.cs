using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    // Variable that stores the instance of PlayerInput
    private Input _playerInput;

    [Header("Script References")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private Torch _torch;

    private void Awake()
    {
        _playerInput = new Input();
    }

    private void Start()
    {
        _playerInput.CharacterControls.Torch.performed += ctx =>
        {
            if (_torch.gameObject.activeInHierarchy)
                _torch.Toggle();
        };

        _playerInput.CharacterControls.Menu.performed += ctx =>
        {
            if (_pauseMenu.gameObject != null)
                ToggleMenu();
        };
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_playerInput.CharacterControls.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _playerRotation.Rotate(_playerInput.CharacterControls.Look.ReadValue<Vector2>());
        _playerMovement.Crouch(_playerInput.CharacterControls.Crouch.ReadValue<float>());
    }

    private void ToggleMenu()
    {
        _pauseMenu.Toggle();

        // Needs to be polished
        if (_pauseMenu.IsGamePaused)
        {
            _playerInput.CharacterControls.Movement.Disable();
            _playerInput.CharacterControls.Torch.Disable();
        }
        else
        {
            _playerInput.CharacterControls.Movement.Enable();
            _playerInput.CharacterControls.Torch.Enable();
        }
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
