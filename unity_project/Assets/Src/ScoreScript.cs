using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    Text score;
    public int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreValue != currentScore)
        {
            score.text += "Score:" + (currentScore +scoreValue);
            scoreValue = currentScore;
        }
    }
}
