using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIhandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().ResetTrigger("Close");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RemoveItself()
    {
        Destroy(GameObject.Find("Canvas(Clone)"));
    }


}
