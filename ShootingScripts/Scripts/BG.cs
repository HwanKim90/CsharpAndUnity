using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BG : MonoBehaviour
{
    // 속력
    public float speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        // 일정한 속도로 배경을 스크롤 하고 싶다.
        // 1.MeshRenderer 컴포넌트를 가져오자.
        MeshRenderer mr = GetComponent<MeshRenderer>();
        // 2.Material 가져오자
        Material mat = mr.material;
        // 3.offset y 값을 변경해서 스크롤 되게 하자.
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
