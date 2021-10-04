using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOWCameraChange : MonoBehaviour
{
    [SerializeField] private GameObject Subcam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }  
    private void OnCollisionEnter(Collision other) 
    {

        if(other.gameObject.tag=="Block")
        {
            this.GetComponent<Camera>().enabled=false;
            Subcam.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag=="Block")
        {
            this.GetComponent<Camera>().enabled=true;
            Subcam.SetActive(false);
        }
    }

}
