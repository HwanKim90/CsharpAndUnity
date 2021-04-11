using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    GameObject target;
    public float speed = 5;
    Vector3 dir;



    void Start()
    {
        // Plyer GameObject 찾아서 target에 넣기
        target = GameObject.Find("Player");

        int rand = Random.Range(1, 11);

        //Random.Range()
        if (rand < 4)
        {

            // 만약1,2,3은 방향을 아래로!
            dir = Vector3.down;

        }
        else 
        {
            // 만약4,5,6,7,8,9,10은 방향은 Player로 

            dir = target.transform.position - transform.position;
            dir.Normalize();
        }


        // 태어날때 한번만 방향을 구하고
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
        print("Collision : " + collision.gameObject.name);
        // 충돌한 게임오브젝트 없애고
        Destroy(collision.gameObject);
        // 나의 게임오브젝트 없애자
        Destroy(gameObject);
    }

    


}

    

    


