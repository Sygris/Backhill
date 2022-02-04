using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    // Variable that stores the instance of PlayerInput
    private Input _playerInput;

    [Header("Script References")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private Torch _torch;

    private void Awake()
    {
        _playerInput = new Input();
    }

    private void Start()
    {
        _playerInput.CharacterControls.Torch.performed += ctx => _torch.Toggle();
        _playerInput.CharacterControls.Menu.performed += ctx => _pauseMenu.Toggle();
    }

    private void Update()
    {
        _playerMovement.Move(_playerInput.CharacterControls.Movement.ReadValue<Vector2>());
        _playerMovement.Rotate(_playerInput.CharacterControls.Look.ReadValue<Vector2>());
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
