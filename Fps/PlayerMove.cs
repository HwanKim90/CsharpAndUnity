using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    //Character Controller
    CharacterController cc;
    public GameObject hitUI;

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

    // 현재 HP
    float hp = 100f;

    void Start()
    {
        cc = GetComponent<CharacterController>();    
    }

    void Update()
    {
        // 만약에 GameState가 Play가 아닐때
        if (GameManager.instance.state != GameManager.GameState.Play)
        {
            return; // 여기서 함수 끝나고 if문 밑에 코드 실행안함
        }
        

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
    
    public void DamagedAction(float damage)
    {
        // damage 만큼 hp를 줄인다.
        hp -= damage;
        print("현재 HP : " + hp);

        // 2.맞았을때 코루틴 함수를 실행
        StartCoroutine(HitEffect());

        // hp가 0보다 작거나 같으면
        if (hp <= 0 )
        {
            // 게임상태를 GameOver로
            GameManager.instance.GameOver();
        }
    }
    
    // 1.Hit UI를 깜빡하는 코루틴 함수를 만든다.
    IEnumerator HitEffect()
    {
        // 1.1 Hit UI를 활성화
        hitUI.SetActive(true);
        // 1.2 0.2초 기다렸다가
        yield return new WaitForSeconds(0.2f);
        // 1.3 Hit UI를 비활성화
        hitUI.SetActive(false);
    }
       

}
        


    

        
                
        



    

        

        
