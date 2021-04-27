using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    // ���ӹ���
    public string gameVersion = "1";
    // �г���
    public InputField nickName;

    public void Connect()
    {

        // ���࿡ nickname�� ���̰� 0�̶��
        if (nickName.text.Length == 0)
        {
            // ���Ӹ��ϰ�
            Debug.LogWarning("�г����� �Է����ּ���.");
        }
        else
        {
            // 1.Game Version �� �����Ѵ�.
            PhotonNetwork.GameVersion = gameVersion;
            // 2.Scene�� ����ȭ ���θ� ����
            PhotonNetwork.AutomaticallySyncScene = true;
            // 3.����
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    // Name Server ���� ����
    public override void OnConnected()
    {
        print("OnConnected");
    }

    // Master Server ���� ����
    public override void OnConnectedToMaster()
    {
        print("OnConnectedToMaster");

        // �г��� �����ϰ� 
        PhotonNetwork.NickName = nickName.text;
        // �κ����� ��û
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    // Lobby ���� ����
    public override void OnJoinedLobby()
    {
        print("OnJoinedLobby");
        //// �κ������ �̵�
        PhotonNetwork.LoadLevel("LobbyScene");
    }

    
}
