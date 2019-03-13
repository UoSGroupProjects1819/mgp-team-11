using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    public int par;
    public float newScore;
    public float levelScore;
    private float multipler;
    private int movesOver;
    private int total;

    // Start is called before the first frame update
    void Start()
    {
        multipler = 0.2f;
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
            newScore = other.gameObject.GetComponent<Ball_movement>().score;
            Debug.Log(total);
            if (total > par)
            {
                movesOver = total - par;
                levelScore = levelScore / (1 +(multipler * movesOver));
            }
            else if (total < par || total == par)
            {
                newScore += levelScore;
            }
        }
    }
}
