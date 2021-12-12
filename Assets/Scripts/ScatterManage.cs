using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterManage : MonoBehaviour
{
    [SerializeField]private List<GameObject> Parts;
    public AudioSource Sound;
    private bool breaking=false;
    private bool isitWeapon=false;
    // Start is called before the first frame update

    public void typechange()
    {
        isitWeapon=true;
        this.tag="Weapon";
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(breaking==false)
        {
            string tag=other.gameObject.tag;
            if(tag!="LHand" && tag!="RHand")
            {
                if(isitWeapon==true&&tag=="Player")return;
                if((this.GetComponent<Weapon>().enabled==true) && tag=="Player")return;
                Sound.Play();
                float x;
                float y;
                float z;
                foreach(GameObject t in Parts)
                {
                    x=Random.Range(-5.0f,5.0f);
                    y=Random.Range(-5.0f,5.0f);
                    z=Random.Range(-5.0f,5.0f);
                    t.AddComponent<Rigidbody>();
                    t.GetComponent<Rigidbody>().AddForce(x,y,z,ForceMode.Impulse);
                }
                this.GetComponent<Animator>().SetTrigger("Break");
                breaking=true;
            }
        }
    }
}
