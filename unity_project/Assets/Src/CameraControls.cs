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
            playerX = player.transform.position.x;
            playerY = player.transform.position.y;
            this.transform.position = new Vector3(playerX, playerY, -10);
        }
        
        if (Input.GetKey("c"))
        {
            Camera.orthographicSize = CameraSize;
            Camera.transform.position = new Vector3(levelCentre.gameObject.transform.position.x, levelCentre.gameObject.transform.position.y, -10);
            player.GetComponent<BallMovement>().ready = false;
        }
        else
        {
            Camera.orthographicSize = 5.0f;
        }
    }
}
