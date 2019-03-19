using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public bool aiming;
    public float speed;
    public bool ready;
    public LineRenderer line;
    public Vector3 startPos;
    public Vector3 endPos;
    public float maxDist;
    public Rigidbody2D rigid;
    public int[] speedSelector;
    public int[] colourSelector;
    public int moves;
    public GameObject Spawn;
    private float SpawnX;
    private float SpawnY;
    private Vector2 SpawnArea;
    public float score;
    public GameObject sceneCamera;
    private int speedCounter;
    private int lineColour;
    private float playerX;
    private float playerY;
    Color c1 = Color.green;
    Color c2 = Color.yellow;
    Color c3 = Color.red;


    // Start is called before the first frame update
    void Start()
    {
        SpawnX = Spawn.transform.position.x;
        SpawnY = Spawn.transform.position.y;
        SpawnArea = new Vector2(SpawnX, SpawnY);
        line.GetComponent<LineRenderer>().enabled = true;
        rigid = this.GetComponent<Rigidbody2D>();
        this.transform.position = SpawnArea;
        playerX = this.transform.position.x;
        playerY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<Rigidbody2D>().velocity.magnitude == 0 && isActiveAndEnabled)
        {
            playerX = this.transform.position.x;
            playerY = this.transform.position.y;
            sceneCamera.transform.position = new Vector3(playerX, playerY, -10);
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
        }
        else
        {
            line.GetComponent<LineRenderer>().enabled = false;
        }

        if (Input.GetKeyDown("s"))
        {
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
        Debug.Log("Shooting @ " + endPos.ToString());

        Vector3 direction = startPos - endPos;
        rigid.AddForce(direction * speed);
    }

}