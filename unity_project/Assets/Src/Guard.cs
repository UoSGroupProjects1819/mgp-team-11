using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float Stationary;
    private float SleepTime;


    // Start is called before the first frame update
    void Start()
    {
        SleepTime = Time.time + Stationary;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SleepTime)
        {
            transform.Rotate(0, 0, 90);
            SleepTime = Time.time + Stationary;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            Debug.Log("FAIL");
        }
    }
}