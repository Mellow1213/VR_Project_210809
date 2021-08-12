using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    public GameObject viewInfo;
    public GameObject viewVideo;
    private int page = 0;


    // Start is called before the first frame update
    void Start()
    {
        InitView();

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void InitView()
    {
        viewInfo.SetActive(false);
        viewVideo.SetActive(false);
        page = 0;
    }



    public void ViewInformation()
    {
        if(page == 0)
        {
            viewInfo.SetActive(true);
        }
        else if(page == 1)
        {
            viewInfo.SetActive(false);
            viewVideo.SetActive(true);

        }
        else if (page == 2)
        {
            viewVideo.SetActive(false);
            page = -1;

        }

        page++;
    }
}
