using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField]private List<GameObject> GenerableItem;
    [SerializeField]private GameObject genPos;
    [SerializeField]private ParticleSystem PS;
    private Animator AnimateManager;
    private bool opened=false;
    // Start is called before the first frame update
    void Start()
    {
        AnimateManager=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(opened==false)
        {
            if(other.transform.tag=="LHand" ||other.transform.tag=="RHand"||other.transform.tag=="Weapon")Generate();  
        }
    }
    void Generate()
    {
        opened=true;
        GameObject t= GenerableItem[Random.Range(0,GenerableItem.Count)];
        AnimateManager.SetTrigger("Open");
        Instantiate(t,genPos.transform.position,Quaternion.identity);
  
        var psmain=PS.main;
        if(t.GetComponent<Weapon>().getRank()==0)psmain.startColor=new Color(255,0,0);
        if(t.GetComponent<Weapon>().getRank()==1)psmain.startColor=new Color(0,0,255);
        if(t.GetComponent<Weapon>().getRank()==2)psmain.startColor=new Color(255,0,0);
        PS.Play();
    }
}
