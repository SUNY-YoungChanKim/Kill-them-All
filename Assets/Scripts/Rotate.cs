using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed= 1.0f;
    public bool yAxis=true;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(yAxis)
        transform.Rotate(0, rotateSpeed*Time.deltaTime, 0);
        else
        transform.Rotate(0,0,  rotateSpeed*Time.deltaTime);
    }
}
