using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  ���� ��ư�� ������ ������ �̵�
 *  ���� ��ư�� ������ �ڷ� �̵�
 */

public class CarControl : MonoBehaviour
{
    // �ӷ�
    public float moveSpeed = 5;
    // ������ ������ ���� (1 : ����, 0 : ����, -1 : ����)
    int dir = 0;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        // dir �������� ��������
        transform.position += transform.forward * dir * moveSpeed * Time.deltaTime;
    }

    // ������ư ������ ȣ��
    public void OnClickForward()
    {
        dir = 1;
    }

    // ������ư ������ ȣ��
    public void OnClickBack()
    {
        dir = -1;
    }

    // �����ư ������ ȣ��
    public void OnClickStop()
    {
        dir = 0;
    }

    // ���ʹ�ư ������ ȣ��
    public void OnClickLeft()
    {
        transform.Rotate(new Vector3(0, -10, 0));
    }

    // �����ʹ�ư ������ ȣ��
    public void OnClickRight()
    {
        transform.Rotate(new Vector3(0, 10, 0));
    }
}
