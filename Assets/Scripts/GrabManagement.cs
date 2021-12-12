using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class GrabManagement : MonoBehaviour
{
    XRRayInteractor XRray; 
    public bool islefthand;
    // Start is called before the first frame update
    void Start()
    {
        XRray=this.GetComponent<XRRayInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(XRray.selectTarget!=null)
        {
            GameObject t= XRray.selectTarget.gameObject;
            if(t.tag=="GB")
            {
                t.GetComponent<Weapon>().enabled=true;
                if(islefthand==true) t.GetComponent<Weapon>().statuschange("Lgrip");
                else t.GetComponent<Weapon>().statuschange("Rgrip");
                t.GetComponent<Bullet>().enabled=false;
                t.GetComponent<ScatterManage>().typechange();
                t.GetComponent<Rigidbody>().useGravity=true;

                 foreach(Transform x in t.transform)
                {
                    x.gameObject.layer=6;
                    x.tag="Weapon";
                }
            }
        }
    }
}
