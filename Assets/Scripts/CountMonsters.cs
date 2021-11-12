using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountMonsters : MonoBehaviour
{
    [SerializeField]private int count=0;
    // Start is called before the first frame update
    public void Increase()
    {
        count++;

    }
    public void Decrease()
    {
        count--;
    }
    public int GetCount()
    {
        return count;
    }
}
