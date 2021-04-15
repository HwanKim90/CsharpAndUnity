using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // �����ð�
    float destroyTime = 1;
    // �帣�½ð�
    float currTime = 0;

    private void Start()
    {
        // ��ƼŬ ����
        //ParticleSystem ps = GetComponent<ParticleSystem>();
        //ps.Play();

        //// ����� ����
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();
    }

    // �ı��� �ҰŸ� ������ ���
    //private void Start()
    //{
    //    Destroy(gameObject, 1);
    //}

    void Update()
    {
        // �ð��� �帣�� ����
        currTime += Time.deltaTime;
        // �帣�� �ð��� �����ð����� Ŀ����
        if (destroyTime < currTime)
        {
            // ���� �ı�����
            Destroy(gameObject);
        }
    }
}
