using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float Stationary;
    private float SleepTime;
    public GameObject seekingSprite;
    public GameObject detectedSprite;
    public GameObject[] Gems;
    private GameObject CurrentGem;


    // Start is called before the first frame update
    void Start()
    {
        //SleepTime is used to rotate the player 
        SleepTime = Time.time + Stationary;
        seekingSprite.SetActive(true);
        detectedSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SleepTime)
        {
            //Roatates the guard 90 degrees and updates sleeptime, resets the vision sprites
            transform.Rotate(0, 0, 90);
            SleepTime = Time.time + Stationary;
            seekingSprite.SetActive(true);
            detectedSprite.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //When colliding with the player, it changes the active vision sprite and moves the player back to the spawn, removing any force.
            seekingSprite.SetActive(false);
            detectedSprite.SetActive(true);
            for (int i = 0; i < Gems.Length; i++)
            {
                CurrentGem = Gems[i];
                CurrentGem.SetActive(false);
            }
            other.gameObject.GetComponent<BallMovement>().CurrentGemScore = 0;
            other.gameObject.transform.position = new Vector2(other.gameObject.GetComponent<BallMovement>().Spawn.gameObject.transform.position.x, other.GetComponent<BallMovement>().Spawn.gameObject.transform.position.y);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
    }
}