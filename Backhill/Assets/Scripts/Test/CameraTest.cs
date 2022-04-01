using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public float xValue;
    public float yValue;
    public float zValue;

    void Update()
    {
        transform.position = new Vector3(transform.position.x + (xValue * Time.deltaTime),
                                            transform.position.y + (yValue * Time.deltaTime),
                                            transform.position.z + (zValue * Time.deltaTime));
    }
}
