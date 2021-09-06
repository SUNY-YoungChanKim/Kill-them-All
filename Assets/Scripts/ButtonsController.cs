using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class ButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject TSslider, TAslider,FOVslider,Heightslider,TsText,TaText;
    private GameObject PHandB,MChageB,TChageB;
    private int PrimaryLhand=0,MovementMethod=0,TurnMethod=0;
    private float turnspeed=0.1f,turnangle=0.1f,Fov=0.1f,Height=0.1f;
    private GameObject FOVText,HeightText;

    private GameObject locomotion;

    private Vector2 pBleft,pBRight,mBLeft,mBRight,tBLeft,tBRight;

    private void Start() 
    {

    }
    private void OnEnable() 
    {

        pBleft=new Vector2(0,11.35f);
        pBRight=new Vector2(6,11.35f);
        mBLeft = new Vector2(0,9.95f);
        mBRight = new Vector2(6,9.95f);
        tBLeft = new Vector2(0,8.55f);
        tBRight = new Vector2(6,8.55f);
        PHandB=GameObject.Find("PrimaryHandChange");
        MChageB=GameObject.Find("MovementChange");
        TChageB=GameObject.Find("TurnChange");
        locomotion =GameObject.Find("Locomotion System");

  
        FOVText=GameObject.Find("FOVText");
        HeightText=GameObject.Find("HeightText");
        
        GameObject DataManager= GameObject.Find("DataManager");
        PrimaryLhand = DataManager.GetComponent<SaveData>().dataset.Primaryhand;
        MovementMethod=DataManager.GetComponent<SaveData>().dataset.MovementMethod;
        TurnMethod=DataManager.GetComponent<SaveData>().dataset.TurnMethod;
        turnspeed=DataManager.GetComponent<SaveData>().dataset.turnspeed;
        turnangle=DataManager.GetComponent<SaveData>().dataset.turnangle;
        Fov= DataManager.GetComponent<SaveData>().dataset.FOV;
        Height= DataManager.GetComponent<SaveData>().dataset.Height;


        TSslider.GetComponent<Slider>().value=turnspeed;
        TAslider.GetComponent<Slider>().value=turnangle;
        FOVslider.GetComponent<Slider>().value=Fov;
        Heightslider.GetComponent<Slider>().value=Height;


        UIUpdate();
    }
    private void OnDisable() 
    {
        GameObject DataManager= GameObject.Find("DataManager"); 
        DataManager.GetComponent<SaveData>().dataset.Primaryhand=PrimaryLhand;
        DataManager.GetComponent<SaveData>().dataset.MovementMethod=MovementMethod;
        DataManager.GetComponent<SaveData>().dataset.TurnMethod=TurnMethod;
        DataManager.GetComponent<SaveData>().dataset.turnspeed=turnspeed;
        DataManager.GetComponent<SaveData>().dataset.turnangle=turnangle;
        DataManager.GetComponent<SaveData>().dataset.FOV=Fov;
        DataManager.GetComponent<SaveData>().dataset.Height=Height;
        DataManager.GetComponent<SaveData>().Save();
    }

    public void UIUpdate()
    {
        if(PrimaryLhand==0)
        {
            PHandB.GetComponent<RectTransform>().anchoredPosition=pBleft;
            GameObject.Find("PText").GetComponent<Text>().text="Left";
            

        }
        else
        {
            PHandB.GetComponent<RectTransform>().anchoredPosition=pBRight;
            GameObject.Find("PText").GetComponent<Text>().text="Right";
        }



        if(MovementMethod==0)
        {
            MChageB.GetComponent<RectTransform>().anchoredPosition=mBLeft;
            GameObject.Find("MText").GetComponent<Text>().text="Direct";

        }
        else
        {
            MChageB.GetComponent<RectTransform>().anchoredPosition=mBRight;
            GameObject.Find("MText").GetComponent<Text>().text="Teleport";
        }


        if(TurnMethod==0)
        {
            TChageB.GetComponent<RectTransform>().anchoredPosition=tBLeft;
            GameObject.Find("TText").GetComponent<Text>().text="Direct";


        }
        else
        {
            TChageB.GetComponent<RectTransform>().anchoredPosition=tBRight;
            GameObject.Find("TText").GetComponent<Text>().text="Snap";
        }


        if(TurnMethod==0)
        {
            TSslider.SetActive(true);
            TAslider.SetActive(false);
        }
        else
        {               
            TSslider.SetActive(false);
            TAslider.SetActive(true);
        }


        if(TsText.GetComponent<Text>()!=null)TsText.GetComponent<Text>().text= (Mathf.RoundToInt(turnspeed*100)).ToString();
        if(FOVText.GetComponent<Text>().text!=null)FOVText.GetComponent<Text>().text= (Mathf.RoundToInt(Fov*100)).ToString();
        if(HeightText.GetComponent<Text>()!=null)HeightText.GetComponent<Text>().text=(Mathf.RoundToInt(Height*100)).ToString();
        if(TaText.GetComponent<Text>()!=null)TaText.GetComponent<Text>().text=(Mathf.RoundToInt(turnangle*100)).ToString();
    }
    public void HandChange()
    {
        if(PrimaryLhand==1)
            PrimaryLhand=0;
        else
            PrimaryLhand=1;

        UIUpdate();


    }
    public void MovementChange()
    {
        if(MovementMethod==1)
            MovementMethod=0;
        else
            MovementMethod=1;

        UIUpdate();

    }

    public void TurnChange()
    {
        if(TurnMethod==1)
        {
            TurnMethod=0;
        }
        else
        {               
            TurnMethod=1;
        }
        UIUpdate();

    }

 
    public void TSChange()
    {
        turnspeed=TSslider.GetComponent<Slider>().value;
        UIUpdate();
    }
    public void TAchange()
    {
        turnangle=TAslider.GetComponent<Slider>().value;
        UIUpdate();
    }
    public void FOVChange()
    {
        Fov=FOVslider.GetComponent<Slider>().value;
        UIUpdate();
    }
    public void HeightChange()
    {
        Height=Heightslider.GetComponent<Slider>().value;
        UIUpdate();
    }
    public int getHand()
    {
        return PrimaryLhand;
    }
}
