using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory; //null
    // �����ð�(�����ð�)
    float createTime = 2; 
    // �帣�� �ð�(����ð�)
    float currTime; // �ʱⰪ 0

    void Start()
    {
        
    }
    
    void Update()
    {
        //currTime �帣���Ѵ�. (������Ų��)
        currTime += Time.deltaTime;
        //1.���࿡ �����ð��� ������
        if (createTime < currTime)
        {
            //2.Enemy���忡�� Enemy�� �����.
            GameObject enemy = Instantiate(enemyFactory);
            //3.������� Enemy�� EnemyManager ��ġ�� ���´�.
            enemy.transform.position = transform.position;
            //4. currTime �ʱ�ȭ
            currTime = 0;
            //5. createTime�� �����ϰ� ��������
            createTime = Random.Range(2f, 5f);
        }
    }
}

             

