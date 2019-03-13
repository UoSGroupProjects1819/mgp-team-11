using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    public int par;
    public float levelScore;
    private int movesOver;
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
            total = other.gameObject.GetComponent<Ball_movement>().moves;
            if (total > par)
            {
                movesOver = total - par;
                levelScore = levelScore / (1 + (0.2f * movesOver));
            }
            other.gameObject.GetComponent<Ball_movement>().score += levelScore;
            other.gameObject.SetActive(false);
        }
    }
}
