using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrabObj : MonoBehaviour
{
    LineRenderer lr;

    // 던지는 파워
    public float throwPower = 3;
        
    // 왼손 트랜스폼
    public Transform leftHand;

    // PhotonView
    public PhotonView photonView;
    public Player player;

    void Start()
    {
        lr = GetComponent<LineRenderer>();   
    }

    void Update()
    {
        if (photonView.IsMine == false) return;

        CreateCube();
        //DrawGuideLine();
        CatchObj();
        DropObj();
    }

    void DrawGuideLine()
    {
        //1. 오른손 위치, 오른손 앞방향에서 발사하는 Ray를 만든다.
        Ray ray = new Ray(transform.position, transform.forward);
        //2. 부딪힌 곳이 있다면
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //3. 부딪힌 지점까지 Line 을 그린다
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }
        else
        {
            //4. 부딪힌 지점이 없으면 오른손위치에서 오른손 앞방향으로 몇미터까지 그려라
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + transform.forward * 1);
        }
    }

    void CatchObj()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            photonView.RPC("RpcCatchObj", RpcTarget.All);
        }
    }

    void CreateCube()
    {
        // 만약에 왼쪽컨트롤러 X버튼을 누르면
        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            photonView.RPC("RpcCreateCube", RpcTarget.All);
        }
    }

    
    void DropObj()
    {
        // 만약에 잡은놈 놈이 없다면 함수를 나가라
        if (player.catchedObj == null) return;

        // 오른손 B 버튼을 떼면
        if(OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            photonView.RPC("RpcDropObj", RpcTarget.All);
        }
    }

}
