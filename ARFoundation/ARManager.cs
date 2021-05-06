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
        // 1.ī�޶� ��ġ, ���� �������� Ray ����
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

#if UNITY_EDITOR
        RaycastHit hit;
        int layer = 1 << LayerMask.NameToLayer("Ground");
        if (Physics.Raycast(ray, out hit, 100, layer))
        {
            DetectedGround(hit.point);

            //// 3.Indicator�� Ȱ��ȭ �ϰ� �ε��� ��ġ�� ���´�.
            //indicator.SetActive(true);
            //// ��ġ�� ���� ���ֱ� y�� �ø���
            //indicator.transform.position = hit.point; //new Vector3(hit.point.x, hit.point.y + 0.01f, hit.point.z);
            ////indicator.transform.position = hit.point + Vector3.up * 0.01f;
            //// ī�޶� ���� �������� ȸ��
            //indicator.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);

        }
#else
        // 2.�ٴڰ� �ε����ٸ�
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (rayManager.Raycast(ray, hits, TrackableType.Planes))
        {
            DetectedGround(hits[0].pose.position);
        }
#endif
        
        else
        {
            // �ٴڰ� �ε����� �ʴ´ٸ� Indicator�� ��Ȱ��ȭ
            indicator.SetActive(false);
        }

        // ���࿡ ȭ�� ��ġ�� �ߴٸ�
        if (Input.GetMouseButtonDown(0))
        {
            // ���࿡ indicator�� Ȱ��ȭ �Ǿ��ִٸ�
            if (indicator.activeSelf)
            {
                // �ڵ��� Ȱ��ȭ
                car.SetActive(true);
                // �ڵ��� ��ġ�� indicator ��ġ�� ����
                // �ڵ����� ȸ������ indicator�� ȸ�������� ����
                car.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);
                // UI Ȱ��ȭ
                ui.SetActive(true);
                // indicator ��Ȱ��ȭ
                indicator.SetActive(false);
                // ARManager ��Ȱ��ȭ
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
