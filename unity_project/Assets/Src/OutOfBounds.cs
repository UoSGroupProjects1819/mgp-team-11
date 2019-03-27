using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector2(collision.gameObject.GetComponent<BallMovement>().Spawn.gameObject.transform.position.x, collision.gameObject.GetComponent<BallMovement>().Spawn.transform.position.y);
        }
    }
}
