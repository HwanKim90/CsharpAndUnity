using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    // �Ѿ� �� ���
    public GameObject target;
    // �ӷ�
    public float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1.Ÿ���� ���ϴ� ������ ���ϰ�
        // Target - Tail => Target <- tail
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        // 2.�� �������� �̵��ϰ� �ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }
}
