using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyRun : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.Translate((-Vector3.forward * Speed) * Time.deltaTime);
        }
    }
}
