using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField]private GameObject BulletImpactsound;
    [SerializeField]private ParticleSystem BulletEffect;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.back*Time.deltaTime*Speed);
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag=="Monster")
        {
            other.gameObject.GetComponent<MonsterAI>().Dead(); 
        }
        Instantiate(BulletImpactsound,this.transform.position,Quaternion.identity);
        Instantiate(BulletEffect,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
