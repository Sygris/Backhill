using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSkyboxChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.Instance.ChangeScene();

        gameObject.SetActive(false);
    }
}
