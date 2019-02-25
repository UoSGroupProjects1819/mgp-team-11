using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentsMovement : MonoBehaviour
{
    public GameObject ExitVent;
    private float VentX;
    private float VentY;
    private Vector2 VentPos;
    public int VentX_Offset;
    public int VentY_Offset;
    private float SleepTime;

    // Start is called before the first frame update
    void Start()
    {
        VentX = ExitVent.transform.position.x + VentX_Offset;
        VentY = ExitVent.transform.position.y + VentY_Offset;
        VentPos = new Vector2(VentX, VentY);
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PerformTransportation(collision.gameObject, 2.0f));
        }
    }

    // Googled IEnumerator as suggested by friend
    IEnumerator PerformTransportation(GameObject ball, float time)
    {
        ball.SetActive(false);

        yield return new WaitForSeconds(time);

        ball.SetActive(true);

        ball.transform.position = VentPos;
        ball.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
    }
}
