using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDetect : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps=this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void OnCollisionExit(Collision other) {
        if(other.transform.tag=="Weapon")
        {
            ps.Stop();
        }
    }
}
