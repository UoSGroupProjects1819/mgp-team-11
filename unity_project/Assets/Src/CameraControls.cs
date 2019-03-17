using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("c"))
        {
            Camera.orthographicSize = 15.0f;
        }
        else
        {
            Camera.orthographicSize = 5.0f;
        }
    }
}
