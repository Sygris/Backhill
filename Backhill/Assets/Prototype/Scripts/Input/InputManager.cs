using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    private static InputManager _instance;

    public static InputManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;

        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return _playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return _playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool HasPlayerCrouched()
    {
        return _playerControls.Player.Crouch.triggered;
    }
}
