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
        // ���࿡ ���콺 Ŭ���Ѵٸ�
        if (Input.GetMouseButtonDown(0))
        {
            // ���ΰ������� ������ �����.
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
            // ī�޶� ��ġ���� ���ο� ��� �߰�
            Vector3 pos = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;

            currLine.positionCount = index + 1;

            currLine.SetPosition(index, pos);

            index++;
        }
    }

    public void OnButtonUp()
    {
        print("��ư ��!!!");
    }

    public void OnButtonDown()
    {
        print("��ư �ٿ�!!");
    }
}
