using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �Ʒ��� ��� �����̰� �ʹ�.
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        // �̵����� p = p0 + vt
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}

        
