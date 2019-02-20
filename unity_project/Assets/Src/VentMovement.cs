using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentMovement : MonoBehaviour
{ 
    public Rigidbody2D Rigidbody2D;
    public GameObject vent;
    public float ventX;
    public float ventY;
    public Vector2 vent_pos;
    public float sleep_time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > sleep_time)
        {

        }
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Time.time > sleep_time)
        {
            if (Other.gameObject.tag == "Vent1")
            {
                vent = GameObject.FindGameObjectWithTag("Vent2");
                ventX = vent.gameObject.transform.position.x + 1;
                ventY = vent.gameObject.transform.position.y;
            }
            else if (Other.gameObject.tag == "Vent2")
            {
                vent = GameObject.FindGameObjectWithTag("Vent1");
                ventX = vent.gameObject.transform.position.x -1;
                ventY = vent.gameObject.transform.position.y;
            }
            sleep_time = Time.time + 2;
            vent_pos = new Vector2(ventX, ventY);
            this.gameObject.transform.position = vent_pos;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
        }

    }
}
