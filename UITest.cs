using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Transform rightHand;
    public Transform dot;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //int layer = 1 << LayerMask.NameToLayer("UI");
        // 1.Ray 만든다 (오른손 위치, 오른손 앞방향)
        Ray ray = new Ray(rightHand.transform.position, rightHand.transform.forward);
        // 2.부딪혔다면
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // 만약 부딪힌 놈의 layer가 UI라면
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                // 3.그 위치에 빨건점 위치시킨다.
                dot.gameObject.SetActive(true);
                dot.position = hit.point;
            }
            else
            {
                dot.gameObject.SetActive(false);
            }
        }
        else
        {
            // 4.빨간점 안보이게
            dot.gameObject.SetActive(false);
        }

        // 만약에 점이 활성화 상태면
        if (dot.gameObject.activeSelf == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                // 버튼 스크립트를 가져온다
                Button btn = hit.transform.GetComponent<Button>();
                // 만약에 btn이 null이 아니라면
                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
            }
        }
    }
}
