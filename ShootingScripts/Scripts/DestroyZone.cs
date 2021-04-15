using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // 충돌했을 때 부딪힌놈 다 파괴
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 놈의 이름이 Bullet을 포함하고 있으면
        if (other.gameObject.name.Contains("Bullet"))
        {
            // Player게임오브젝트 찾자
            GameObject player = GameObject.Find("Player");

            // PlayerFire 컴포넌트 가져오고
            PlayerFire pf = player.GetComponent<PlayerFire>();

            // PlayerFire 컴포넌트의 AddMagazine 을 실행
            pf.AddMagazine(other.gameObject);
        }
        else
        {
            // 부딪힌 놈 파괴
            Destroy(other.gameObject);
        }
    }
}



        
