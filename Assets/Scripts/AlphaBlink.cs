using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaBlink : MonoBehaviour
{
    private Color Default;
    private bool fadein=true;
    [SerializeField] private float speed=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Default=this.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadein==true)
        {
            Default.a-=Time.deltaTime*1.0f;
            if(Default.a<=0)fadein=false;
        }
        else
        {
            Default.a+=Time.deltaTime*1.0f;
            if(Default.a>=255)fadein=true;
        }
        this.GetComponent<SpriteRenderer>().color=Default;
    }
}
