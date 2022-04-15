using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    void Start()
    {

    }

    void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            if (pitch < 90.0f && pitch > -90.0f)
            {
                pitch -= speedV * Input.GetAxis("Mouse Y");
            }
            else if (pitch >= 90.0f)
            {
                pitch = 89.9f;
            }
            else if (pitch <= -90.0f)
            {
                pitch = -89.9f;
            }
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
