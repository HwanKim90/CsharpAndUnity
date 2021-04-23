using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItweenTest : MonoBehaviour
{
    // 애니메이션이 적용될 오브젝트
    public GameObject target;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            iTween.MoveBy(target, iTween.Hash(
                "x", 5,
                "time", 1,
                "easetype", iTween.EaseType.easeOutBounce,
                "oncomplete", "OnCompleteAni",
                "oncompletetarget", gameObject,
                "onupdate", "OnUpdateAni",
                "onupdatetarget", gameObject
                
            ));

            //iTween.ScaleTo(target, iTween.Hash(
            //    "delay", 2,
            //    "scale", new Vector3(2, 2, 2),
            //    "time", 1,
            //    "easetype", iTween.EaseType.easeOutBounce

            //));

        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RectTransform rt = target.GetComponent<RectTransform>();
                
            iTween.ValueTo(gameObject, iTween.Hash(
                "time", 1,
                "from", rt.anchoredPosition.x,
                "to", 0,
                "easetype", iTween.EaseType.easeOutBounce,
                "onupdate", "OnUpdateAniUI",
                "onupdatetarget", gameObject
            ));
        }

        
    }

    void OnCompleteAni()
    {
        print("iTween Complete");
        
    }

    void OnUpdateAni()
    {
        print("iTween OnUpdate");
    }

    void OnUpdateAniUI(float value)
    {
        RectTransform rt = target.GetComponent<RectTransform>();
        Vector2 pos = rt.anchoredPosition;
        pos.x = value;
        rt.anchoredPosition = pos;
        print(value);
    }
}
