using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletEftFactory;
    public GameObject exploFactory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {   
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ShowBulletEft(hit);
                CheckCollisionDrone(hit);
            }
        }
    }

    void ShowBulletEft(RaycastHit hit)
    {
        GameObject bulletEft = Instantiate(bulletEftFactory);
        bulletEft.transform.position = hit.point;
        bulletEft.transform.forward = hit.normal;

        PlayEft(bulletEft);
        bulletEft.GetComponent<AudioSource>().Play();

        Destroy(bulletEft, 3f);
    }

    void CheckCollisionDrone(RaycastHit hit)
    {
        // 맞은놈이 드론이면
        if (hit.transform.name.Contains("Drone"))
        {
            // 폭발공장에서 폭발효과를 만든다.
            GameObject explo = Instantiate(exploFactory);
            // 맞은 위치에 놓는다.
            explo.transform.position = hit.point;
            // 효과를 Play 시킨다.
            PlayEft(explo);
            // 파괴하자
            Destroy(explo, 3f);
            Destroy(hit.transform.gameObject);
        }
    }

    void PlayEft(GameObject go)
    {
        go.GetComponent<ParticleSystem>().Play();
    }
}
