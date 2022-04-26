using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPowerToggle : MonoBehaviour
{
    [SerializeField] private float _interval;
    [SerializeField] private AudioClip _targetSFX;
    private float currentTime = 0.0f;
    private Light _myLight;
    private bool IsLightOff;

    void Start()
    {
        _myLight = GetComponent<Light>();
        IsLightOff = true;
        PlaySound();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > _interval)
        {
            IsLightOff = !IsLightOff;
            currentTime = 0.0f;
            _myLight.enabled = IsLightOff;
            PlaySound();
        }
    }

    private void PlaySound()
    {
        if (IsLightOff)
            AudioManager.instance.PlaySound(_targetSFX, transform.position, 1.0f);
    }
}
