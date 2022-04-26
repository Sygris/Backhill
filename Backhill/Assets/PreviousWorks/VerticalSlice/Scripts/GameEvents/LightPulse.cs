using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    private Light _myLight;
    private float _currentTime;
    private bool IsGettingBrighter;
    [SerializeField] private float _intensityTime;
    [SerializeField] private float _intensityStrenght;

    void Start()
    {
        _myLight = GetComponent<Light>();
        _currentTime = 0.0f;
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime < _intensityTime)
        {
            if (!IsGettingBrighter)
                _myLight.intensity += _intensityStrenght;
            else
                _myLight.intensity -= _intensityStrenght;
        }
        else
        {
            _currentTime = 0.0f;
            IsGettingBrighter = !IsGettingBrighter;
        }
    }
}
