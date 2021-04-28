using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    // 게임버전
    public string gameVersion = "1";
    // 닉네임
    public InputField nickName;

    public void Connect()
    {

        // 만약에 nickname의 길이가 0이라면
        if (nickName.text.Length == 0)
        {
            // 접속못하게
            Debug.LogWarning("닉네임을 입력해주세요.");
        }
        else
        {
            // 1.Game Version 을 설정한다.
            PhotonNetwork.GameVersion = gameVersion;
            // 2.Scene을 동기화 여부를 설정
            PhotonNetwork.AutomaticallySyncScene = true;
            // 3.접속
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    // Name Server 접속 성공
    public override void OnConnected()
    {
        print("OnConnected");
    }

    // Master Server 접속 성공
    public override void OnConnectedToMaster()
    {
        print("OnConnectedToMaster");

        // 닉네임 설정하고 
        PhotonNetwork.NickName = nickName.text;
        // 로비접속 요청
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        //PhotonNetwork.JoinLobby(new TypedLobby("로비이름",LobbyType.Default));
    }

    // Lobby 접속 성공
    public override void OnJoinedLobby()
    {
        print("OnJoinedLobby");
        //// 로비씬으로 이동
        PhotonNetwork.LoadLevel("LobbyScene");
    }

    
}
