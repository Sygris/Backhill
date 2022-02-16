using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPowerToggle : MonoBehaviour
{
    [SerializeField] private float interval;
    private float currentTime = 0.0f;
    private Light _myLight;
    private bool IsLightOff;

    void Start()
    {
        _myLight = GetComponent<Light>();
        IsLightOff = true;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > interval)
        {
            IsLightOff = !IsLightOff;
            currentTime = 0.0f;
            _myLight.enabled = IsLightOff;
        }
    }
}
