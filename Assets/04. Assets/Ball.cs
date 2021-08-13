using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject plane;
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Distance = " + Vector3.Distance(this.transform.position, plane.transform.position));
        if (Vector3.Distance(this.transform.position, plane.transform.position) > 80) 
            this.transform.position = spawn.transform.position;
    }
}
