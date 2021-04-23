using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{

    // 타겟 Transform을 담아놓을 배열
    public Transform[] target;
    public int[] numbers;
    // 이동할 target 인덱스
    int targetIndex = 0;
    float moveSpeed = 15;

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            // 랜덤한 값 1
            int rand1 = Random.Range(0, numbers.Length);
            // 랜덤한 값 2
            int rand2 = Random.Range(0, numbers.Length);
            //랜덤한 값1 자리에 있는 number를 잠시 임시공간에 넣어둔다.
            int temp = numbers[rand1];
            //랜덤한 값2 자리에 있는 number를 랜덤한 값1 자리에 넣는다.
            numbers[rand1] = numbers[rand2];
            //임시공간에 넣어둔 값을 랜덤한 값2 자리에 넣는다.
            numbers[rand2] = temp;
        }

        for (int i = 0; i < 100; i++)
        {
            int rand1 = Random.Range(0, target.Length);
            int rand2 = Random.Range(0, target.Length);
            
            Transform temp = target[rand1];
            target[rand1] = target[rand2];
            target[rand2] = temp;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // target을 향하는 방향을 구하고
        Vector3 dir = target[targetIndex].position - transform.position;
        
        // 그방향으로 이동하고 싶다.
        transform.position += dir.normalized * moveSpeed * Time.deltaTime;

        // 만약에 dir의 크기가 0.1보다 작으면

        
        if (dir.magnitude < 0.1f)
        {
            
            // 타겟을 바꾸자.
            targetIndex++;
            targetIndex %= target.Length;
        }
                
            
    }
            
}
          
            
          

    
