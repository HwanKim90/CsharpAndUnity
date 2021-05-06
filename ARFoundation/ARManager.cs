using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARManager : MonoBehaviour
{
    public GameObject ground;
    public GameObject testCam;
    public GameObject arSession;
    public GameObject arSessionOrigin;

    public GameObject indicator;
    public GameObject car;
    public GameObject ui;
    // AR raycast Manager
    ARRaycastManager rayManager;

    private void Awake()
    {
#if UNITY_EDITOR
        arSession.SetActive(false);
        arSessionOrigin.SetActive(false);
        testCam.SetActive(true);
        ground.SetActive(true);
#else
        arSession.SetActive(true);
        arSessionOrigin.SetActive(true);
        testCam.SetActive(false);
        ground.SetActive(false);
#endif
    }

    void Start()
    {
        rayManager = GetComponent<ARRaycastManager>();
    }

    
    void Update()
    {
        // 1.카메라가 위치, 보는 방향으로 Ray 만들어서
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

#if UNITY_EDITOR
        RaycastHit hit;
        int layer = 1 << LayerMask.NameToLayer("Ground");
        if (Physics.Raycast(ray, out hit, 100, layer))
        {
            DetectedGround(hit.point);

            //// 3.Indicator를 활성화 하고 부딪힌 위치에 놓는다.
            //indicator.SetActive(true);
            //// 겹치는 현상 없애기 y값 올리기
            //indicator.transform.position = hit.point; //new Vector3(hit.point.x, hit.point.y + 0.01f, hit.point.z);
            ////indicator.transform.position = hit.point + Vector3.up * 0.01f;
            //// 카메라가 보는 방향으로 회전
            //indicator.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);

        }
#else
        // 2.바닥과 부딪혔다면
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (rayManager.Raycast(ray, hits, TrackableType.Planes))
        {
            DetectedGround(hits[0].pose.position);
        }
#endif
        
        else
        {
            // 바닥과 부딪히지 않는다면 Indicator를 비활성화
            indicator.SetActive(false);
        }

        // 만약에 화면 터치를 했다면
        if (Input.GetMouseButtonDown(0))
        {
            // 만약에 indicator가 활성화 되어있다면
            if (indicator.activeSelf)
            {
                // 자동차 활성화
                car.SetActive(true);
                // 자동차 위치를 indicator 위치로 셋팅
                // 자동차의 회전값을 indicator의 회전값으로 셋팅
                car.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);
                // UI 활성화
                ui.SetActive(true);
                // indicator 비활성화
                indicator.SetActive(false);
                // ARManager 비활성화
                enabled = false;
            }

        }
    }

    void DetectedGround(Vector3 hitPos)
    {
        indicator.SetActive(true);
        indicator.transform.position = hitPos;

        indicator.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
    }
}
