using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    //ȸ����
    Vector2 rot;

    //ȸ���ӷ�
    public float rotSpeed = 200;

    void Start()
    {
        
    }

    void Update()
    {
        //1. ���콺 �Է� �޾ƿ���
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        //2. ȸ������ ����
        rot.x += mx * rotSpeed * Time.deltaTime;
        rot.y += my * rotSpeed * Time.deltaTime;

        //3. ������ ȸ������ �����Ű��
        transform.localEulerAngles = new Vector3(-rot.y, rot.x, 0);
    }
}
