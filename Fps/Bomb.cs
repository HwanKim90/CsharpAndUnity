using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // 폭발공장
    public GameObject exploFactory;

    private void OnCollisionEnter(Collision collision)
    {
        // 폭발효과 공장에서 폭발효과 생성
        GameObject explo = Instantiate(exploFactory);
        // 생성된 폭발효과를 자기자신위치에 위치시킨다.
        explo.transform.position = transform.position;
        Destroy(gameObject);
    }
}
