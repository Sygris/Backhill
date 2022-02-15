using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNewScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.Instance.NewScene();
    }
}
