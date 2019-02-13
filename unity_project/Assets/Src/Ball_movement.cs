using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_movement : MonoBehaviour
{
    public bool sleeping;
    public bool aiming;
    public float speed; 
    public bool ready;
    public LineRenderer line;
    public Vector3 startPos;
    public Vector3 endPos;
    public float maxDist;
    public Vector3 maxForce;
    private float sleepTime;

    // Start is called before the first frame update
    void Start()
    {
        line.GetComponent<LineRenderer>().enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f)
        {
            ready = true;
        } else {
            ready = false;
            sleepTime = Time.time + 2f;
            sleeping = true;
        }

        if (Input.GetMouseButton(0) && ready && !aiming && !sleeping)
        {
            aiming = true;
        }

        if (Input.GetMouseButtonUp(0) == true && aiming && ready)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Shoot();
        }

        if (sleeping)
        {
            if (Time.time > sleepTime)
            {
                sleeping = false;
            }
        }

        if (aiming)
        {
            line.GetComponent<LineRenderer>().enabled = true;
            startPos = this.transform.position;
            line.GetComponent<LineRenderer>().SetPosition(0, startPos);
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
        } else {
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
