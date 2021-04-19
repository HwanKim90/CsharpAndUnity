using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjRotate : MonoBehaviour
{
    // 회전속력
    public float rotSpeed = 200f;
    // 회전값
    float rotX = 0;
    float rotY = 0;

    // 회전 가능 여부
    public bool useVertical = false;
    public bool useHorizontal = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        // 마우스의 움직임값을 받아오자.
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        // 회전 각도 누적
        if (useVertical == true)
        {
            rotX += -my * rotSpeed * Time.deltaTime;
        }

        if (useHorizontal == true)
        {
            rotY += mx * rotSpeed * Time.deltaTime;
        }

        // -90 ~ 90도 제한
        rotX = Mathf.Clamp(rotX, -90, 90);

        // 물체를 회전하고 싶다.
        transform.localEulerAngles = new Vector3(rotX, rotY, 0);
        

        
       

        
    }
}


