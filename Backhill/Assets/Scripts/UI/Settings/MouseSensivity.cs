using UnityEngine;

public class MouseSensivity : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private PlayerMovement _playerMovement;

    public void AdjustMouseSensivity(float newSensivity)
    {
        _playerMovement.MouseSensivity = newSensivity;
    }
}
