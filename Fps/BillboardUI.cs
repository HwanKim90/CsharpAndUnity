using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    
    void Update()
    {
        // ���� �չ����� ī�޶� �ٶ󺸴� �������� ����
        transform.forward = Camera.main.transform.forward;
    }
}
