using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject lineFactory;

    LineRenderer currLine;

    int index;

    void Start()
    {
        
    }

    
    void Update()
    {
        // 만약에 마우스 클릭한다면
        if (Input.GetMouseButtonDown(0))
        {
            // 라인공정에서 라인을 만든다.
            GameObject line = Instantiate(lineFactory);
            currLine = line.GetComponent<LineRenderer>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            currLine = null;
            index = 0;
        }
        
        if (currLine != null)
        {
            // 카메라 위치값을 라인에 계속 추가
            Vector3 pos = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;

            currLine.positionCount = index + 1;

            currLine.SetPosition(index, pos);

            index++;
        }
    }

    public void OnButtonUp()
    {
        print("버튼 업!!!");
    }

    public void OnButtonDown()
    {
        print("버튼 다운!!");
    }
}
