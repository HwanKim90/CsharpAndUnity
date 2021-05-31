using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneManager : MonoBehaviour
{
    //�����ð�
    public float createTime = 2;
    //����ð�
    float currTime;
    //��а���
    public GameObject droneFactory;
    void Start()
    {
        StartCoroutine(CreateDroneProc());
    }

    void Update()
    {
        ////0. ����ð��� ����
        //currTime += Time.deltaTime;
        ////1. �����ð��� ������
        //if (currTime > createTime)
        //{
        //    //2. ��а��忡�� ����� �����
        //    GameObject drone = Instantiate(droneFactory);
        //    //3. ����� ��иŴ�����ġ�� ���´�
        //    drone.transform.position = transform.position;
        //    //4. ���� �ð� �ʱ�ȭ
        //    currTime = 0;
        //}
    }

    IEnumerator CreateDroneProc()
    {
        while(true)
        {
            yield return new WaitForSeconds(createTime);

            //2. ��а��忡�� ����� �����
            GameObject drone = Instantiate(droneFactory);
            //3. ����� ��иŴ�����ġ�� ���´�
            drone.transform.position = transform.position;
        }
    }
}
