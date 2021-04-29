using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjRotate : MonoBehaviour
{
    // 자신의 각도값
    float rotX;
    float rotY;
    // 회전속력
    float rotSpeed = 200;
    // 좌우회전 가능?
    public bool useRotH = false;
    // 상하회전 가능
    public bool useRotV = false;
    // PhotonView
    public PhotonView pv;


    void Start()
    {
        
    }

    
    void Update()
    {
        // 내것이 아니면 함수를 나가라!!!
        if (pv.IsMine == false) return;

        // 마우스 좌우상하 움직임
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        // 오브젝트의 각도를 누적
        if (useRotV) rotX += my * rotSpeed * Time.deltaTime;
        if (useRotH) rotY += mx * rotSpeed * Time.deltaTime;

        // 각도를 세팅
        transform.localEulerAngles = new Vector3(-rotX, rotY, 0);
    }
}
