using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overview : MonoBehaviour
{
    public Camera camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camera.orthographicSize = 21f;
            transform.position = new Vector3(40.0f,20.0f,-5.0f);
        }
    }
}
