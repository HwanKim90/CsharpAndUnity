using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerFire : MonoBehaviourPun
{
    // 총구
    public Transform firePos;
    // 총알공장
    public GameObject bulletFactory;

    void Start()
    {
        
    }

    
    void Update()
    {
        // 내것이 아니면 함수를 나가자!
        if (photonView.IsMine == false) return;

        // 만약에 Fire1버튼을 누르면
        if(Input.GetButtonDown("Fire1")) 
        {
            photonView.RPC("RpcFire", RpcTarget.All, firePos.position, firePos.rotation);


            // 총알공장에서 총알을 생성 (위치, 회전)
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
        // 총알생성
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = pos;
        bullet.transform.rotation = rot;
    }
}
