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
        // 아래로 계속 움직이고 싶다.
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        // 이동공식 p = p0 + vt
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}

        
