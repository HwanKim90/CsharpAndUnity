using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    //회전값
    Vector2 rot;

    //회전속력
    public float rotSpeed = 200;

    void Start()
    {
        
    }

    void Update()
    {
        //1. 마우스 입력 받아오자
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        //2. 회전값을 누적
        rot.x += mx * rotSpeed * Time.deltaTime;
        rot.y += my * rotSpeed * Time.deltaTime;

        //3. 누적된 회전값을 적용시키자
        transform.localEulerAngles = new Vector3(-rot.y, rot.x, 0);
    }
}
