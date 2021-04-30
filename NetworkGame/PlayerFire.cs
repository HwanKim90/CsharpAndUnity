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
    public GameObject bulletEftFactory;

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

            #region
            // 총알공장에서 총알을 생성 (위치, 회전)
            //#if USE_PHOTON
            //PhotonNetwork.Instantiate("Bullet", firePos.position, firePos.rotation);
            //#else
            //GameObject bullet = Instantiate(bulletFactory);
            //bullet.transform.position = firePos.position;
            //bullet.transform.rotation = firePos.rotation;
            //#endif
            #endregion
        }
        // 만약에 Fire2버튼을 누르면
        if (Input.GetButtonDown("Fire2"))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.gameObject.name);
                // 맞은지점에 총알효과 보여달라고 요청(RpcFireRay)
                photonView.RPC("RpcFireRay", RpcTarget.All, hit.point);
                
                // 만약에 맞은놈이 layer가 Player라면
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Player")) 
                {
                    print("되니?");
                    // PlayerMove 컴포넌트 가져와서
                    PlayerMove pm = hit.transform.parent.GetComponent<PlayerMove>();
                    // OnDamaged함수 호출
                    pm.OnDamaged(2);
                }
                
            }
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

    [PunRPC]
    void RpcFireRay(Vector3 hitPoint)
    {
        GameObject stonEft = Instantiate(bulletEftFactory);
        stonEft.transform.position = hitPoint;
        
        
    }
}
