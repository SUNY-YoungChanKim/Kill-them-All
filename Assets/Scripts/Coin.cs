using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]private float speed=1.0f;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
        target=GameObject.Find("LeftHand Controller");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position=Vector3.MoveTowards(this.transform.position,target.transform.position,Time.deltaTime*speed);
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag=="LHand")
        {

           GameObject.Find("XR Rig").GetComponent<PlayerControl>().Gain();
            Destroy(this.gameObject);
        }
    }
}
