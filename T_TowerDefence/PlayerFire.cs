using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //총알효과공장
    public GameObject bulletEftFactory;

    //폭발공장
    public GameObject exploFactory;

    void Start()
    {
        
    }

    void Update()
    {
        // 1번키를 누르면
        if(Input.GetKeyDown(KeyCode.Alpha1) || 
            OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //1. 카메라 위치, 카메라 앞방향으로 나가는 Ray를 만든다.
            Ray ray = new Ray(
                Camera.main.transform.position,
                Camera.main.transform.forward);
            //2. 만든 Ray를 발사해서 어딘가에 부딪혔다면
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                ShowBulletEft(hit);

                CheckCollisionDrone(hit);
            }
        }
    }

    void ShowBulletEft(RaycastHit hit)
    {
        //3. 총알효과공장에서 총알효과를 생성
        GameObject bulletEft = Instantiate(bulletEftFactory);
        //4. 생성된 효과를 부딪힌 지점에 위치
        bulletEft.transform.position = hit.point;
        bulletEft.transform.forward = hit.normal;
        //5. 총알효과 보여주고
        PlayEft(bulletEft);
        //6. 효과음도 출력
        AudioSource audio = bulletEft.GetComponent<AudioSource>();
        audio.Play();
        //7. 3초뒤에 파괴
        Destroy(bulletEft, 3);
    }

    void CheckCollisionDrone(RaycastHit hit)
    {
        //8. 맞은 놈이 Drone이면 
        if (hit.transform.name.Contains("Drone"))
        {
            //8-1. 폭발공장에서 폭발효과를 만든다
            GameObject explo = Instantiate(exploFactory);
            //8-2. 맞은 위치에 놓는다.
            explo.transform.position = hit.point;
            //8-3. 효과를 Play 시킨다
            PlayEft(explo);
            //8-4. 효과를 3초뒤에 파괴하자
            Destroy(explo, 3);
            //파괴하자
            Destroy(hit.transform.gameObject);
        }
    }

    void PlayEft(GameObject go)
    {
        ParticleSystem ps = go.GetComponent<ParticleSystem>();
        ps.Play();
    }
}
