using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public LayerMask InteractableLayerMask;
    UnityEvent onInteract;

    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 2f, InteractableLayerMask))
        {
            if (hit.collider.GetComponent<Interactable>())
            {
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    onInteract?.Invoke();
                }
            }
        }
    }
}
