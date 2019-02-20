using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollection : MonoBehaviour
{
    public Rigidbody2D RigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody2D = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
