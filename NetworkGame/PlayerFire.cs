using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerFire : MonoBehaviourPun
{
    // �ѱ�
    public Transform firePos;
    // �Ѿ˰���
    public GameObject bulletFactory;

    void Start()
    {
        
    }

    
    void Update()
    {
        // ������ �ƴϸ� �Լ��� ������!
        if (photonView.IsMine == false) return;

        // ���࿡ Fire1��ư�� ������
        if(Input.GetButtonDown("Fire1")) 
        {
            photonView.RPC("RpcFire", RpcTarget.All, firePos.position, firePos.rotation);


            // �Ѿ˰��忡�� �Ѿ��� ���� (��ġ, ȸ��)
//#if USE_PHOTON
            //PhotonNetwork.Instantiate("Bullet", firePos.position, firePos.rotation);
//#else
            //GameObject bullet = Instantiate(bulletFactory);
            //bullet.transform.position = firePos.position;
            //bullet.transform.rotation = firePos.rotation;
//#endif
        }
    }

    [PunRPC]
    void RpcFire(Vector3 pos, Quaternion rot)
    {
        // �Ѿ˻���
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = pos;
        bullet.transform.rotation = rot;
    }
}
