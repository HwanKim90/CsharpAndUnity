using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    float currTime = 0;
    // Ÿ�� Transform�� ��Ƴ��� �迭
    public Transform[] target;
    public int[] numbers;
    // �̵��� target �ε���
    int targetIndex = 0;
    float moveSpeed = 15;

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            // ������ �� 1
            int rand1 = Random.Range(0, numbers.Length);
            // ������ �� 2
            int rand2 = Random.Range(0, numbers.Length);
            //������ ��1 �ڸ��� �ִ� number�� ��� �ӽð����� �־�д�.
            int temp = numbers[rand1];
            //������ ��2 �ڸ��� �ִ� number�� ������ ��1 �ڸ��� �ִ´�.
            numbers[rand1] = numbers[rand2];
            //�ӽð����� �־�� ���� ������ ��2 �ڸ��� �ִ´�.
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
        // target�� ���ϴ� ������ ���ϰ�
        Vector3 dir = target[targetIndex].position - transform.position;
        
        // �׹������� �̵��ϰ� �ʹ�.
        transform.position += dir.normalized * moveSpeed * Time.deltaTime;

        // ���࿡ dir�� ũ�Ⱑ 0.1���� ������

        
        if (dir.magnitude < 0.1f)
        {
            
            // Ÿ���� �ٲ���.
            targetIndex++;
            targetIndex %= target.Length;
        }
                
            
    }
            
}
          
            
          

    
