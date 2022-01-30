using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;

        // Locks the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Makes the cursor invisible
        Cursor.visible = false;
    }

    public void Move(Vector2 input)
    {
        float x = input.x;
        float z = input.y;

        Vector3 direction = transform.right * x + transform.forward * z;

        _characterController.Move(direction * _speed * Time.deltaTime);
    }

    public void Rotate(Vector2 input)
    {
        float mouseX = input.x * _mouseSensivity * Time.deltaTime;
        float mouseY = input.y * _mouseSensivity * Time.deltaTime;

        _cameraRotation -= mouseY;
        _cameraRotation = Mathf.Clamp(_cameraRotation, -_clamp, _clamp);

        _camera.transform.localRotation = Quaternion.Euler(_cameraRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
