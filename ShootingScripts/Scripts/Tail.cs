using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    // 쫓아 갈 대상
    public GameObject target;
    // 속력
    public float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1.타겟을 향하는 방향을 구하고
        // Target - Tail => Target <- tail
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        // 2.그 방향으로 이동하고 싶다.
        transform.position += dir * speed * Time.deltaTime;
    }
}
