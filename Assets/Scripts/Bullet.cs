using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private Vector3 Target;
   private float inclination,inclination2;
    [SerializeField] private float Speed;
    [SerializeField] public bool set=false;
    [SerializeField] private string HitEffectName;

    // Start is called before the first frame update
    // Update is called once per frame
    public void Init(Vector3 t)
    {
        Target=t;
        set=true;
        inclination= (this.transform.position.z-t.z)/(this.transform.position.x-t.x);
        inclination2=(this.transform.position.y-t.y)/(this.transform.position.x-t.x);
        if(this.transform.position.x>=t.x)
        {
            Target= new Vector3(this.transform.position.x-1000,Target.y,(this.transform.position.x-1000)*inclination);
        }
        else
        {
            Target= new Vector3(this.transform.position.x+1000,Target.y,(this.transform.position.x+1000)*inclination);
        }
        this.GetComponent<Rigidbody>().AddTorque(new Vector3(3,0,3));
    }
    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,Target,Time.deltaTime*Speed);
    }
    private void DestroyObejct()
    {

        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision other) 
    {
  
    }
}
