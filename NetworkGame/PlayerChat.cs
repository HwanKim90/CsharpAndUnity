using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerChat : MonoBehaviourPun
{
    // ä�� ǥ���Ǵ� Text 
    public Text chatUI;

    public void SetChatValue(string text)
    {
        photonView.RPC("RpcSetChat", RpcTarget.All, text);
    }

    [PunRPC]
    void RpcSetChat(string text)
    {
        chatUI.text = text;
    }
}
