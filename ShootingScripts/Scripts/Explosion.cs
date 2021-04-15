using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // 일정시간
    float destroyTime = 1;
    // 흐르는시간
    float currTime = 0;

    private void Start()
    {
        // 파티클 실행
        //ParticleSystem ps = GetComponent<ParticleSystem>();
        //ps.Play();

        //// 오디오 실행
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();
    }

    // 파괴만 할거면 간단한 방법
    //private void Start()
    //{
    //    Destroy(gameObject, 1);
    //}

    void Update()
    {
        // 시간을 흐르게 하자
        currTime += Time.deltaTime;
        // 흐르는 시간이 일정시간보다 커지면
        if (destroyTime < currTime)
        {
            // 나를 파괴하자
            Destroy(gameObject);
        }
    }
}
