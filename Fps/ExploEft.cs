using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploEft : MonoBehaviour
{
    
    void Start()
    {
        // 파티클 플레이
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        // 사운드 플레이
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        // 3초 있다가 파괴하자
        //Destroy(gameObject, 3);
        //Invoke("DestroyObject", 3);
        StartCoroutine(DestroyObject());
    }

    
    //void DestroyObject()
    //{
    //    Destroy(gameObject);
    //}

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
