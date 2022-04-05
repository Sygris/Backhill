using UnityEngine;
using UnityEngine.InputSystem;
    
public class Inspect : MonoBehaviour
{
    [SerializeField] private Camera _cameraUI;
    [SerializeField] private float _sensivity;
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

            Vector3 rotation = new Vector3(0, 0, 0);
            rotation.y = -(delta.x + delta.y) * _sensivity;

            transform.Rotate(rotation);
            _positionLastFrame = mousePosition;

            //var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            //transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.1f, axis) * transform.rotation;
        }
    }
}
