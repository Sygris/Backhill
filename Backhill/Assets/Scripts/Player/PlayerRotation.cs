using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Camera _camera;

    private float _xRotation = 0f;

    [Header("Rotation Settings")]
    [SerializeField] private float _xSensivity = 30f;
    [SerializeField] private float _xRotationClampMax = 80f;
    [SerializeField] private float _xRotationClampMin = -80f;
    [SerializeField] private float _ySensivity = 30f;


    private void Start()
    {
        // Gets the camera component
        _camera = Camera.main;

        // Locks the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Makes the cursor invisible
        Cursor.visible = false;
    }

    public void Rotate(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculates camera rotation for looking vertically
        _xRotation -= (mouseY * Time.deltaTime) * _ySensivity;
        _xRotation = Mathf.Clamp(_xRotation, _xRotationClampMin, _xRotationClampMax);

        // Apply this rotation to the camera transform
        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        // Rotate player to look horizontally
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensivity);
    }
}
