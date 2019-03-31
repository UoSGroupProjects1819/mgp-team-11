using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollection : MonoBehaviour
{
    public int value;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Set gem inactive and award points to the player based off gem value
            this.gameObject.SetActive(false);
            other.gameObject.GetComponent<BallMovement>().CurrentGemScore += value;
            ScoreScript.scoreValue += value;
        }
    }
}
