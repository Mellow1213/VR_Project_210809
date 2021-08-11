using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretRotate : MonoBehaviour
{
    public float turnSpeed = 840f;

    void Update()
    {
        Debug.Log("Rotate_X = " + transform.rotation.x);
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -1f * turnSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.LeftControl))
            transform.Rotate(turnSpeed * Time.deltaTime, 0f, 0f);
        if (Input.GetKey(KeyCode.LeftShift))
            transform.Rotate(-1f * turnSpeed * Time.deltaTime, 0f, 0f);


    }
}
