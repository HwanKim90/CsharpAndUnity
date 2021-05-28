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
        // 1.Ray ����� (������ ��ġ, ������ �չ���)
        Ray ray = new Ray(rightHand.transform.position, rightHand.transform.forward);
        // 2.�ε����ٸ�
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // ���� �ε��� ���� layer�� UI���
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                // 3.�� ��ġ�� ������ ��ġ��Ų��.
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
            // 4.������ �Ⱥ��̰�
            dot.gameObject.SetActive(false);
        }

        // ���࿡ ���� Ȱ��ȭ ���¸�
        if (dot.gameObject.activeSelf == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                // ��ư ��ũ��Ʈ�� �����´�
                Button btn = hit.transform.GetComponent<Button>();
                // ���࿡ btn�� null�� �ƴ϶��
                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
            }
        }
    }
}
