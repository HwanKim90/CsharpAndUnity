using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public int speed = 50;
    
    void Start()
    {
        
    }
    void Update()
    {
        // 1.사용자의 입력을 받아서
        // a키 : -1, d키 : 1, 누르지않으면 0 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2.이동방향을 결정하고 싶다.
        Vector3 dirH = Vector3.right * h; 
        Vector3 dirV = Vector3.up * v;
        //(1, 0, 0) * h(-1(a키)) => (-1, 0, 0)
        //(1, 0, 0) * 0 => (0, 0, 0)

        Vector3 dir = dirH + dirV;

        //노말라이즈 정규화
        dir.Normalize();
        //dir.normalized 이미 정규화된 변수인 상태
        // -> transform.Translate(dir.normalized * speed * Time.deltaTime); 이렇게 쓰면됨

        // 3.그 방향으로 계속 움직이고 싶다.
        // 오른쪽으로 계속 움직이고 싶다.
        // 좋은컴이나 나쁜컴이나 같은 속도로 만들어주기 위해 델타타임을곱한다.
        // update 1번의 걸리는 시간 = deltatime

        //transform.Translate(dir * speed * Time.deltaTime);

        //이동 공식
        // p = p0 + vt
        //transform.position = transform.position + (dir * speed) * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;

        //transform.position += Vector3.right * speed * Time.deltaTime;   space.world 유니티세상에서 오른쪽으로 움직임
        //transform.position += transform.right * speed * Time.deltaTime; space.self 오브젝트 중심으로 오른쪽으로 움직임
    }

    //void Translate(Vector3 dir)
    //{
        
    //}
}
        
        
        


    
    
