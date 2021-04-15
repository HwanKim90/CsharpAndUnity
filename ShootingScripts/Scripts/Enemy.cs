using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    GameObject target;
    public float speed = 5;
    Vector3 dir;
    // 폭발공장
    public GameObject exploFactory;

    void Start()
    {
        

        int rand = Random.Range(1, 11);

        //Random.Range()
        if (rand < 4)
        {

            // 만약1,2,3은 방향을 아래로!
            dir = Vector3.down;

        }
        else 
        {
            // Plyer GameObject 찾아서 target에 넣기
            target = GameObject.Find("Player");

            if (target != null)
            {
                // 만약4,5,6,7,8,9,10은 방향은 Player로 
                dir = target.transform.position - transform.position;
                dir.Normalize();
            }
            
        }


        // 5초 있다가 파괴하라
        //Destroy(gameObject, 5);
    }


    // Update is called once per frame
    void Update()
    {
        // 아래로 계속 움직이고 싶다.
        //transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 타겟을 향하는 방향 구하기
        //dir = target.transform.position - transform.position;
        //dir.Normalize();

        // 그방향으로 계속 움직이고 싶다.
        // 이동공식 p = p0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 1.ScoreManager 게임오브젝트 찾고
        GameObject smObj = GameObject.Find("ScoreManager");
        
        // 2.찾은 ScoreManager 게임오브젝트 -> ScoreManager스크립트
        ScoreManager sm = smObj.GetComponent<ScoreManager>();

        // 3.sm이 가지고 있는 AddScore함수 실행
        sm.AddScore(10);


        // 1.충돌공장에서 충돌효과를 생성
        GameObject explo = Instantiate(exploFactory);
        
        // 2.만들어진 효과를 위치시킨다.
        explo.transform.position = transform.position;

        //print("Collision : " + collision.gameObject.name);
        // 충돌한 게임오브젝트 없애고
        Destroy(collision.gameObject);
        
        // 나의 게임오브젝트 없애자
        Destroy(gameObject);
    }

    


}

    

    


