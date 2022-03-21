using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variable that stores the reference to the player's character controller
    private CharacterController _characterController;

    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f;

    [Header("Gravity Settings")]
    [SerializeField] private float _gravity = -9.8f;
    private Vector3 _playerVelocity;
    private bool _isGrounded;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = _characterController.isGrounded;
    }

    public void Move(Vector2 input)
    {
        float x = input.x;
        float z = input.y;
        Vector3 direction = transform.right * x + transform.forward * z;

        _characterController.Move(direction * _speed * Time.deltaTime);

        _playerVelocity.y += _gravity * Time.deltaTime;

        if (_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = 0f;

        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void Crouch(float isCrouching)
    {
        if (isCrouching == 1)
        {
            _characterController.height = Mathf.Lerp(_characterController.height, -0.5f, Time.deltaTime * 5);
            _characterController.center = Vector3.Lerp(_characterController.center, new Vector3(0, 0, 0), Time.deltaTime * 5);
        }
        else
        {

            _characterController.center = Vector3.Lerp(_characterController.center, new Vector3(0, 0, 0), Time.deltaTime * 10);
            _characterController.height = Mathf.Lerp(_characterController.height, 2, Time.deltaTime * 5);
        }
    }
}
