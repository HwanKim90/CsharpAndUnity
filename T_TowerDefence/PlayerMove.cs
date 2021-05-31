using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{
    PhotonView photonView;
    // 속력
    public float speed = 5;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (photonView.IsMine == false) return;

        //왼쪽 조이스틱 값 받아오기
        Vector2 joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        //방향 정하자
        Vector3 dir = 
            Camera.main.transform.forward * joystick.y +
            Camera.main.transform.transform.right * joystick.x;
        dir.Normalize();

        //그방향으로 이동하자
        transform.position += dir * speed * Time.deltaTime;
    }
}
