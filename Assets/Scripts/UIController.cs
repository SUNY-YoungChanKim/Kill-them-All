using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UIController : MonoBehaviour
{
    [SerializeField] private InputActionReference UIPress;
    [SerializeField] private InputActionReference LMove,RMove,lTurn,RTurn;
    [SerializeField] private GameObject LeftHandController,RightHandController;
    private GameObject Locomotion;
    private GameObject DataManager;
    public GameObject MainMenu;
    public GameObject Setting;
    private GameObject tMenu,tCam,tUIloc;
    private Vector3 tPos;
    private Quaternion tRot;

    private int PrimaryLhand=0,MovementMethod=0,TurnMethod=0;
    private float turnspeed=0.1f,turnangle=0.1f,Fov=0.1f,Height=0.1f;

    private int UIstatus=0;
    // Start is called before the first frame update
    void Start()
    {
        UIPress.action.performed += UIshow;
        tCam=GameObject.Find("Main Camera");
        tUIloc=GameObject.Find("CanvasLocation");
        DataManager= GameObject.Find("DataManager");
        Locomotion =GameObject.Find("Locomotion System");

        Reflect();

    }
    private void load()
    {
        PrimaryLhand = DataManager.GetComponent<SaveData>().dataset.Primaryhand;
        MovementMethod=DataManager.GetComponent<SaveData>().dataset.MovementMethod;
        TurnMethod=DataManager.GetComponent<SaveData>().dataset.TurnMethod;
        turnspeed=DataManager.GetComponent<SaveData>().dataset.turnspeed;
        turnangle=DataManager.GetComponent<SaveData>().dataset.turnangle;
        Fov= DataManager.GetComponent<SaveData>().dataset.FOV;
        Height= DataManager.GetComponent<SaveData>().dataset.Height;
    }

    // Update is called once per frame
    public void resume()
    {
        Time.timeScale=1.0f;
        MainMenu.SetActive(false);
        UIstatus=0;
        LeftHandController.GetComponent<XRInteractorLineVisual>().enabled=false;
        RightHandController.GetComponent<XRInteractorLineVisual>().enabled=false;
        Reflect();
    }
    public void UIshow(InputAction.CallbackContext obj)
    {
        UIcreate();
    }
    public void UIcreate()
    {
        if(UIstatus==0)
        {
            tPos=tUIloc.transform.position;
            tRot=tCam.transform.rotation;
            this.transform.position=tPos;
            this.transform.rotation=tRot;
           
            MainMenu.SetActive(true);

            Time.timeScale=0;
            UIstatus=1;

            Locomotion.GetComponent<TeleportationProvider>().enabled=false;
            Locomotion.GetComponent<ContinuousMoveProviderBase>().enabled=false;
            Locomotion.GetComponent<SnapTurnProviderBase>().enabled=false;
            Locomotion.GetComponent<ContinuousTurnProviderBase>().enabled=false;
            Locomotion.GetComponent<TeleportManager>().enabled=false; 

            LeftHandController.GetComponent<XRInteractorLineVisual>().enabled=true;
          RightHandController.GetComponent<XRInteractorLineVisual>().enabled=true;

        }
        else if(UIstatus==1)
            resume();
        else if(UIstatus==2)
        {
            settingClose();
            UIstatus=1;
        }
    }
    
    public void settingShow()
    {
        MainMenu.SetActive(false);
        Setting.SetActive(true);
        UIstatus=2;
    }
    public void settingClose()
    {
        MainMenu.SetActive(true);
        Setting.SetActive(false);
        UIstatus=1;
    }

    private void Reflect()
    {
        load();
        ControllerHandReflect();
        MovementMethodReflect();
        TurnMethodReflect();
        TurnAngleReflect();
        TurnspeedReflect();
        HeightReflect();
    }

    private void MovementMethodReflect()
    {
        if(MovementMethod==0)
        {
            Locomotion.GetComponent<ContinuousMoveProviderBase>().enabled=true;

        }
        else
        {
            Locomotion.GetComponent<TeleportationProvider>().enabled=true;
            Locomotion.GetComponent<TeleportManager>().enabled=true;
            Locomotion.GetComponent<TeleportManager>().HandReflect();
        }
    }
    private void TurnMethodReflect()
    {
        if(TurnMethod==0)
        {
            Locomotion.GetComponent<ContinuousTurnProviderBase>().enabled=true;
        }
        else
        {
            Locomotion.GetComponent<SnapTurnProviderBase>().enabled=true;
        }
    }
    private void TurnspeedReflect()
    {
        Locomotion.GetComponent<ContinuousTurnProviderBase>().turnSpeed=(Mathf.RoundToInt(turnspeed*100))*2;
    }
    private void TurnAngleReflect()
    {
        Locomotion.GetComponent<SnapTurnProviderBase>().turnAmount=(Mathf.RoundToInt(turnangle*100))*1.8f;
    }
    private void HeightReflect()
    {
        GameObject.Find("XR Rig").GetComponent<XRRig>().cameraYOffset=1+(Mathf.RoundToInt(Height*100))*0.03f;
    }
    private void ControllerHandReflect()
    {
        if(PrimaryLhand==0)
        {
            Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().leftHandMoveAction = new InputActionProperty(LMove);
            Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().rightHandMoveAction = new InputActionProperty();

            Locomotion.GetComponent<ActionBasedContinuousTurnProvider>().leftHandTurnAction = new InputActionProperty();
            Locomotion.GetComponent<ActionBasedContinuousTurnProvider>().rightHandTurnAction = new InputActionProperty(RTurn);

            Locomotion.GetComponent<ActionBasedSnapTurnProvider>().leftHandSnapTurnAction = new InputActionProperty();
            Locomotion.GetComponent<ActionBasedSnapTurnProvider>().rightHandSnapTurnAction = new InputActionProperty(RTurn);
        }
        else
        {
            Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().leftHandMoveAction = new InputActionProperty();
            Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().rightHandMoveAction = new InputActionProperty(RMove);

            
            Locomotion.GetComponent<ActionBasedContinuousTurnProvider>().leftHandTurnAction = new InputActionProperty(lTurn);
            Locomotion.GetComponent<ActionBasedContinuousTurnProvider>().rightHandTurnAction = new InputActionProperty();


            Locomotion.GetComponent<ActionBasedSnapTurnProvider>().leftHandSnapTurnAction = new InputActionProperty(lTurn);
            Locomotion.GetComponent<ActionBasedSnapTurnProvider>().rightHandSnapTurnAction = new InputActionProperty();
        }

        Locomotion.GetComponent<TeleportManager>().HandReflect();
    }
}