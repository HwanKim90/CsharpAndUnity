using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneManager : MonoBehaviour
{
    public float createTime = 2f;
    //public float currTime;
    public GameObject droneFactory;
    
    void Start()
    {
        StartCoroutine(CreateDroneProc());
    }
   
    void Update()
    {
        //currTime += Time.deltaTime;
        
        //if (currTime > createTime)
        //{   
        //    GameObject drone = Instantiate(droneFactory);
        //    drone.transform.position = transform.position;
        //    currTime = 0;
        //}
    }

    IEnumerator CreateDroneProc()
    {
        while(true)
        {
            yield return new WaitForSeconds(createTime);

            GameObject drone = Instantiate(droneFactory);
            drone.transform.position = transform.position;
        }
    }
}
