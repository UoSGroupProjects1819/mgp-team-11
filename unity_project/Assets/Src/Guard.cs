using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float Stationary;
    private float SleepTime;
    public GameObject seekingSprite;
    public GameObject detectedSprite;

    // Start is called before the first frame update
    void Start()
    {
        SleepTime = Time.time + Stationary;
        seekingSprite.SetActive(true);
        detectedSprite.SetActive(false);
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
            seekingSprite.SetActive(false);
            detectedSprite.SetActive(true);
            other.gameObject.SetActive(false);
            Debug.Log("FAIL");
        }
    }
}