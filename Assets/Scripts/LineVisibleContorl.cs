using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class LineVisibleContorl : MonoBehaviour
{
    [SerializeField] private XRRayInteractor XRRayInteractor;
    [SerializeField] private TeleportationProvider TPprovider;
    [SerializeField] private TeleportManager TeleportManager;
    [SerializeField] private bool isLeft;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(XRRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if(hit.collider.gameObject.tag=="Weapon" || hit.collider.gameObject.tag=="GB")
            {
                this.GetComponent<XRInteractorLineVisual>().enabled=true;
            }
            else if(Time.timeScale==0)
            {
                this.GetComponent<XRInteractorLineVisual>().enabled=true;
            }
            else if(TeleportManager._isActive==true)
            {
                this.GetComponent<XRInteractorLineVisual>().enabled=true;
            }
            else
            {
                this.GetComponent<XRInteractorLineVisual>().enabled=false;
            }
        }
    }
}
