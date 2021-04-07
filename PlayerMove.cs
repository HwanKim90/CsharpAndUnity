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
        // 1.������� �Է��� �޾Ƽ�
        // aŰ : -1, dŰ : 1, ������������ 0 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2.�̵������� �����ϰ� �ʹ�.
        Vector3 dirH = Vector3.right * h; 
        Vector3 dirV = Vector3.up * v;
        //(1, 0, 0) * h(-1(aŰ)) => (-1, 0, 0)
        //(1, 0, 0) * 0 => (0, 0, 0)

        Vector3 dir = dirH + dirV;

        //�븻������ ����ȭ
        dir.Normalize();
        //dir.normalized �̹� ����ȭ�� ������ ����
        // -> transform.Translate(dir.normalized * speed * Time.deltaTime); �̷��� �����

        // 3.�� �������� ��� �����̰� �ʹ�.
        // ���������� ��� �����̰� �ʹ�.
        // �������̳� �������̳� ���� �ӵ��� ������ֱ� ���� ��ŸŸ�������Ѵ�.
        // update 1���� �ɸ��� �ð� = deltatime

        //transform.Translate(dir * speed * Time.deltaTime);

        //�̵� ����
        // p = p0 + vt
        //transform.position = transform.position + (dir * speed) * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;

        //transform.position += Vector3.right * speed * Time.deltaTime;   space.world ����Ƽ���󿡼� ���������� ������
        //transform.position += transform.right * speed * Time.deltaTime; space.self ������Ʈ �߽����� ���������� ������
    }

    //void Translate(Vector3 dir)
    //{
        
    //}
}
        
        
        


    
    
