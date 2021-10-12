using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapGenerator : MonoBehaviour
{
    public int length;
    [SerializeField] private GameObject[] Tileset;
    [SerializeField] private GameObject Blockwall,Doorwall,Asile;
    private int[,] field; 

    // Start is called before the first frame update
    void Start()
    {
  
        field = new int [length,length];

        intialize();
        maze();
        print();

        
    }
    void intialize()
    {
        for(int i=0;i<length;i++)
            for(int j=0;j<length;j++)
            {
                field[i,j]= -1;
                Instantiate(Tileset[Random.Range(0,Tileset.Length)], new Vector3(-250-i*250,-5,-250 + j*250),Quaternion.identity).transform.SetParent(this.transform);
            }
        
        for(int i=0;i<length;i++)
        {
            Instantiate(Blockwall, new Vector3(-250-i*250,-5,-250-100),Quaternion.Euler(-90,0,90)).transform.SetParent(this.transform);
            Instantiate(Blockwall, new Vector3(-250-i*250,-5,-250 + length*250-150),Quaternion.Euler(-90,0,90)).transform.SetParent(this.transform);
            Instantiate(Blockwall, new Vector3(-250-length*250+150,-5,-250 + i*250),Quaternion.Euler(-90,0,0)).transform.SetParent(this.transform);
        }

        for(int i=0;i<length;i++)
            if(i!=1)
               Instantiate(Blockwall, new Vector3(-250+100,-5,-250 + i*250),Quaternion.Euler(-90,0,0)).transform.SetParent(this.transform);
        
        Instantiate(Doorwall, new Vector3(-150,-5,0),Quaternion.Euler(0,0,0)).transform.SetParent(this.transform);
    }

    private bool Closed(int line)
    {
        for(int i=0;i<length;i++)
            if(field[line,i]==-1)return false;
        return true;
    }
    private void print()
    {
        string text;
        for(int i=0;i<length;i++)
        {
            text="";
            for(int j=0;j<length;j++)
            {
                text+=field[i,j]+" ";
            }
            Debug.Log(text);
        }
    }
    private void maze()
    {
        int groupnumber =1;
        field[0,0]=groupnumber++;
        for(int i=1;i<length;i++)
        {
             field[0,i]=groupnumber++;
            if(Random.Range(0,2)==0)
            {


                Instantiate(Doorwall,new Vector3(-250 ,-5,-400+i*250),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
                Instantiate(Doorwall,new Vector3(-250 ,-5,-400+i*250+50),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
                Instantiate(Asile,new Vector3(-250 ,-5,-400+i*250+5),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
                field[0,i]=field[0,i-1];
            }      
            else
            {
                Instantiate(Blockwall,new Vector3(-250,-5,-400+i*250),Quaternion.Euler(-90,0,90)).transform.SetParent(this.transform);
                Instantiate(Blockwall,new Vector3(-250 ,-5,-400+i*250+50),Quaternion.Euler(-90,0,90)).transform.SetParent(this.transform);
            }
        }
        for(int i=0;i<length;)
        {

                int l=i;
                int k=l;
                int targetgroupnum=field[0,i];
                int r;

                while(true)
                {
                  if(k>=length||field[0,k]!=targetgroupnum)break;
                  else k++;
                }
                
                r=Random.Range(l,k);


                field[1,r]=field[0,r];
                i=k;
        }

        for(int i=0;i<length;i++)
        {
            if(field[0,i]==field[1,i])
            {
                Instantiate(Doorwall,new Vector3(-350,-7,-250+i*250),Quaternion.Euler(0,180,0)).transform.SetParent(this.transform);
                Instantiate(Doorwall,new Vector3(-400,-7,-250+i*250),Quaternion.Euler(0,180,0)).transform.SetParent(this.transform);
                Instantiate(Asile,new Vector3(-367,-5,-250+i*250),Quaternion.Euler(0,0,0)).transform.SetParent(this.transform);
            }
            else
            {
                Instantiate(Blockwall,new Vector3(-350,-7,-250+i*250),Quaternion.Euler(-90,0,180)).transform.SetParent(this.transform);
                Instantiate(Blockwall,new Vector3(-400,-7,-250+i*250),Quaternion.Euler(-90,0,180)).transform.SetParent(this.transform);
            }
        }

        for(int i=1;i<length-1;i++)
        {
            while(Closed(i)==false)
            {
                for(int j=0;j<length;j++)
                {
                    if(field[i,j]==-1)
                    {
                        if(j==0)
                        {
                            field[i,j]=field[i,j+1];
                        }
                        else if(j==length-1)
                        {
                            field[i,j]=field[i,j-1];
                        }
                        else
                        {
                            int r = Random.Range(0,2);
                            
                            if(field[i,j-1]==0)field[i,j]=field[i,j+1];
                            else if(field[i,j+1]==0)field[i,j]=field[i,j-1];
                            else
                            {
                                if(r==0)field[i,j]=field[i,j-1];
                                else field[i,j]=field[i,j+1];
                            }
                        }
                    }

                }
            }

            for(int j=0;j<length;)
            {

                int l=j;
                int k=l;
                int targetgroupnum=field[i,j];
                int r;

                while(true)
                {
                if(k>=length||field[i,k]!=targetgroupnum)break;
                else k++;
                }
                
                r=Random.Range(l,k);


                field[i+1,r]=field[i,r];
                j=k;
            }
            for(int j=0;j<length;j++)
            {
                if(j<length-1)
                {
                    if(field[i,j]==field[i,j+1])
                    {
                        Instantiate(Doorwall,new Vector3(-250-i*250,-5,-150+j*250),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
                        Instantiate(Doorwall,new Vector3(-250-i*250,-5,-150+j*250+50),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
                        Instantiate(Asile,new Vector3(-250-i*250,-5,-150+j*250+5),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
                    }
                    else
                    {
                        if(Random.Range(0,2)==0)
                        {
                            Instantiate(Blockwall,new Vector3(-250-i*250,-5,-150+j*250),Quaternion.Euler(-90,0,90)).transform.SetParent(this.transform);
                            Instantiate(Blockwall,new Vector3(-250-i*250,-5,-150+j*250+50),Quaternion.Euler(-90,0,90)).transform.SetParent(this.transform);
                        }
                        else
                        {
                            Instantiate(Doorwall,new Vector3(-250-i*250,-5,-150+j*250),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
                            Instantiate(Doorwall,new Vector3(-250-i*250,-5,-150+j*250+50),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
                            Instantiate(Asile,new Vector3(-250-i*250,-5,-150+j*250+5),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
                        }
                    }
                }
                if(field[i,j]==field[i+1,j])
                {
                    Instantiate(Doorwall,new Vector3(-350-i*250,-7,-250+j*250),Quaternion.Euler(0,180,0)).transform.SetParent(this.transform);
                    Instantiate(Doorwall,new Vector3(-400-i*250,-7,-250+j*250),Quaternion.Euler(0,180,0)).transform.SetParent(this.transform);
                    Instantiate(Asile,new Vector3(-367-i*250,-5,-250+j*250),Quaternion.Euler(0,0,0)).transform.SetParent(this.transform);
                }
                else
                {
                    Instantiate(Blockwall,new Vector3(-350-i*250,-7,-250+j*250),Quaternion.Euler(-90,0,180)).transform.SetParent(this.transform);
                    Instantiate(Blockwall,new Vector3(-400-i*250,-7,-250+j*250),Quaternion.Euler(-90,0,180)).transform.SetParent(this.transform);
                }
                
            }
        }
        for(int j=0;j<length-1;j++)
        {
            field[length-1,j]=0;
            Instantiate(Doorwall,new Vector3(-250-(length-1)*250,-5,-150+j*250),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
            Instantiate(Doorwall,new Vector3(-250-(length-1)*250,-5,-150+j*250+50),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
            Instantiate(Asile,new Vector3(-250-(length-1)*250,-5,-150+j*250+5),Quaternion.Euler(0,90,0)).transform.SetParent(this.transform);
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
