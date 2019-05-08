using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public GameObject textDisplay;
    public Text displayScore;
    public float score;
    public GameObject Spawn;
    public int[] speedSelector;
    public GameObject sceneCamera;
    public Rigidbody2D rigid;
    public LineRenderer line;
    //public int moves;
    public int CurrentGemScore;
    public bool ready;
    public bool aiming;

    private float SpawnX;
    private float SpawnY;
    private Vector2 SpawnArea;
    private Vector3 startPos;
    private Vector3 endPos;
    
    
    private float speed;
    private float maxDist;
    private bool shooting;



    // Start is called before the first frame update
    void Start()
    {
        textDisplay.SetActive(false);
        shooting = false;
        //Gets the x y pos location of Spawn gameobject, then sets the player pos to the same x y
        SpawnX = Spawn.transform.position.x;
        SpawnY = Spawn.transform.position.y;
        SpawnArea = new Vector2(SpawnX, SpawnY);
        this.transform.position = SpawnArea;
        speed = 75;
        maxDist = 5;
        line.GetComponent<LineRenderer>().enabled = true;
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        playerRotate();

        if (Input.GetKey("r"))
        {
            this.gameObject.transform.position = SpawnArea;
        }


        if (sceneCamera.GetComponent<CameraControls>().zoomed == true)
        {
            displayScore.text = "Score: " + CurrentGemScore;
            textDisplay.SetActive(true);
        }
        else
        {
            textDisplay.SetActive(false);
        }

        //Checks if the ball is "not moving (0.05 velocity) and is enabled(game object gets disabled in vent script)
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.05 && isActiveAndEnabled && sceneCamera.GetComponent<CameraControls>().zoomed == false)
        {
            ready = true;
            shooting = false;
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
    }

    void Shoot()
    {
        shooting = true;
        //moves++;
        aiming = false;

        Vector3 direction = startPos - endPos;
        //Adds force to the player
        rigid.AddForce(direction * speed);
    }

    //https://youtu.be/_XdqA3xbP2A
    void playerRotate()
    {
        if (!shooting)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2(
                (mousePosition.x - transform.position.x) * -1,
                (mousePosition.y - transform.position.y) * -1
                );
            transform.up = direction;
        }
    }
}