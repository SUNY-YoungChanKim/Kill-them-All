using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatarecordMove : MonoBehaviour
{
    public float StartZpos=0;
    public float EndzPos=0;
    public float Speed=4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Speed);

     
        if(this.gameObject.transform.position.z-this.gameObject.transform.parent.position.z<=EndzPos)
        {

            Vector3 Posset=this.gameObject.transform.position;
            this.gameObject.transform.position=new Vector3(Posset.x,Posset.y,StartZpos+this.gameObject.transform.parent.position.z);
        }
    }
}
