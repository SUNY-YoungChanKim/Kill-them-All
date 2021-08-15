using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recordcreater : MonoBehaviour
{
    public GameObject type1;
    public GameObject type2;
    public GameObject type3;
    public GameObject type4;
    public GameObject type5;
    public GameObject type6;
    private GameObject target;
    public float CreateDelay;
    private float Ran1;
    private float Ran2;
    private float Ran3;
    private int Ran4;
    public float YArea;
    public float XArea;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Create",CreateDelay);
    }
    void Create()
    {
        Ran1=Random.Range(1,scale);
        Ran2=Random.Range(1,scale);
        Ran3=Random.Range(1,scale);
        Ran4=Random.Range(1,6);


        switch(Ran4)
        {
            case 1:
                target=Instantiate(type1);
                break;
            case 2:
                target=Instantiate(type2);
                break;
            case 3:
                target=Instantiate(type3);
                break;
            case 4:
                target=Instantiate(type4);
                break;
            case 5:
                target=Instantiate(type5);
                break;
            default:
                target=Instantiate(type6);
                break;
        }


        target.transform.position= this.transform.position+new Vector3(Random.Range(0,XArea),Random.Range(0,YArea),0);
        target.transform.localScale=new Vector3(Ran1,Ran2,Ran3);
        target.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-Ran4*1000));
        target.transform.parent=this.transform;
        Invoke("Create",CreateDelay);

    }
}
