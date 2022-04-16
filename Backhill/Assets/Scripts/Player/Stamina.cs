using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [Header("Stamina Settings")]
    [SerializeField] private float _playerStamina = 100.0f;
    [SerializeField] private float _maxStamina = 100.0f;
    private bool _isPlayerSprinting = false;

    [Header("Stamina Regeneration Settings")]
    [Range(0, 50)] [SerializeField] private float _staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float _staminaRegeneration = 0.5f;

    [Header("UI References")]
    [SerializeField] private Image _slider;

    private void Update()
    {
        Drain();
        Recharge();

        _slider.fillAmount = _playerStamina / 100.0f;
    }

    public void Sprint()
    {
        _isPlayerSprinting = true;
    }

    public void Walk() { _isPlayerSprinting = false; }

    private void Drain()
    {
        if (_isPlayerSprinting)
        {
            if (_playerStamina > 0.0f)
            {
                _playerStamina -= Time.deltaTime * _staminaDrain;
            }
        }
    }

    private void Recharge()
    {
        if (!_isPlayerSprinting && _playerStamina < _maxStamina)
        {
            _playerStamina += Time.deltaTime * _staminaRegeneration;
        }
    }
}
