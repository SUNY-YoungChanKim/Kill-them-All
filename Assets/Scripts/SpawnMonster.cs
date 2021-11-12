using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
     [SerializeField] private GameObject Monster;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        animator.SetTrigger("Spawn");
    }
    public void DestorySpawn()
    {
        Destroy(this.gameObject);
    }
    public void SpawnStart()
    {
        Instantiate(Monster,this.transform.position,Quaternion.identity);
    }
}
