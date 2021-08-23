using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private InputActionReference UIPress;
    private bool opened;

    public GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        UIPress.action.performed += UIshow;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void UIshow(InputAction.CallbackContext obj)
    {
        Debug.Log("IN");
        if( GameObject.Find("Canvas(Clone)")==null)
        {
            Instantiate(Canvas,GameObject.Find("CanvasLocation").transform.position,GameObject.Find("Main Camera").transform.rotation);
            Time.timeScale=0;

        }
        else
        {
            GameObject.Find("Canvas(Clone)").GetComponent<Animator>().SetTrigger("Close");
            Time.timeScale=1.0f;
        }
            
    }

}