using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Camera Camera;
    public float CameraSize;
    public GameObject player;
    private float playerX;
    private float playerY;
    public GameObject levelCentre;
    public bool zoomed;

    // Start is called before the first frame update
    void Start()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf == true && Input.GetKeyDown("c") == false)
        {
            zoomed = false;
            playerX = player.transform.position.x;
            playerY = player.transform.position.y;
            this.transform.position = new Vector3(playerX, playerY, -10);
        }

        if (Input.GetKey("c"))
        {
            zoomed = true;
            Camera.orthographicSize = CameraSize;
            Camera.transform.position = new Vector3(levelCentre.gameObject.transform.position.x, levelCentre.gameObject.transform.position.y, -10);
            player.GetComponent<BallMovement>().ready = false;
            player.GetComponent<BallMovement>().aiming = false;
        }
        else
        {
            Camera.orthographicSize = 5.0f;
        }
    }
}
