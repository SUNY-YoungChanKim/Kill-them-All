using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapGenerator : MonoBehaviour
{
    public int length;
    private int[,] field; 

    // Start is called before the first frame update
    void Start()
    {
        int groupnumber =1;
        field = new int [length,length];

        intialize();
     

        for(int i=0;i<length;i++)
        {
            for(int j=0;j<length;j++)
                if(field[i,j]==-1)
                    field[i,j]=groupnumber++;
            for(int j=1;j<length;j++)
            {
                if(field[i,j]==-1)
                {
                    if(Random.Range(0,2)==0)
                        field[i,j]=field[i,j-1];
                }
            }
            if(i!=length-1)
            {
                for(int j=0;j<length;j++)
                {
                    if(Random.Range(0,2)==0)
                        field[i+1,j]=field[i,j];
                }
            }
        }
    }
    void intialize()
    {
        for(int i=0;i<length;i++)
            for(int j=0;j<length;j++)
                field[i,j]= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
