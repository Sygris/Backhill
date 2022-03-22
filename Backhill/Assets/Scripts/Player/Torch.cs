using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Light))]
public class Torch : MonoBehaviour
{
    private Light _light;

    [Header("Drain Battery Settings")]
    [SerializeField] private bool _drainOverTime;
    [SerializeField] private float _drainRate;

    [Header("Light Settings")]
    [SerializeField] private float _maxBrightness;
    [SerializeField] private float _minBrightness;

    [Header("UI References and settings")]
    [SerializeField] private Image _torchImage;
    [SerializeField] private Color _chargedColor;
    [SerializeField] private Color _halfChargedColor;
    [SerializeField] private Color _emptyColor;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        if (_drainOverTime && _light.enabled)
        {
            _light.intensity = Mathf.Clamp(_light.intensity, _minBrightness, _maxBrightness);

            if (_light.intensity > _minBrightness)
            {
                _light.intensity -= Time.deltaTime * (_drainRate / 100.0f);
            }
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        _torchImage.fillAmount = _light.intensity / 1;

        if (_light.intensity >= 0.55f)
        {
            _torchImage.color = _chargedColor;
        }
        else if (_light.intensity >= 0.25f)
        {
            _torchImage.color = _halfChargedColor;
        }
        else
        {
            _torchImage.color = _emptyColor;
        }

    }

    public void Toggle()
    {
        _light.enabled = !_light.enabled;

        gameObject.SetActive(_light);
    }

    public void Recharge(float amount)
    {
        _light.intensity += amount;
    }
}
