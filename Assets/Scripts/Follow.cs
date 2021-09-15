using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float FollowSpeed;
    [SerializeField] private bool Left;
    private bool follow=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(follow==true)
        {
        target.transform.position= Vector3.MoveTowards(target.transform.position,this.transform.position,Time.deltaTime*FollowSpeed);
        target.transform.rotation=this.transform.rotation;
        if(Left)
        target.transform.Rotate(new Vector3(0,-180,-60));
        else
        target.transform.Rotate(new Vector3(0,-180,60));
        }
        //this.transform.localEulerAngles = new Vector3(target.transform.rotation.x,target.transform.rotation.y,target.transform.rotation.z);

    }
    private void OnCollisionEnter(Collision other) 
    {   
        Debug.Log(other.gameObject.name);
        follow=false;
    }
   private void OnCollisionExit(Collision other) 
    {
        Debug.Log("Exit");
        follow=true;   
    }
}
