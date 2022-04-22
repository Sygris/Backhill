using UnityEngine;
using UnityEngine.InputSystem;

public class InspectUI : MonoBehaviour
{
    [SerializeField] private InputActionReference _returnInputActions;

    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _SpawnInspect;

    private void Start()
    {
        _returnInputActions.action.performed += ctx => Return();
    }

    private void Return()
    {
        gameObject.SetActive(false);
        _menu.SetActive(true);

        Destroy(_SpawnInspect.transform.GetChild(0).gameObject);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Destroy(_SpawnInspect.transform.GetChild(0).gameObject);
    }

    private void OnEnable()
    {
        _returnInputActions.action.Enable();
    }

    private void OnDisable()
    {
        _returnInputActions.action.Disable();
    }
}
