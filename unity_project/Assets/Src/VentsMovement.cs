using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentsMovement : MonoBehaviour
{
    public GameObject ExitVent;
    private float VentX;
    private float VentY;
    private Vector2 VentPos;
    public int VentX_Offset;
    public int VentY_Offset;
    private float SleepTime;

    // Start is called before the first frame update
    void Start()
    {
        VentX = ExitVent.transform.position.x + VentX_Offset;
        VentY = ExitVent.transform.position.y + VentY_Offset;
        VentPos = new Vector2(VentX, VentY);
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SleepTime = Time.time + 2;
            if (SleepTime > Time.time)
            {
                collision.gameObject.SetActive(false);
            }
            else
            {
                collision.transform.position = VentPos;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
                collision.gameObject.SetActive(true);
            }  
        }
    }
}
