using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bombFactory;
    public Transform firePos;
    
    // 던지는 파워
    public float throwPower = 15f;

    // 총알효과
    public GameObject bulletEft;

    // 총알 파워
    public float bulletPower = 20f;

    void Update()
    {
        //// 만약에 GameState가 Play가 아닐때
        //if (GameManager.instance.state != GameManager.GameState.Play)
        //{
        //    return; // 여기서 함수 끝나고 if문 밑에 코드 실행안함
        //}
        if (!GameManager.instance.isPlaying()) return;
        

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePos.position;
            
            // 4.폭탄에 있는 rigidbody 가져오자.
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            // 5.카메라가 바라보는 방향으로 물리적인 힘을 가한다.
            rb.AddForce(Camera.main.transform.forward * throwPower);


        }

        // Fire1버튼 (마우스왼쪽) 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            // 카메라의 앞방향으로 발사되는 Ray를 만든다.
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // 일직선상 부딪힌놈 다 가지고온다. 배열로 변수를 받는다.
            RaycastHit[] hits =  Physics.RaycastAll(ray);
            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    print(hits[i].transform.gameObject.name);
                }
            }

            // 부딪히 놈의 정보를 담을 변수
            RaycastHit hit = new RaycastHit();

            int layerEnemy = 1 << LayerMask.NameToLayer("Enemy");
            int layerBomb = 1 << LayerMask.NameToLayer("Bomb");
            int layer = layerEnemy | layerBomb; // 이두개만 충돌하게 만들겠다.

            // 그 Ray가 어딘가에 부딪히면 정보를 담아서
            if (Physics.Raycast(ray, out hit, 100, ~layer)) //layer앞의 ~붙이면 두개 빼고 다 충돌
            {
                // 그 정보에 의해 효과를 보여주자        
                //print(hit.transform.gameObject.name);
                // 1.부딪힌 위치에 효과를 위치시키고
                bulletEft.transform.position = hit.point;
                // 2.부딪힌 위치의 normal(수직인벡터)로 방향을 잡고
                bulletEft.transform.forward = hit.normal;
                // 3.파티클 실행
                ParticleSystem ps = bulletEft.GetComponent<ParticleSystem>();
                ps.Play();
                
                // 만약에 맞은놈의 Layer가 Enemy라면
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    // Enemy 컴포넌트 가져오고
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    // HitEnemy 함수를 실행
                    enemy.HitEnemy(bulletPower);

                }
            }
            // 4.사운드 실행
            AudioSource audio = bulletEft.GetComponent<AudioSource>();
            audio.Play();
            
        }
    }
}
