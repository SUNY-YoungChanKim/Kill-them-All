using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject LHSprite,RHSprite;
    [SerializeField] private int Hp;
    [SerializeField] private float HittableTime;
    [SerializeField] private GameObject HitEffect;
    [SerializeField] private AudioSource HitSound;
    [SerializeField] private ParticleSystem RegenEffect;
    [SerializeField] private AudioSource RegenSound;
    [SerializeField] private AudioSource CoinGainSound;
    [SerializeField] private Text Cointext;
    private List<GameObject> hpList;
    private bool Behit=true;
    private int currentHp;
    private GameObject UICanvas;
    private int money;
    // Start is called before the first frame update
    void Start()
    {
        UICanvas=GameObject.Find("UICanvas");
        GenerateHPUI();
        currentHp=Hp-1;
        money=0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GenerateHPUI()
    {
        hpList=new List<GameObject>();
        for(int i=0;i<Hp;i++)
        {
            GameObject t;
            if(i%2==0)
                 t= Instantiate(LHSprite,new Vector3(0,0,0),Quaternion.identity);
            else
                 t= Instantiate(RHSprite,new Vector3(0,0,0),Quaternion.identity);

            t.transform.SetParent(UICanvas.transform);
            t.transform.localPosition=new Vector3(((int)(Hp/2)-1)*-50f+((int)i/2)*100f,-300,0);
            t.transform.localEulerAngles=new Vector3(0,0,-180.0f);

            hpList.Add(t);
            
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag=="Monster"||other.transform.tag=="GB")
        {
            Hit();
        }

    }
    public bool GenerateHP()
    {
        if(currentHp<Hp)
        {
            currentHp+=1;
            hpList[currentHp].GetComponent<RawImage>().color=new Color(255,0,0);
            if(RegenEffect.isPlaying==false)RegenEffect.Play();
            if(RegenSound.isPlaying==false)RegenSound.Play();
            return true;
        }
        return false;
    }
    private void Hit()
    {
        if(Behit==true)
        {
            Behit=false;
            Invoke("Hitchange",HittableTime);

            HitEffect.GetComponent<Animator>().SetTrigger("Play");
            if(HitSound.isPlaying!=true)HitSound.Play();

            hpList[currentHp--].GetComponent<RawImage>().color=new Color(255,255,255);
        }

    }
    private void Hitchange()
    {
        Behit=true;
    }
    public void Gain()
    {
        if(CoinGainSound.isPlaying==false)CoinGainSound.Play();
        money++;
        Cointext.text=money.ToString();
    }
    
}
