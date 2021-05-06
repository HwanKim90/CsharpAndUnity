using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  직진 버튼을 누르면 앞으로 이동
 *  후진 버튼을 누르면 뒤로 이동
 */

public class CarControl : MonoBehaviour
{
    // 속력
    public float moveSpeed = 5;
    // 방향을 가지는 변수 (1 : 직진, 0 : 멈춰, -1 : 후진)
    int dir = 0;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        // dir 방향으로 움직여라
        transform.position += transform.forward * dir * moveSpeed * Time.deltaTime;
    }

    // 직진버튼 누를때 호출
    public void OnClickForward()
    {
        dir = 1;
    }

    // 후진버튼 누를때 호출
    public void OnClickBack()
    {
        dir = -1;
    }

    // 스톱버튼 누를때 호출
    public void OnClickStop()
    {
        dir = 0;
    }

    // 왼쪽버튼 누를때 호출
    public void OnClickLeft()
    {
        transform.Rotate(new Vector3(0, -10, 0));
    }

    // 오른쪽버튼 누를때 호출
    public void OnClickRight()
    {
        transform.Rotate(new Vector3(0, 10, 0));
    }
}
