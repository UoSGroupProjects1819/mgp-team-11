using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    bool lastIsDragging = false;
    bool isDragging = false;
    Vector2 dragStart;
    Vector2 lastMouse;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            lastMouse = Input.mousePosition;
        }
        if (lastIsDragging == true && isDragging == false)
        {
            var lastToThis = (dragStart - lastMouse) / 
                new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
            var dir = lastToThis.normalized;
            var mag = lastToThis.magnitude;

            rigid.velocity = Vector2.zero;
            rigid.AddForce(dir * mag * 100.0f);
            Debug.DrawRay(transform.position, dir, Color.red, 10.0f);
        }
    }

    private void LateUpdate()
    {
        lastIsDragging = isDragging;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        dragStart = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        isDragging = false;    
    }
}
