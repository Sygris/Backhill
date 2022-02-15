using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPowerToggle : MonoBehaviour
{
    public float interval = 1.0f;
    private float currentTime = 0.0f;
    private Light _myLight;
    private bool IsLightOff;

    void Start()
    {
        _myLight = GetComponent<Light>();
        IsLightOff = false;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > interval)
        {
            IsLightOff = !IsLightOff;
            currentTime = 0.0f;
        }

        if (IsLightOff)
        {
            _myLight.enabled = false;
        }
        else
        {
            _myLight.enabled = true;
        }
    }
}
