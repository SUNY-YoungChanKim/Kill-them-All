using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private string RotateAxis="X";
    [SerializeField] private float RotateSpeed=1;
    [SerializeField] private GameObject HitEffect;
 
    private string Status="None";
    private Vector3 previouspos;

    // Start is called before the first frame update
    void Start()
    {   
        Invoke("Stampedpos",0.2f);
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnCollisionEnter(Collision other)
     {
        if(other.transform.tag=="LHand")
        {
            Status="Lgrip";
        }
        if(other.transform.tag=="RHand")
        {
            Status="Rgrip";
        }

        if(other.transform.tag=="Monster"&&(Status=="Lgrip"||Status=="Rgrip"||Status=="Throw"))
        {
            if(other.gameObject.GetComponent<MonsterAI>().Hit(Damage)==true)
            {
                Instantiate(HitEffect,other.gameObject.transform.position,Quaternion.Euler(getAngles()-60,other.transform.rotation.eulerAngles.y+100,0));
                other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,2),ForceMode.Impulse);
            }            
        }

        if(Status=="Throw"&&(other.transform.tag!="LHand"&&other.transform.tag!="RHand"))
        {
            Status="None";
        }
    }
    private void OnCollisionExit(Collision other) 
    {

        
        if(Status=="Rgrip"&&other.transform.tag=="RHand")
        {
            Status="Throw";
            
            if(RotateAxis=="X")
            {
                this.transform.Rotate(Time.deltaTime*RotateSpeed,0,0);
            }
            else if(RotateAxis=="Y")
            {
                this.transform.Rotate(0,Time.deltaTime*RotateSpeed,0);
            }
            else if(RotateAxis=="Z")
            {
                this.transform.Rotate(0,0,Time.deltaTime*RotateSpeed);
            }
        }
        if(Status=="Lgrip"&&other.transform.tag=="LHand")
        {
            Status="Throw";
            
            if(RotateAxis=="X")
            {
                this.transform.Rotate(Time.deltaTime*RotateSpeed,0,0);
            }
            else if(RotateAxis=="Y")
            {
                this.transform.Rotate(0,Time.deltaTime*RotateSpeed,0);
            }
            else if(RotateAxis=="Z")
            {
                this.transform.Rotate(0,0,Time.deltaTime*RotateSpeed);
            }
        }
    }
    private void Stampedpos()
    {
        previouspos=this.transform.position;
        Invoke("Stampedpos",0.2f);
    }
    private float getAngles()
    {       
        
        Vector2 v2 = new Vector2(this.transform.position.y,this.transform.position.z) - new Vector2(previouspos.y,previouspos.z);
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }
}
