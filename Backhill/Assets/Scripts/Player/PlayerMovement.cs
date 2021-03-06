using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variable that stores the reference to the player's character controller
    private CharacterController _characterController;

    [Header("Movement Settings")]
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _crouchVelocity = 2.0f;
    [SerializeField] private float _sprintVelocity = 3.5f;
    private Vector3 _playerVelocity;
    private bool _isPlayerSprinting = false;

    [Header("Crouch Settings")]
    [Range(0, 1.0f)]
    [SerializeField] private float _crouchSpeed = 0.3f;
    [SerializeField] private float _standHeight = 2.0f;
    [SerializeField] private float _crouchHeight = 1.0f;
    [SerializeField] private float _offsetStanding = 1.25f;
    [SerializeField] private float _offsetCrouching = 0.25f;
    private bool _isCrouching = false;
    public bool IsCrouching { get { return _isCrouching; } }

    [Header("Stamina Settings")]
    [SerializeField] private Stamina _stamina;

    [Header("Gravity Settings")]
    [SerializeField] private float _gravity = -9.8f;
    private bool _isGrounded;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        _characterController.height = _standHeight;
        _characterController.center = new Vector3(0, _crouchHeight / 2, 0);
    }

    private void Update()
    {
        _isGrounded = _characterController.isGrounded;
    }

    public void Move(Vector2 input)
    {
        Vector3 direction = transform.right * input.x + transform.forward * input.y;

        var velocity = _isCrouching ? _crouchVelocity : _speed;

        if (_isCrouching)
            velocity = _crouchVelocity;
        else if (_stamina.IsPlayerCrouching)
            velocity = _sprintVelocity;
        else
            velocity = _speed;

        _characterController.Move(direction * velocity * Time.deltaTime);

        Gravity();
    }

    private void Gravity()
    {
        _playerVelocity.y += _gravity * Time.deltaTime;

        if (_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = 0f;

        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void Sprint(float isSprinting)
    {
        // Player should not be able to sprint if its already crouching (Design choice)
        if (_isCrouching) return;
        else
        {
            if (isSprinting == 1f)
            {
                _isPlayerSprinting = true;
                _stamina.Sprint();
            }
            else
            {
                _isPlayerSprinting = false;
                _stamina.Walk();
            }
        }
    }

    // Hold crouch
    public void Crouch(float isCrouching)
    {
        float desiredHeight;

        if (isCrouching == 1f)
        {
            desiredHeight = _crouchHeight;
            _isCrouching = true;
        }
        else
        {
            desiredHeight = _standHeight;
            _isCrouching = false;
        }

        if (_characterController.height != desiredHeight)
        {
            // Adjust the center and Height of the Character Controller component
            AdjustHeight(desiredHeight);

            // Moves the camera y position to be the same as the Character controller's y position
            var camPos = Camera.main.transform.position;

            float offset = _isCrouching ? _offsetCrouching : _offsetStanding;

            camPos.y = transform.position.y + offset;

            Camera.main.transform.position = camPos;
        }
    }

    // Trigger crouch
    public void Crouch()
    {
        _isCrouching = !_isCrouching;

        float desiredHeight = _isCrouching == true ? _crouchHeight : _standHeight;

        if (_characterController.height != desiredHeight)
        {
            // Adjust the center and Height of the Character Controller component
            AdjustHeight(desiredHeight);

            // Moves the camera y position to be the same as the Character controller's y position
            var camPos = Camera.main.transform.position;

            float offset = _isCrouching ? _offsetCrouching : _offsetStanding;

            camPos.y = transform.position.y + offset;

            Camera.main.transform.position = camPos;
        }
    }

    private void AdjustHeight(float height)
    {
        float center = height / 2;

        _characterController.height = Mathf.Lerp(_characterController.height, height, _crouchSpeed);
        _characterController.center = Vector3.Lerp(_characterController.center, new Vector3(0, center, 0), _crouchSpeed);
    }
}
