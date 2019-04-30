using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScore : MonoBehaviour
{
    public static GlobalScore PlayerScore;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (PlayerScore == null)
        {
            DontDestroyOnLoad(this.gameObject);
            PlayerScore = this;
        } else if(PlayerScore != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
