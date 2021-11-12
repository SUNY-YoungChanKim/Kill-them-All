using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeshVisibleControl : MonoBehaviour
{
    [SerializeField]public GameObject HandModel;
    [SerializeField]public XRRayInteractor RayInteractor;
    // Start is called before the first frame update

    public void MeshHide()
    {
        if(RayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if(hit.transform.gameObject.tag=="Weapon")
                HandModel.GetComponent<SkinnedMeshRenderer>().enabled=false;
        }
    }
    public void MeshShow()
    {
        HandModel.GetComponent<SkinnedMeshRenderer>().enabled=true;
    }
}
