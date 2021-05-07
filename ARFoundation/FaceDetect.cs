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

    // 얼굴 위치에 올릴 오브젝트
    public GameObject[] objs;

    ARCoreFaceSubsystem subSys;

    NativeArray<ARCoreFaceRegionData> regionData;

    int index;
    
    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();

        subSys = (ARCoreFaceSubsystem)faceManager.subsystem;

        // 얼굴 정보가 변할때 호출해주는 함수 등록
        faceManager.facesChanged += OnDetectThreePoint;
        faceManager.facesChanged += OnDetectFaceAll;
    }

    void OnDetectFaceAll(ARFacesChangedEventArgs events)
    {
        // 얼굴정보가 Detect되었다면
        if (events.updated.Count > 0)
        {
            // 468개의 포인트
            Vector3 pos = events.updated[0].vertices[index];
            // 정점좌표를 월드좌표로 변환
            pos = events.updated[0].transform.TransformPoint(pos);
            // obj를 활성화, 위치시킨다.
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
        // 얼굴정보가 Detect되었다면
        if (events.updated.Count > 0)
        {
            // 세 지점(코, 왼쪽이마, 오른쪽이마) 정보를 가져오자
            subSys.GetRegionPoses(
                events.updated[0].trackableId,
                Allocator.Persistent,
                ref regionData
                );
            // 해당위치에 objs에 있는 애들을 활성화, 위치시키자.
            // 0 : 코 1 : 왼쪽이마 2 : 오른쪽이마
            for (int i = 0; i < regionData.Length; i++)
            {
                objs[i].SetActive(true);
                objs[i].transform.position = regionData[i].pose.position;
                objs[i].transform.rotation = regionData[i].pose.rotation;
            }
            // 얼굴정보가 없어졌다면
            if (events.removed.Count > 0)
            {
                // objs 들을 비활성화
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
