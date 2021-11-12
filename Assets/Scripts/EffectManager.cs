using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private Animator animator;
    private string Status="None";
    [SerializeField] private AudioSource Sound;
    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Play()
    {
        if(Status=="None")
        {
            animator.SetTrigger("Play");
            Status="Play";
            if(Sound.isPlaying==false)Sound.Play();
        }
    }
    void PlayExit()
    {
        Status="None";
        animator.SetTrigger("Exit");
    }
}
