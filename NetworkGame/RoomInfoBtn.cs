using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ŭ�� �Ǿ����� ȣ��Ǵ� �Լ� ����� �� �ִ� delegate
//public delegate void ClickAction(string s);

public class RoomInfoBtn : MonoBehaviour
{
    // Ŭ�� �Ǿ����� ȣ�� �Ǵ� �Լ�
    public Action<string> clickAction;
    //public ClickAction clickAction;
    // ������ ������ �ؽ�Ʈ
    public Text info;

    // ������
    string room;
    
    // ���� ����
    public void SetInfo(string roomName, int currPlayer, int maxPlayer)
    {   
        // ������ ����
        room = roomName;
        // ������ (�����ο� / �ִ��ο�)
        info.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")";
    }

    public void OnClick()
    {
        // clickAction ���� �ִٸ�
        if (clickAction != null)
        {
            clickAction(room);
        }



        //// LobbyManager(GameObject) ã��
        //GameObject go = GameObject.Find("LobbyManager");
        //// LobbyManager(������Ʈ) ã��
        //LobbyManager lm = go.GetComponent<LobbyManager>();
        //// roomNameInput.text�� �������� ����
        //lm.roomNameInput.text = room;
    }
}
