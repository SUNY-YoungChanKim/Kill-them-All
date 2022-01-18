using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        this.transform.position=new Vector3(this.transform.position.x,1.5F,this.transform.position.z);
    }
}
