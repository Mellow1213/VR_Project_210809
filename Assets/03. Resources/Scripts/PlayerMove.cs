using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Transform player;
    public float speed = 3;

    public Text textMessage;

    private bool isViewPicture = false;
    private bool isMove = false;


    private Action initView;

    // Start is called before the first frame update
    void Start()
    {
        textMessage.text = "Touch to Move";
        textMessage.color = Color.blue;



        Picture[] pictures = FindObjectsOfType<Picture>();
        foreach(Picture p in pictures)
        {
            initView += p.InitView;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; 
        Physics.Raycast(player.transform.position, player.forward, out hit, 10);

        if (Input.GetMouseButtonDown(0))
        {
            if (isViewPicture)
            {
                Picture picture = null;

                if (hit.collider != null)
                    picture = hit.collider.GetComponent<Picture>();

                if (picture != null)
                {
                    isMove = false;
                    picture.ViewInformation();
                }
                else
                {
                    isMove = true;
                }
            }
            else
            {
                isMove = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {

            isMove = false;
        }


        if (isMove)
        {

            Vector3 dir = player.forward;
            dir.y = 0;
            this.transform.position += dir * Time.deltaTime * speed;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            isViewPicture = true;
            textMessage.text = "Touch Picture";
            textMessage.color = Color.red;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            isViewPicture = false;
            textMessage.text = "Touch to Move";
            textMessage.color = Color.blue;
        }


        initView?.Invoke();
    }
}
