using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
public class Weapon : MonoBehaviour
{
    [Serializable] public struct Skill
    {
        public GameObject SkillImage;
        public String SkillName;
        public float CoolTime;
        public UnityEvent active;
    }
    [SerializeField] private string RotateAxis="X";
    [SerializeField] private float RotateSpeed=1;
    [SerializeField] private GameObject HitEffect;
    [SerializeField] private int rank=0;
    [SerializeField] private Skill Skillset;


    private string Status="None";
    private bool HitEffectCreated=false;
    private Vector3 previouspos;
    private GameObject SkillImage,Canvas;

    // Start is called before the first frame update
    void Start()
    {   
        Invoke("Stampedpos",0.2f);
        Canvas=GameObject.Find("UICanvas");
        SkillImage=null;
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void ItemActive()
    {
        Skillset.active.Invoke();
        SkillImage.GetComponent<RawImage>().color=new Color(0,0,0);
        Invoke("Coolup",Skillset.CoolTime);
    }
    public void Coolup()
    {
        SkillImage.GetComponent<RawImage>().color=new Color(255,255,255);
    }
    public void statuschange(string x)
    {
        Status=x;
    }
    private void OnCollisionEnter(Collision other)
     {
        if(other.transform.tag=="LHand"&&Status!="Lgrip")
        {

            Status="Lgrip";
        }
        if(other.transform.tag=="RHand"&&Status!="Rgrip")
        {
            Status="Rgrip";
        }

        if(other.transform.tag=="Monster"&&(Status=="Lgrip"||Status=="Rgrip"||Status=="Throw"))
        {
            other.gameObject.GetComponent<MonsterAI>().Dead(); 
            if(HitEffectCreated==false)
            {
                Instantiate(HitEffect,other.GetContact(0).point,Quaternion.Euler(getAngles()-60,other.transform.rotation.eulerAngles.y+100,0));
                HitEffectCreated=true;
            }
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,2),ForceMode.Impulse);
                
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
    public void UIActivate(bool isleft)
    {
        SkillImage=Instantiate(Skillset.SkillImage);
        SkillImage.transform.SetParent(Canvas.transform);
        if(isleft==true)SkillImage.GetComponent<RectTransform>().localPosition=new Vector3(-250,200,0);
        else SkillImage.GetComponent<RectTransform>().localPosition=new Vector3(250,200,0);
        SkillImage.GetComponent<RectTransform>().localRotation=Quaternion.identity;
        SkillImage.GetComponent<RectTransform>().localScale=new Vector3(2,2,2);
    }
    public void UIDeactivate()
    {
        Destroy(SkillImage.gameObject);
        SkillImage=null;
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
    public int getRank()
    {
        return rank;
    }
}
