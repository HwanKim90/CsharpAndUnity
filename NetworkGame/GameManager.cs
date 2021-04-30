using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    // 내 Player만 저장
    public GameObject myPlayer;
    // 채팅 InputFiled
    public InputField inputChat;

    void Start()
    {
        // 내 Player 생성
        myPlayer = PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void OnClickChat()
    {
        // 내 플레이어에서 PlayerChat 컴포넌트 가져오자
        PlayerChat pc = myPlayer.GetComponent<PlayerChat>();
        // SetChatValue 함수 실행
        pc.SetChatValue(inputChat.text);
    }
}
