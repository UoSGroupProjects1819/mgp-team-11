using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotate : MonoBehaviour
{

    public bool RotateUp;
    public bool RotateRight;
    public bool RotateLeft;
    public bool RotateDown;

    public Quaternion RotationUp;
    public Quaternion RotationRight;
    public Quaternion RotationDown;
    public Quaternion RotationLeft;

    public Quaternion StartRotate;

    public float Stationary;
    private float SleepTime;


    public float Rotation_Speed;
    public float Rotation_Friction; //The smaller the value, the more Friction there is. [Keep this at 1 unless you know what you are doing].
    public float Rotation_Smoothness; //Believe it or not, adjusting this before anything else is the best way to go.

    private float Resulting_Value_from_Input;
    private Quaternion Quaternion_Rotate_From;
    private Quaternion Quaternion_Rotate_To;



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
            //Resulting_Value_from_Input += Input.GetAxis("Horizontal") * Rotation_Speed * Rotation_Friction; //You can also use "Mouse X"
            Quaternion_Rotate_From = transform.rotation;
            Quaternion_Rotate_To = Quaternion.Euler(0, 0, 90);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion_Rotate_To, Time.deltaTime * Rotation_Smoothness);
        }
    }

    void Rotate()
    {

        if (Time.time > SleepTime)
        {
            
        }
    }
}
