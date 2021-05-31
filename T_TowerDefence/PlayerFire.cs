using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //�Ѿ�ȿ������
    public GameObject bulletEftFactory;

    //���߰���
    public GameObject exploFactory;

    void Start()
    {
        
    }

    void Update()
    {
        // 1��Ű�� ������
        if(Input.GetKeyDown(KeyCode.Alpha1) || 
            OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //1. ī�޶� ��ġ, ī�޶� �չ������� ������ Ray�� �����.
            Ray ray = new Ray(
                Camera.main.transform.position,
                Camera.main.transform.forward);
            //2. ���� Ray�� �߻��ؼ� ��򰡿� �ε����ٸ�
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
        //3. �Ѿ�ȿ�����忡�� �Ѿ�ȿ���� ����
        GameObject bulletEft = Instantiate(bulletEftFactory);
        //4. ������ ȿ���� �ε��� ������ ��ġ
        bulletEft.transform.position = hit.point;
        bulletEft.transform.forward = hit.normal;
        //5. �Ѿ�ȿ�� �����ְ�
        PlayEft(bulletEft);
        //6. ȿ������ ���
        AudioSource audio = bulletEft.GetComponent<AudioSource>();
        audio.Play();
        //7. 3�ʵڿ� �ı�
        Destroy(bulletEft, 3);
    }

    void CheckCollisionDrone(RaycastHit hit)
    {
        //8. ���� ���� Drone�̸� 
        if (hit.transform.name.Contains("Drone"))
        {
            //8-1. ���߰��忡�� ����ȿ���� �����
            GameObject explo = Instantiate(exploFactory);
            //8-2. ���� ��ġ�� ���´�.
            explo.transform.position = hit.point;
            //8-3. ȿ���� Play ��Ų��
            PlayEft(explo);
            //8-4. ȿ���� 3�ʵڿ� �ı�����
            Destroy(explo, 3);
            //�ı�����
            Destroy(hit.transform.gameObject);
        }
    }

    void PlayEft(GameObject go)
    {
        ParticleSystem ps = go.GetComponent<ParticleSystem>();
        ps.Play();
    }
}
