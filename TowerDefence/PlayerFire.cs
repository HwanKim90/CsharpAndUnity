using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletEftFactory;
    public GameObject exploFactory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
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
        // �������� ����̸�
        if (hit.transform.name.Contains("Drone"))
        {
            // ���߰��忡�� ����ȿ���� �����.
            GameObject explo = Instantiate(exploFactory);
            // ���� ��ġ�� ���´�.
            explo.transform.position = hit.point;
            // ȿ���� Play ��Ų��.
            PlayEft(explo);
            // �ı�����
            Destroy(explo, 3f);
            Destroy(hit.transform.gameObject);
        }
    }

    void PlayEft(GameObject go)
    {
        go.GetComponent<ParticleSystem>().Play();
    }
}
