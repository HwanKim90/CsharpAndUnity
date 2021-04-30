using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // �����̶��..
        if (PhotonNetwork.IsMasterClient)
        {
            // �ε��� ���� Player�� 
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                // PlyaerMove ������Ʈ ������. OnDamaged�Լ� ȣ��
                other.transform.parent.GetComponent<PlayerMove>().OnDamaged(10);
            
                // �� �ڽ��� �ı�����
                Destroy(gameObject);
            }
        }
    }
}

