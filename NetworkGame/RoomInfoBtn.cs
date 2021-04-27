using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomInfoBtn : MonoBehaviour
{
    // ������ ������ �ؽ�Ʈ
    public Text info;
    
    // ���� ����
    public void SetInfo(string roomName, int currPlayer, int maxPlayer)
    {
        // ������ (�����ο� / �ִ��ο�)
        info.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")";
    }
}
