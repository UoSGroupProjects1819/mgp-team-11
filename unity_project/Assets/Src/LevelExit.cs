using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    public int par;
    private int total;

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
            Debug.Log("level complete!");
            other.gameObject.SetActive(false);
            total = other.gameObject.GetComponent<Ball_movement>().moves;
            Debug.Log(total);
            if (total > par)
            {
                Debug.Log("Over par! :(");
            }
            else if (total < par)
            {
                Debug.Log("Under par! :)");
            }
            else if (total == par)
            {
                Debug.Log("On par! :)" );
            }
        }
    }
}
