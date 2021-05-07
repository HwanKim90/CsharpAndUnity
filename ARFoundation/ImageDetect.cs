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
    // �̹����̸�, �ش� �̹����� ��Ÿ�� ������Ʈ
    public MarkerInfo[] markerInfos;

    // AR Tracked Image Manager
    ARTrackedImageManager trackedManager;
    
    void Start()
    {
        trackedManager = GetComponent<ARTrackedImageManager>();
        // ������ȭ(�̹��� �νĿ���)�� ������ ȣ��Ǵ� �Լ� ���
        trackedManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnDestroy()
    {
        // ������ȭ(�̹��� �νĿ���)�� ������ ȣ��Ǵ� �Լ� ����
        trackedManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs events)
    {
        // ����� ������ŭ ���Ѵ�
        for (int i = 0; i < events.updated.Count; i++)
        {
            ARTrackedImage trImage = events.updated[i];

            for (int j = 0; j < markerInfos.Length; j++)
            {
                // �νĵ� �̹���(1000won)��  markerInfos[0].imgName�� ���ٸ�
                if (trImage.referenceImage.name == markerInfos[j].imgName)
                {
                    // ���࿡ �νĵ� �̹����� Ʈ��ŷ ���̶��
                    if (trImage.trackingState == TrackingState.Tracking)
                    {
                        // markerInfos[0].targetObj �� Ȱ��ȭ.
                        markerInfos[j].targetObject.SetActive(true);
                        // �̹����� ����ٴϰ�
                        markerInfos[j].targetObject.transform.position = trImage.transform.position;
                        // ĳ���Ϳ� ��������ֱ�
                        markerInfos[j].targetObject.transform.up = trImage.transform.up;
                    }
                    else
                    {
                        // markerInfos[0].targetObj �� ��Ȱ��ȭ.
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
