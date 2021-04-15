using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // �浹���� �� �ε����� �� �ı�
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ���� �̸��� Bullet�� �����ϰ� ������
        if (other.gameObject.name.Contains("Bullet"))
        {
            // Player���ӿ�����Ʈ ã��
            GameObject player = GameObject.Find("Player");

            // PlayerFire ������Ʈ ��������
            PlayerFire pf = player.GetComponent<PlayerFire>();

            // PlayerFire ������Ʈ�� AddMagazine �� ����
            pf.AddMagazine(other.gameObject);
        }
        else
        {
            // �ε��� �� �ı�
            Destroy(other.gameObject);
        }
    }
}



        
