using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    
    [SerializeField] private string HitEffectName;
    // Start is called before the first frame update
    void Start()
    {
       Destroy(this.gameObject,0.8f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
  
        if(other.transform.tag=="Player")
        {
            GameObject.Find(HitEffectName).GetComponent<EffectManager>().Play();
        }   
    }
}
