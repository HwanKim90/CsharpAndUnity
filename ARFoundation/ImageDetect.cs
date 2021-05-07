using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[Serializable]
public class MarkerInfo
{
    public string imgName;
    public GameObject targetObject;
}

public class ImageDetect : MonoBehaviour
{
    // 이미지이름, 해당 이미지에 나타날 오브젝트
    public MarkerInfo[] markerInfos;

    // AR Tracked Image Manager
    ARTrackedImageManager trackedManager;
    
    void Start()
    {
        trackedManager = GetComponent<ARTrackedImageManager>();
        // 정보변화(이미지 인식여부)가 있을때 호출되는 함수 등록
        trackedManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnDestroy()
    {
        // 정보변화(이미지 인식여부)가 있을때 호출되는 함수 제거
        trackedManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs events)
    {
        // 변경된 정보만큼 비교한다
        for (int i = 0; i < events.updated.Count; i++)
        {
            ARTrackedImage trImage = events.updated[i];

            for (int j = 0; j < markerInfos.Length; j++)
            {
                // 인식된 이미지(1000won)과  markerInfos[0].imgName이 같다면
                if (trImage.referenceImage.name == markerInfos[j].imgName)
                {
                    // 만약에 인식된 이미지를 트랙킹 중이라면
                    if (trImage.trackingState == TrackingState.Tracking)
                    {
                        // markerInfos[0].targetObj 를 활성화.
                        markerInfos[j].targetObject.SetActive(true);
                        // 이미지를 따라다니게
                        markerInfos[j].targetObject.transform.position = trImage.transform.position;
                        // 캐릭터에 방향잡아주기
                        markerInfos[j].targetObject.transform.up = trImage.transform.up;
                    }
                    else
                    {
                        // markerInfos[0].targetObj 를 비활성화.
                        markerInfos[j].targetObject.SetActive(false);
                    }
                }
            }
        }

    }

    void Update()
    {
        
    }
}
