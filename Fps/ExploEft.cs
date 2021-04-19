using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploEft : MonoBehaviour
{
    
    void Start()
    {
        // ��ƼŬ �÷���
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        // ���� �÷���
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        // 3�� �ִٰ� �ı�����
        //Destroy(gameObject, 3);
        Invoke("DestroyObject", 3);
    }

    
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
