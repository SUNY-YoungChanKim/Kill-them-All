using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private Vector3 Target;
    [SerializeField] private float Speed;
    [SerializeField] public bool set=false;
    [SerializeField] private string HitEffectName;
    // Start is called before the first frame update
    // Update is called once per frame
    public void Init(Vector3 t)
    {
        Target=t;
        set=true;
    }
    private void Update()
    {
        if(set==true)
            this.transform.position = Vector3.MoveTowards(this.transform.position,Target,Time.deltaTime*Speed);

        if(this.transform.position==Target)
            Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision other) 
    {
  
        if(other.transform.tag=="Player")
        {
            Destroy(this.gameObject);
            GameObject.Find(HitEffectName).GetComponent<EffectManager>().Play();
        }   
    }
}
