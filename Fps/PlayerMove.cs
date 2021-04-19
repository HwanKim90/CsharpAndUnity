using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    //Character Controller
    CharacterController cc;

    // 중력
    float gravity = -9.8f;
    // 점프파워
    float jumpPower = 5;
    // y속력
    float yVelocity;

    // 점프횟수
    int jumpCnt = 0;

    // 최대점프횟수
    int maxJumpCnt = 2;

    void Start()
    {
        cc = GetComponent<CharacterController>();    
    }

    void Update()
    {
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        
        // 카메라가 보는 방향을 기준으로 방향 재설정
        dir = Camera.main.transform.TransformDirection(dir);
        dir.Normalize();

        if (cc.isGrounded == true)
        {
            // 점프횟수를 초기화
            jumpCnt = 0;
            // y속력 초기화
            yVelocity = 0;
        }

        // 점프횟수가 최대 점프횟수보다 작으면
        if (jumpCnt < maxJumpCnt)
        {
            // 스페이스바를 누르면 점프파워를 y속력에 넣는다.
            if (Input.GetButtonDown("Jump"))
            {
                // 점프파워를 y속력에 넣는다.
                yVelocity = jumpPower;
                //점프횟수를 증가
                jumpCnt++;
            }
        }
            
        // p = v0 + at
        yVelocity += gravity * Time.deltaTime;

        dir.y = yVelocity;
        
        cc.Move(dir * speed * Time.deltaTime);
    }
}
        


    

        
                
        



    

        

        
