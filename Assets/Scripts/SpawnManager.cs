using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]private List<GameObject> Spawns;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag=="Player")
        {
            CreateNDestory();
        }
        
    }

    private void CreateNDestory()
    {
        foreach(var Target in Spawns)
        {
            Target.GetComponent<SpawnMonster>().SpawnStart();
        }

        Destroy(this.gameObject);
    }
}
