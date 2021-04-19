using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed = 100f;

    public Transform target;
    public Transform target2;

    bool isCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollider)
        {
            MoveTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isCollider = true;
    }

    void MoveTarget()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            target = target2;

            if (Mathf.Approximately(transform.position.x, target2.position.x))
            {
                isCollider = false;
            }
        } 

        
    }
}
