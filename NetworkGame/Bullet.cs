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
        // 방장이라면..
        if (PhotonNetwork.IsMasterClient)
        {
            // 부딪힌 놈이 Player면 
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                // PlyaerMove 컴포넌트 얻어오자. OnDamaged함수 호출
                other.transform.parent.GetComponent<PlayerMove>().OnDamaged(10);
            
                // 나 자신을 파괴하자
                Destroy(gameObject);
            }
        }
    }
}

