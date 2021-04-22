using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    // 마우스 클릭 지점
    Vector3 mouseClickPoint;
    // 이동방향
    Vector3 dir;
    // 이동할 거리
    float dist;
    // 네비메쉬
    NavMeshAgent navi;

    void Start()
    {
        navi = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        // 마우스 왼쪽 클릭을 했다면
        if (Input.GetMouseButtonDown(0))
        {
            // 클릭한 지점에서 Ray 만든다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ray를 쏴서 부딪혔다면 hit 정보를 담는다. 
            if (Physics.Raycast(ray, out hit))
            {
                navi.SetDestination(hit.point);

                //print(hit.transform.gameObject.name);
                //// 그 Ray가 부딪힌 위치로 이동하고 싶다.
                //mouseClickPoint = hit.point;
                //// 0.부딪힌 지점 저장
                //// 1.부딪힌 지점을 향하는 방향을 구한다.
                //dir = hit.point - transform.position;
                //// 2.부딪힌 지점과 나와의 거리를 구한다.
                //dist = dir.magnitude;
                //// 3.정규화
                //dir.Normalize();
            }
        }

        //if (dist > 0)
        //{
        //    // 3.그방향으로 움직인다. 
        //    transform.position += dir * 5 * Time.deltaTime;

        //    // 5 * time.deltaTime => 이동거리
        //    dist -= 5 * Time.deltaTime;

        //    if (dist <= 0)
        //    {
        //        transform.position = mouseClickPoint;
        //    }
        //}
        
        

    }
}

