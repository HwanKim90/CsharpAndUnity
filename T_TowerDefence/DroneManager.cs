using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneManager : MonoBehaviour
{
    //생성시간
    public float createTime = 2;
    //현재시간
    float currTime;
    //드론공장
    public GameObject droneFactory;
    void Start()
    {
        StartCoroutine(CreateDroneProc());
    }

    void Update()
    {
        ////0. 현재시간을 누적
        //currTime += Time.deltaTime;
        ////1. 생성시간이 지나면
        //if (currTime > createTime)
        //{
        //    //2. 드론공장에서 드론을 만든다
        //    GameObject drone = Instantiate(droneFactory);
        //    //3. 드론을 드론매니저위치에 놓는다
        //    drone.transform.position = transform.position;
        //    //4. 현재 시간 초기화
        //    currTime = 0;
        //}
    }

    IEnumerator CreateDroneProc()
    {
        while(true)
        {
            yield return new WaitForSeconds(createTime);

            //2. 드론공장에서 드론을 만든다
            GameObject drone = Instantiate(droneFactory);
            //3. 드론을 드론매니저위치에 놓는다
            drone.transform.position = transform.position;
        }
    }
}
