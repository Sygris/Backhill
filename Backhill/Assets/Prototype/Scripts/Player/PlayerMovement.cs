using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // Variable that stores the instance of PlayerInput
    private PlayerInput _playerInput;

    // Variable that stores the reference to the player's character controller
    private CharacterController _characterController;

    // Variable that stores the reference to the camera
    private Camera _camera;
    private float _cameraRotation = 0f;

    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f;

    [Header("Looking Settings")]
    [SerializeField] private float _mouseSensivity = 100f;
    [SerializeField] private float _clamp = 90f;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;
    }

    private void Start()
    {
        // Locks the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Makes the cursor invisible
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        float x = _playerInput.CharacterControls.Movement.ReadValue<Vector2>().x;
        float z = _playerInput.CharacterControls.Movement.ReadValue<Vector2>().y;

        Vector3 direction = transform.right * x + transform.forward * z;

        _characterController.Move(direction * _speed * Time.deltaTime);

    }

    private void Turn()
    {
        float mouseX = _playerInput.CharacterControls.Look.ReadValue<Vector2>().x * _mouseSensivity * Time.deltaTime;
        float mouseY = _playerInput.CharacterControls.Look.ReadValue<Vector2>().y * _mouseSensivity * Time.deltaTime;

        _cameraRotation -= mouseY;
        _cameraRotation = Mathf.Clamp(_cameraRotation, -_clamp, _clamp);

        _camera.transform.localRotation = Quaternion.Euler(_cameraRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
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
