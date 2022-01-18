using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    private bool LGrip;
    private bool RGrip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LGrip==true&&RGrip==true)
        {
            GameObject.Find("XR Rig").GetComponent<PlayerControl>().GenerateHP();
            Destroy(this.gameObject);
        }
        
    }
    private void OnCollisionExit(Collision other) 
    {
        if(other.transform.tag=="LHand")LGrip=false;
        else if(other.transform.tag=="RHand")RGrip=false;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag=="LHand")LGrip=true;
        else if(other.transform.tag=="RHand")RGrip=true;
    }
}
