using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private bool opened = false;
    private Animator animator;
    private GameObject StatusManager;
    private int LeftEnemy;
    private bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        animator= this.GetComponent<Animator>();
        StatusManager=GameObject.Find("StatusManager");    
        isLeft=this.gameObject.tag=="LDoor";
    }

    // Update is called once per frame
    void Update()
    {
        if(StatusManager.GetComponent<CountMonsters>().GetCount()!=0&&opened==true)
        {
            if(isLeft==true)
                animator.SetBool("LDoorOpen",false);
  
            else
                animator.SetBool("RDoorOpen",false);
           
        }
        else if(StatusManager.GetComponent<CountMonsters>().GetCount()==0&&opened==false)
        {
            if(isLeft==true)
                animator.SetBool("LDoorOpen",true);

            else 
                animator.SetBool("RDoorOpen",true);
     
        }
    }
    public void Open()
    {
        opened=true;
    }
    public void Close()
    {
        opened=false;
    }
}
