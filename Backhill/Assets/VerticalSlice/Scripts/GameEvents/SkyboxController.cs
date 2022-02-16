using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    [SerializeField] private Material _targetSkybox;

    void Start()
    {
        GameEvents.Instance.TriggerSkyboxChange += ChangeMaterial;
    }

    private void ChangeMaterial()
    {
        RenderSettings.skybox = _targetSkybox;
    }
}
