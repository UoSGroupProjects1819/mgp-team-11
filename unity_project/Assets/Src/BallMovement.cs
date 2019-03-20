using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float score;
    public GameObject Spawn;
    public int[] speedSelector;
    public GameObject sceneCamera;
    public Rigidbody2D rigid;
    public LineRenderer line;
    public int moves;

    private bool aiming;
    private float speed;
    private bool ready;
    private Vector3 startPos;
    private Vector3 endPos;
    private float maxDist;
    
    private float SpawnX;
    private float SpawnY;
    private Vector2 SpawnArea;
    private int speedCounter;
    private int lineColour;
    private Color c1 = Color.green;
    private Color c2 = Color.yellow;
    private Color c3 = Color.red;


    // Start is called before the first frame update
    void Start()
    {
        //Gets the x y pos location of Spawn gameobject, then sets the player pos to the same x y
        SpawnX = Spawn.transform.position.x;
        SpawnY = Spawn.transform.position.y;
        SpawnArea = new Vector2(SpawnX, SpawnY);
        this.transform.position = SpawnArea;

        line.GetComponent<LineRenderer>().enabled = true;
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the ball is "not moving (0.05 velocity) and is enabled(game object gets disabled in vent script)
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.05 && isActiveAndEnabled)
        {
            ready = true;
        }
        else
        {
            ready = false;
        }


        if (Input.GetMouseButton(0) && ready && !aiming)
        {
            aiming = true;
        }

        if (Input.GetMouseButtonUp(0) == true && aiming)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Shoot();
        }


        if (aiming)
        {
            //Enable line render, and work out the direction it faces
            line.GetComponent<LineRenderer>().enabled = true;
            startPos = this.transform.position;
            line.GetComponent<LineRenderer>().SetPosition(0, startPos);
            Vector3 shootPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shootPos.z = 0;
            shootPos = this.transform.position + (this.transform.position - shootPos);
            endPos = shootPos;

            //Sets a max limit on the line size
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


        if (Input.GetKeyDown("s"))
        {
            //Allows changing of the speed of the player by looping through an array of speeds. Also changes line colour based off speed
            speedCounter++;
            if (speedCounter > 2)
            {
                speedCounter = 0;
            }
            speed = speedSelector[speedCounter];

            if (speedCounter == 0)
            {
                maxDist = 3;
                line.startColor = c1;
            }
            else if (speedCounter == 1)
            {
                maxDist = 4;
                line.startColor = c2;
            } 
            else
            {
                maxDist = 5;
                line.startColor = c3;
            }
        }
    }

    void Shoot()
    {
        moves++;
        aiming = false;

        Vector3 direction = startPos - endPos;
        //Adds force to the player
        rigid.AddForce(direction * speed);
    }

}