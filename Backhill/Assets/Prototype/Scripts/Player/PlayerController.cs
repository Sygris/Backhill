using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _gravityValue = -9.81f;
    
    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    private bool _isPlayerGrounded;

    private InputManager _inputManager;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _inputManager = InputManager.Instance;
    }

    private void Update()
    {
        // Checks if the player is touching the ground
        _isPlayerGrounded = _characterController.isGrounded;

        // If the player is touching the ground and it's not moving down set the velocity.y to 0
        if (_isPlayerGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0.0f;
        }

        Vector2 movement = _inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0.0f, movement.y);
        _characterController.Move(move * Time.deltaTime * _playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
