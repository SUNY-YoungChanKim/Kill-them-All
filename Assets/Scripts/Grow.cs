using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Duration;
    private Vector3 target;
    private bool Growing;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start() 
    {

        target=this.transform.localScale;
    }
    void Update()
    {
        if(target!=this.transform.localScale)
        {
            this.transform.localScale=Vector3.MoveTowards(this.transform.localScale,target,Time.deltaTime*speed);
        }
        
    }
    public void Acitve()
    {
        target=this.transform.localScale*2;
        Invoke("Deacitave",Duration);

    }
    public void Deacitave()
    {
        target=this.transform.localScale/2;
    }

}
