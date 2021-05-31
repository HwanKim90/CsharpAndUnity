using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{
    PhotonView photonView;
    // �ӷ�
    public float speed = 5;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (photonView.IsMine == false) return;

        //���� ���̽�ƽ �� �޾ƿ���
        Vector2 joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        //���� ������
        Vector3 dir = 
            Camera.main.transform.forward * joystick.y +
            Camera.main.transform.transform.right * joystick.x;
        dir.Normalize();

        //�׹������� �̵�����
        transform.position += dir * speed * Time.deltaTime;
    }
}
