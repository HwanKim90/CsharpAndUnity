using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 클릭 되엇을때 호출되는 함수 등록할 수 있는 delegate
//public delegate void ClickAction(string s);

public class RoomInfoBtn : MonoBehaviour
{
    // 클릭 되었을때 호출 되는 함수
    public Action<string> clickAction;
    //public ClickAction clickAction;
    // 정보를 보여줄 텍스트
    public Text info;

    // 방제목
    string room;
    
    // 정보 세팅
    public void SetInfo(string roomName, int currPlayer, int maxPlayer)
    {   
        // 방제목 저장
        room = roomName;
        // 방제목 (현재인원 / 최대인원)
        info.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")";
    }

    public void OnClick()
    {
        // clickAction 값이 있다면
        if (clickAction != null)
        {
            clickAction(room);
        }



        //// LobbyManager(GameObject) 찾자
        //GameObject go = GameObject.Find("LobbyManager");
        //// LobbyManager(컨포넌트) 찾자
        //LobbyManager lm = go.GetComponent<LobbyManager>();
        //// roomNameInput.text에 방제목을 넣자
        //lm.roomNameInput.text = room;
    }
}
