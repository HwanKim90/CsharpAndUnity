using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            // �Ҹ�1
            SoundManager.instance.PlayEFT(SoundManager.EFT_TYPE.EFT_1);
            //SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_1);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // �Ҹ�2
            SoundManager.instance.PlayEFT(SoundManager.EFT_TYPE.EFT_2);
            //SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_2);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            // �Ҹ�3
            SoundManager.instance.PlayEFT(SoundManager.EFT_TYPE.EFT_3);
            //SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_3);
        }

    }
}
