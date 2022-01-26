using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
     // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(2.0f * Time.deltaTime, 0.0f, 0.0f), Space.World);
    }
}
