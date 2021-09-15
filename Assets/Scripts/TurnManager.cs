using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private SaveData Datamanager;
    private bool ContinuousTurn;
    private InputAction Turn;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnEnable() 
    {
        if(Datamanager.getHand()==0)
        {
            Turn=actionAsset.FindActionMap("XRI LeftHand").FindAction("Turn");
        }
        else
        {
            Turn=actionAsset.FindActionMap("XRI RightHand").FindAction("Turn");
        }


        if(Datamanager.getTurnMethod()==0)
        {
            Turn.performed+=SnapTurn;
            ContinuousTurn=true;
        }
        else
        {
           Turn.performed+=SnapTurn;
        }
    }
    private void OnDisable() 
    {
        Turn=null;
        Turn.performed-=SnapTurn;

    }
    // Update is called once per frame
    void Update()
    {

        if(Turn.triggered)
        {
            Debug.Log("ContinuousTurn");
        }        
    }
    void SnapTurn(InputAction.CallbackContext obj)
    {
        Debug.Log("SNAPTURN");
    }
}
