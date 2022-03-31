using UnityEngine;
using UnityEngine.InputSystem;
    
public class Inspect : MonoBehaviour
{
    [SerializeField] private Camera _cameraUI;
    private Vector3 _positionLastFrame;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _positionLastFrame = Mouse.current.position.ReadValue();
        }

        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            var delta = mousePosition - _positionLastFrame;
            _positionLastFrame = mousePosition;

            var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.1f, axis) * transform.rotation;
        }
    }
}
