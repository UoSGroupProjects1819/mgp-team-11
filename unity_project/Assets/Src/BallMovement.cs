using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public bool aiming;
    public float speed;
    public bool ready;
    public LineRenderer line;
    public Vector2 startPos;
    public Vector2 endPos;
    public float maxDist;
    public Rigidbody2D RigidBody2D;
    public int moves;
    public float sleepTime;


    // Start is called before the first frame update
    void Start()
    {
        RigidBody2D = this.GetComponent<Rigidbody2D>();
        line.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
        {
            ready = true;
        }
        else
        {
            ready = false;
        }

        if (Input.GetMouseButtonUp(0) && ready && !aiming)
        {
            aiming = true;
        }

        if (Input.GetMouseButtonUp(0) && ready && aiming)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Shoot();
        }

        if (aiming)
        {
            line.GetComponent<LineRenderer>().enabled = true;
            startPos = this.transform.position;
            Vector3 shootPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shootPos.z = 0;
            shootPos = this.transform.position + (this.transform.position - shootPos);
            endPos = shootPos;

            if (Vector3.Distance(startPos, shootPos) > maxDist)
            {
                Vector3 dir = endPos - startPos;
                endPos = this.transform.position + (dir.normalized * maxDist);
            }
            line.GetComponent<LineRenderer>().SetPosition(1, endPos);
        }
        else
        {
            line.GetComponent<LineRenderer>().enabled = false;
        }
    }
    void Shoot()
    {
        aiming = false;
        Debug.Log("Shooting @ " + endPos.ToString());
        /*if (Vector2.Distance(startPos, endPos) > maxDist)
        *{
        *    
        }*/

        Vector3 direction = startPos - endPos;
        this.GetComponent<Rigidbody2D>().AddForce(direction * speed);
    }
}
