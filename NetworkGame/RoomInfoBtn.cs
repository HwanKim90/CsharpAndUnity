using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomInfoBtn : MonoBehaviour
{
    // 정보를 보여줄 텍스트
    public Text info;
    
    // 정보 세팅
    public void SetInfo(string roomName, int currPlayer, int maxPlayer)
    {
        // 방제목 (현재인원 / 최대인원)
        info.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")";
    }
}
