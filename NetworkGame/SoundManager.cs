using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    //BGM 종류
    public enum BGM_TYPE
    {
        BGM_1,
        BGM_2,
        BGM_3
    }
    //EFT 종류
    public enum EFT_TYPE
    {
        EFT_1,
        EFT_2,
        EFT_3
    }

    // BGM 플레이하는 AudioSource
    public AudioSource bgmAudio;
    // EFT 플레이하는 AudioSource
    public AudioSource eftAudio;

    // bgm 파일
    public AudioClip[] bgms;
    // eft 파일
    public AudioClip[] efts;
    
    private void Awake()
    {
        instance = this;
    }
    
    public void PlayBGM(BGM_TYPE type)
    {
        bgmAudio.clip = bgms[(int)type];
        bgmAudio.Play();
    }

    public void PlayEFT(EFT_TYPE type)
    {
        //eftAudio.clip = efts[(int)type];
        eftAudio.PlayOneShot(efts[(int)type]);
    }
}
