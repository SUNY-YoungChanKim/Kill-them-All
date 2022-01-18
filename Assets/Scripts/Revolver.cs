using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Revolver : MonoBehaviour
{
    [SerializeField]private GameObject Bullet;
    [SerializeField]private GameObject BulletPos;
    [SerializeField]private GameObject Slinder;
    [SerializeField]private List<GameObject> BulletHeads;
    [SerializeField]private AudioSource GunShot;
    [SerializeField]private ParticleSystem GunShotEffect;
    private Animator AnimatManager;
    private bool shotable=true;
    private  ActionBasedController haptic;
    private bool isleft;
    private int count=0;
    // Start is called before the first frame update
    private void Start() {
        AnimatManager=this.GetComponent<Animator>();
        
    }
    public void Judge()
    {
        if(AnimatManager.GetInteger("Status")==0)
        {
            if(count<6)Fire();
            else Reload();
        }
    }
    public void Fire()
    {
        if(shotable==true)
        {
            haptic.SendHapticImpulse(0.7f,0.5f);
            shotable=false;
            BulletHeads[count].GetComponent<MeshRenderer>().enabled=false;
            Slinder.transform.eulerAngles= new Vector3((count+1)*60,0,0);
            count+=1;
            AnimatManager.SetInteger("Status",1);
            Instantiate(Bullet,BulletPos.transform.position,this.transform.rotation);
            GunShot.Play();
            GunShotEffect.Play();
        }
    }
    public void Reload()
    {
        if(shotable==true)
        {
            count=0;
            shotable=false;
            AnimatManager.SetInteger("Status",2);
        }
    }
    public void SetToNormal()
    {
        AnimatManager.SetInteger("Status",0);
    }
    public void shotableTrue()
    {
        shotable=true;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag=="LHand")
        {
            haptic= GameObject.Find("LeftHand Controller").GetComponent<ActionBasedController>();
        }
        else
        {
            haptic= GameObject.Find("RightHand Controller").GetComponent<ActionBasedController>();
        }
    }
}
