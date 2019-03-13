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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            other.gameObject.GetComponent<Ball_movement>().score += value;
        }
    }
}
