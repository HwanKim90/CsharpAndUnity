using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrabObj : MonoBehaviour
{
    LineRenderer lr;

    // ������ �Ŀ�
    public float throwPower = 3;
        
    // �޼� Ʈ������
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
        //1. ������ ��ġ, ������ �չ��⿡�� �߻��ϴ� Ray�� �����.
        Ray ray = new Ray(transform.position, transform.forward);
        //2. �ε��� ���� �ִٸ�
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //3. �ε��� �������� Line �� �׸���
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }
        else
        {
            //4. �ε��� ������ ������ ��������ġ���� ������ �չ������� ����ͱ��� �׷���
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
        // ���࿡ ������Ʈ�ѷ� X��ư�� ������
        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            photonView.RPC("RpcCreateCube", RpcTarget.All);
        }
    }

    
    void DropObj()
    {
        // ���࿡ ������ ���� ���ٸ� �Լ��� ������
        if (player.catchedObj == null) return;

        // ������ B ��ư�� ����
        if(OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            photonView.RPC("RpcDropObj", RpcTarget.All);
        }
    }

}
