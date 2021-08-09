using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    public float turnSpeed = 840f;
    private float tempData = 500f;

    // Use this for initialization
    void Start()
    {
        Debug.Log("시작합니다!");
    }

    // Update is called once per frame
    void Update()
    {
        float h = 0;
        float v = 0;

        if (Input.GetKey(KeyCode.W) == true)
        {
            v = 0.2f;
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            v = -0.2f;
        }
        else
        {
            v = 0;
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            h = -0.2f;
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            h = 0.2f;
        }
        else
        {
            h = 0;
        }

        if (Input.GetKey(KeyCode.Space) == true)
        {
            GameObject.Find("tank").transform.position = new Vector3(0, 0, 0);
        }

        //if (Input.inputString != "") Debug.Log(Input.inputString);

        transform.Translate(0f, 0f, v * moveSpeed * Time.deltaTime);

        transform.Rotate(0f, h * turnSpeed * Time.deltaTime, 0f);
    }
}
