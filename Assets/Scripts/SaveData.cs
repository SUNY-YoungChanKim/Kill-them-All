using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
public class SaveData : MonoBehaviour
{
    public class data
    {
        public int Primaryhand,MovementMethod,TurnMethod;
        public float turnspeed,turnangle, FOV, Height;
        
        public data()
        {
            Primaryhand=1;
            MovementMethod=0;
            TurnMethod=0;

            turnangle=0.1f;
            turnspeed=0.1f;
            FOV=0.1f;
            Height=0.1f;
        }
        

    }
    public data dataset;
    private void Start() 
    {
        dataset=Load();

        if(dataset==null)dataset=new data();

    }
    public void Save()
    {
        string DatatoJson = JsonUtility.ToJson(dataset);
        SaveFile(DatatoJson);
    }

     public data Load()
    {
        if(!File.Exists(GetPath()))
        {
            Debug.Log("세이브 파일이 존재하지 않음.");
            return null;
        }
 
        string encryptData = LoadFile(GetPath());
        data sd = JsonUtility.FromJson<data>(encryptData);
        return sd;
    }
     public void SaveFile(string jsonData)
    {
        using (FileStream fs = new FileStream(GetPath(), FileMode.Create, FileAccess.Write))
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
            fs.Write(bytes, 0, bytes.Length);
        }
    }
    public string LoadFile(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, (int)fs.Length);
            string jsonString = System.Text.Encoding.UTF8.GetString(bytes);
            return jsonString;
        }
    }
    public string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, "1.sv");
    }
    public int getHand()
    {
        return dataset.Primaryhand;
    }
    public int getTurnMethod()
    {
        return dataset.TurnMethod;
    }
}
