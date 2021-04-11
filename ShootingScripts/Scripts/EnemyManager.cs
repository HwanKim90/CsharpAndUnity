using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory; //null
    // 일정시간(생성시간)
    float createTime = 2; 
    // 흐르는 시간(현재시간)
    float currTime; // 초기값 0

    void Start()
    {
        
    }
    
    void Update()
    {
        //currTime 흐르게한다. (증가시킨다)
        currTime += Time.deltaTime;
        //1.만약에 일정시간이 지나면
        if (createTime < currTime)
        {
            //2.Enemy공장에서 Enemy를 만든다.
            GameObject enemy = Instantiate(enemyFactory);
            //3.만들어진 Enemy를 EnemyManager 위치에 놓는다.
            enemy.transform.position = transform.position;
            //4. currTime 초기화
            currTime = 0;
            //5. createTime을 랜덤하게 설정하자
            createTime = Random.Range(2f, 5f);
        }
    }
}

             

