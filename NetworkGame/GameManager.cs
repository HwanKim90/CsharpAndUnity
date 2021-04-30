using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    // �� Player�� ����
    public GameObject myPlayer;
    // ä�� InputFiled
    public InputField inputChat;

    void Start()
    {
        // �� Player ����
        myPlayer = PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void OnClickChat()
    {
        // �� �÷��̾�� PlayerChat ������Ʈ ��������
        PlayerChat pc = myPlayer.GetComponent<PlayerChat>();
        // SetChatValue �Լ� ����
        pc.SetChatValue(inputChat.text);
    }
}
