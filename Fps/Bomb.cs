using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // ���߰���
    public GameObject exploFactory;

    private void OnCollisionEnter(Collision collision)
    {
        // ����ȿ�� ���忡�� ����ȿ�� ����
        GameObject explo = Instantiate(exploFactory);
        // ������ ����ȿ���� �ڱ��ڽ���ġ�� ��ġ��Ų��.
        explo.transform.position = transform.position;
        Destroy(gameObject);
    }
}
