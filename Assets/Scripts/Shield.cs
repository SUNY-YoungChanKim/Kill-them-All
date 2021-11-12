using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag=="Bullet")
        {
            Debug.Log("Hit");
            Destroy(other.transform.gameObject);
            if(sound.isPlaying!=true)sound.Play();
        }    
    }
}
