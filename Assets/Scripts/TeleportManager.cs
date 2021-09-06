using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider; 
    private InputAction activate,cancel,Thumbstick;
    private bool _isActive;
    // Start is called before the first frame update

    public void HandReflect()
    {
        if(activate!=null)
        {
            activate.Disable();
            activate.performed-= OnTeleportActivate;
        }
        if(cancel!=null)
        {
        cancel.Disable();
        cancel.performed-=OnTeleportCancel;
        }
        if(GameObject.Find("DataManager").GetComponent<SaveData>().getHand()==0)
        {
            rayInteractor = GameObject.Find("LeftHand Controller").GetComponent<XRRayInteractor>();
            
            activate= actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
            activate.Enable();
            activate.performed+= OnTeleportActivate;

            cancel= actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Cancel");
            cancel.Enable();
            cancel.performed +=OnTeleportCancel;


            Thumbstick= actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
            Thumbstick.Enable();
        }
        else
        {
            rayInteractor = GameObject.Find("RightHand Controller").GetComponent<XRRayInteractor>();

            activate= actionAsset.FindActionMap("XRI RightHand").FindAction("Teleport Mode Activate");
            activate.Enable();
            activate.performed+= OnTeleportActivate;

            cancel= actionAsset.FindActionMap("XRI RightHand").FindAction("Teleport Mode Cancel");
            cancel.Enable();
            cancel.performed +=OnTeleportCancel;


            Thumbstick= actionAsset.FindActionMap("XRI RightHand").FindAction("Move");
            Thumbstick.Enable();

        }
    }
    private void OnEnable() 
    {

    }
    private void OnDisable() 
    {
        activate.Disable();
        cancel.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if(!_isActive)
            return;
        if(Thumbstick.triggered)
            return;

        if(!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled=false;
            _isActive=false;
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point
        };

        provider.QueueTeleportRequest(request);
        rayInteractor.enabled=false;
        _isActive =false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled=true;
        _isActive = true;
    }
    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled=false;
        _isActive =false;
    }
}
