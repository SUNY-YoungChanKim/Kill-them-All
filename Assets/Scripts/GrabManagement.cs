using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class GrabManagement : MonoBehaviour
{
    XRRayInteractor XRray; 
    [SerializeField] private InputActionReference Trigger;
    public bool islefthand;
    private GameObject SelectedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        Trigger.action.performed += ItemActive;
        XRray=this.GetComponent<XRRayInteractor>();
    }

    // Update is called once per frame
    public void ItemActive(InputAction.CallbackContext obj)
    {
        if(XRray.selectTarget!=null)
        {
            GameObject t= XRray.selectTarget.gameObject;
            if(t.GetComponent<Weapon>()!=null)
            {
                t.GetComponent<Weapon>().ItemActive();
            }
            if(t.GetComponent<Hover>()!=null)
            {
                t.GetComponent<Hover>().enabled=false;
            }
        }

    }
    public void WeaponUIActivate()
    {
        if(XRray.selectTarget!=null)
        {

            if(XRray.selectTarget.GetComponent<Weapon>()!=null)
            {
                SelectedWeapon=XRray.selectTarget.gameObject;
                SelectedWeapon.GetComponent<Weapon>().UIActivate(this.name=="LeftHand Controller");
            }
        }
    }
    public void WeaponUIDeActivate()
    {
        if(SelectedWeapon!=null)
        {
           SelectedWeapon.GetComponent<Weapon>().UIDeactivate();
        }
    }
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
