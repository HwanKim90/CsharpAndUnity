using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    //Character Controller
    CharacterController cc;

    // �߷�
    float gravity = -9.8f;
    // �����Ŀ�
    float jumpPower = 5;
    // y�ӷ�
    float yVelocity;

    // ����Ƚ��
    int jumpCnt = 0;

    // �ִ�����Ƚ��
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
        
        // ī�޶� ���� ������ �������� ���� �缳��
        dir = Camera.main.transform.TransformDirection(dir);
        dir.Normalize();

        if (cc.isGrounded == true)
        {
            // ����Ƚ���� �ʱ�ȭ
            jumpCnt = 0;
            // y�ӷ� �ʱ�ȭ
            yVelocity = 0;
        }

        // ����Ƚ���� �ִ� ����Ƚ������ ������
        if (jumpCnt < maxJumpCnt)
        {
            // �����̽��ٸ� ������ �����Ŀ��� y�ӷ¿� �ִ´�.
            if (Input.GetButtonDown("Jump"))
            {
                // �����Ŀ��� y�ӷ¿� �ִ´�.
                yVelocity = jumpPower;
                //����Ƚ���� ����
                jumpCnt++;
            }
        }
            
        // p = v0 + at
        yVelocity += gravity * Time.deltaTime;

        dir.y = yVelocity;
        
        cc.Move(dir * speed * Time.deltaTime);
    }
}
        


    

        
                
        



    

        

        
