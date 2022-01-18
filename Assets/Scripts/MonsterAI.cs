using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterAI : MonoBehaviour
{
    [Serializable] public struct GenerableItem
    {
        public GameObject Item;
        public float Percent;
    }
    private NavMeshAgent NavMesh;
    private GameObject Player;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float AttackCoolTime;
    [SerializeField] private float AttackDistance;
    [SerializeField] private GameObject AttakPos;
    [SerializeField] private AudioSource HitSound;

    [SerializeField] private List<GenerableItem> GenerableItemList;
    private GameObject StatusManager;


    private Animator Animator;
    private bool CanAttack =true;
    private bool ItemGenerate=false;

    private float Distance;
    private string State="Caculate";
    private float MovingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        NavMesh=GetComponent<NavMeshAgent>();  
        MovingSpeed=NavMesh.speed;
        Player=GameObject.FindGameObjectWithTag("Player");
        Animator=this.GetComponent<Animator>();
        StatusManager=GameObject.Find("StatusManager");
        StatusManager.GetComponent<CountMonsters>().Increase();
    }

    // Update is called once per frame
    void Update()
    {
        NavMesh.destination = Player.transform.position;
        if(State=="Caculate")
        {
            Distance= Mathf.Sqrt(Mathf.Pow(Mathf.Abs(this.transform.position.x - Player.transform.position.x),2)
                    +Mathf.Pow(Mathf.Abs(this.transform.position.z - Player.transform.position.z),2));

           if(Distance>AttackDistance)
            {
                NavMesh.speed=MovingSpeed;

                Animator.SetInteger("Status",1);
            }
            else  
            {
                NavMesh.speed=0.1f;
                if(CanAttack==true)
                {
                    State="Attacking";
                    Animator.SetInteger("Status",2);
                }
            }
        }
    }
    public void SetCaculateStatus()
    {
        State="Caculate";
        Animator.SetInteger("Status",0);
    }
    public void Fire()
    {
        if(State!="Dying")
        {
            GameObject t =Instantiate(Bullet,AttakPos.transform.position,Quaternion.Euler(-90,0,this.transform.rotation.eulerAngles.y+100));
            if(t.GetComponent<Bullet>()!=null)t.GetComponent<Bullet>().Init(Player.transform.position);
        }

       CanAttack=false;
       Invoke("CanAttackChange",AttackCoolTime);
    }
    private void CanAttackChange()
    {
        CanAttack=true;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag=="LHand"||other.transform.tag=="RHand"||other.transform.tag=="Player"||other.transform.tag=="XRRig")
            Dead();    
    }
    private void Destoryobj()
    {
        Destroy(this.gameObject);
        StatusManager.GetComponent<CountMonsters>().Decrease();
    }
    private void GenerateItem()
    {
        int seed;
        foreach(var item in GenerableItemList)
        {
            seed =UnityEngine.Random.Range(0,100);
            if(seed<=item.Percent)
            {
                Instantiate(item.Item,this.transform.position+new Vector3(0,2,0),Quaternion.identity);
                return;
            }
        }
    }
    public void Dead()
    {
        State="Dying";
        NavMesh.speed=0.1f;
        Animator.SetInteger("Status",3);
        if(ItemGenerate==false)
        {
            ItemGenerate=true;
            GenerateItem();
        }
    }
}
