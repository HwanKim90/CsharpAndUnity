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

    // ���� HP
    float hp = 100f;

    void Start()
    {
        cc = GetComponent<CharacterController>();    
    }

    void Update()
    {
        // ���࿡ GameState�� Play�� �ƴҶ�
        if (GameManager.instance.state != GameManager.GameState.Play)
        {
            return; // ���⼭ �Լ� ������ if�� �ؿ� �ڵ� �������
        }
        

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
    
    public void DamagedAction(float damage)
    {
        // damage ��ŭ hp�� ���δ�.
        hp -= damage;
        print("���� HP : " + hp);

        // 2.�¾����� �ڷ�ƾ �Լ��� ����
        StartCoroutine(HitEffect());

        // hp�� 0���� �۰ų� ������
        if (hp <= 0 )
        {
            // ���ӻ��¸� GameOver��
            GameManager.instance.GameOver();
        }
    }
    
    // 1.Hit UI�� �����ϴ� �ڷ�ƾ �Լ��� �����.
    IEnumerator HitEffect()
    {
        // 1.1 Hit UI�� Ȱ��ȭ
        hitUI.SetActive(true);
        // 1.2 0.2�� ��ٷȴٰ�
        yield return new WaitForSeconds(0.2f);
        // 1.3 Hit UI�� ��Ȱ��ȭ
        hitUI.SetActive(false);
    }
       

}
        


    

        
                
        



    

        

        
