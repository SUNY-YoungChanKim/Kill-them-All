using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField]private float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destoryself",time);   
    }

    // Update is called once per fram
    void Destoryself()
    {
        Destroy(this.gameObject);
    }
}
