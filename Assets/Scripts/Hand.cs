using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    [SerializeField] private GameObject Model;
    public float speed;

    Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string GripParam= "Grip";
    private string TriggerParam= "Trigger";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }
    internal void SetGrip(float v)
    {
        gripTarget = v;
    }
    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }
    void AnimateHand()
    {
        if(gripCurrent!=gripTarget)
        {


            gripCurrent = Mathf.MoveTowards(gripCurrent,gripTarget,Time.deltaTime*speed);
            animator.SetFloat(GripParam,gripCurrent);

        }        
        if(triggerCurrent!=triggerTarget)
        {
            
            triggerCurrent = Mathf.MoveTowards(triggerCurrent,triggerTarget,Time.deltaTime*speed);
            animator.SetFloat(TriggerParam,triggerCurrent);


            
        }
    }
}
