using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct UserInfo
{
    public int age;
    public int height;
    public string name;
    public int weight;
    public string[] family;
}


public class JsonSample : MonoBehaviour
{
    public UserInfo info = new UserInfo();

    void Start()
    {
        
    }

    void InitData()
    {
        info.age = 10;
        info.height = 150;
        info.name = "이름";
        info.family = new string[4];
        info.family[0] = "아빠";
        info.family[1] = "엄마";
        info.family[2] = "나";
        info.family[3] = "동생";
    }

    void SaveData()
    {
        string jsonData = JsonUtility.ToJson(info, true);
        print(jsonData);

        FileStream file = new FileStream(Application.dataPath + "/myInfo.txt", FileMode.Create);

        byte[] byteData = Encoding.UTF8.GetBytes(jsonData);

        file.Write(byteData, 0, byteData.Length);
        file.Close();

        //PlayerPrefs.SetString("MyInfo", jsonData);
    }

    void LoadData()
    {
        FileStream file = new FileStream(Application.dataPath + "/myInfo.txt", FileMode.Open);
        byte[] byteData = new byte[file.Length];
        file.Read(byteData, 0, byteData.Length);
        file.Close();

        string jsonData = Encoding.UTF8.GetString(byteData);

        //string jsonData = PlayerPrefs.GetString("MyInfo");
        //print(jsonData);

        info = JsonUtility.FromJson<UserInfo>(jsonData);

        print(info.name);
        print(info.age);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadData();
        }
    }
}
        
