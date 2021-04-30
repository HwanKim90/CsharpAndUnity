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
    public GameObject bulletEftFactory;

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

            #region
            // �Ѿ˰��忡�� �Ѿ��� ���� (��ġ, ȸ��)
            //#if USE_PHOTON
            //PhotonNetwork.Instantiate("Bullet", firePos.position, firePos.rotation);
            //#else
            //GameObject bullet = Instantiate(bulletFactory);
            //bullet.transform.position = firePos.position;
            //bullet.transform.rotation = firePos.rotation;
            //#endif
            #endregion
        }
        // ���࿡ Fire2��ư�� ������
        if (Input.GetButtonDown("Fire2"))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.gameObject.name);
                // ���������� �Ѿ�ȿ�� �����޶�� ��û(RpcFireRay)
                photonView.RPC("RpcFireRay", RpcTarget.All, hit.point);
                
                // ���࿡ �������� layer�� Player���
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Player")) 
                {
                    print("�Ǵ�?");
                    // PlayerMove ������Ʈ �����ͼ�
                    PlayerMove pm = hit.transform.parent.GetComponent<PlayerMove>();
                    // OnDamaged�Լ� ȣ��
                    pm.OnDamaged(2);
                }
                
            }
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

    [PunRPC]
    void RpcFireRay(Vector3 hitPoint)
    {
        GameObject stonEft = Instantiate(bulletEftFactory);
        stonEft.transform.position = hitPoint;
        
        
    }
}
