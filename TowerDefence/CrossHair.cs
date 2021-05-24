using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        // 1.Ray�� �����(ī�޶���ġ, ī�޶�չ���)
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        // 2.�ε��� ������ crosshair�� ��ġ��Ų��.
        if (Physics.Raycast(ray, out hit)) 
        {
            // ��ġ��Ų��.
            transform.position = hit.point;
            // ũ������
            float dist = Vector3.Distance(Camera.main.transform.position, hit.point);
            transform.localScale = Vector3.one * dist;
        }

    }
}
