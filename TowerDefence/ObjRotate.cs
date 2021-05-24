using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    public float rotateSpeed = 100f;
    Vector2 rot;

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        rot.x += -my * rotateSpeed * Time.deltaTime;
        rot.y += mx * rotateSpeed * Time.deltaTime;

        rot.x = Mathf.Clamp(rot.x, -90, 90);

        transform.localEulerAngles = new Vector3(rot.x, rot.y, 0);
    }
}
