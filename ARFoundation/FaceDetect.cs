using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Collections;
using UnityEngine.UI;

public class FaceDetect : MonoBehaviour
{
    public Text faceID;

    // ar face manager
    ARFaceManager faceManager;

    // �� ��ġ�� �ø� ������Ʈ
    public GameObject[] objs;

    ARCoreFaceSubsystem subSys;

    NativeArray<ARCoreFaceRegionData> regionData;

    int index;
    
    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();

        subSys = (ARCoreFaceSubsystem)faceManager.subsystem;

        // �� ������ ���Ҷ� ȣ�����ִ� �Լ� ���
        faceManager.facesChanged += OnDetectThreePoint;
        faceManager.facesChanged += OnDetectFaceAll;
    }

    void OnDetectFaceAll(ARFacesChangedEventArgs events)
    {
        // �������� Detect�Ǿ��ٸ�
        if (events.updated.Count > 0)
        {
            // 468���� ����Ʈ
            Vector3 pos = events.updated[0].vertices[index];
            // ������ǥ�� ������ǥ�� ��ȯ
            pos = events.updated[0].transform.TransformPoint(pos);
            // obj�� Ȱ��ȭ, ��ġ��Ų��.
            objs[3].SetActive(true);
            objs[3].transform.position = pos;
        }

        if (events.removed.Count > 0)
        {
            objs[3].SetActive(false);
        }
    }

    void OnDetectThreePoint(ARFacesChangedEventArgs events)
    {
        // �������� Detect�Ǿ��ٸ�
        if (events.updated.Count > 0)
        {
            // �� ����(��, �����̸�, �������̸�) ������ ��������
            subSys.GetRegionPoses(
                events.updated[0].trackableId,
                Allocator.Persistent,
                ref regionData
                );
            // �ش���ġ�� objs�� �ִ� �ֵ��� Ȱ��ȭ, ��ġ��Ű��.
            // 0 : �� 1 : �����̸� 2 : �������̸�
            for (int i = 0; i < regionData.Length; i++)
            {
                objs[i].SetActive(true);
                objs[i].transform.position = regionData[i].pose.position;
                objs[i].transform.rotation = regionData[i].pose.rotation;
            }
            // �������� �������ٸ�
            if (events.removed.Count > 0)
            {
                // objs ���� ��Ȱ��ȭ
                for (int i = 0; i < objs.Length; i++)
                {
                    objs[i].SetActive(false);
                }
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            index++;
            faceID.text = index.ToString();
        }
    }
    
}
