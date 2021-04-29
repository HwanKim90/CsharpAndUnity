using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjRotate : MonoBehaviour
{
    // �ڽ��� ������
    float rotX;
    float rotY;
    // ȸ���ӷ�
    float rotSpeed = 200;
    // �¿�ȸ�� ����?
    public bool useRotH = false;
    // ����ȸ�� ����
    public bool useRotV = false;
    // PhotonView
    public PhotonView pv;


    void Start()
    {
        
    }

    
    void Update()
    {
        // ������ �ƴϸ� �Լ��� ������!!!
        if (pv.IsMine == false) return;

        // ���콺 �¿���� ������
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        // ������Ʈ�� ������ ����
        if (useRotV) rotX += my * rotSpeed * Time.deltaTime;
        if (useRotH) rotY += mx * rotSpeed * Time.deltaTime;

        // ������ ����
        transform.localEulerAngles = new Vector3(-rotX, rotY, 0);
    }
}
