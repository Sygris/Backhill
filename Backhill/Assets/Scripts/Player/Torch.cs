using UnityEngine;

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
