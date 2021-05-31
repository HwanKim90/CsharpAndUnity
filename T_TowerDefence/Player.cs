using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun, IPunObservable
{

    struct SyncData
    {
        public Vector3 pos;
        public Quaternion rotation;
    }
    
    public GameObject myModel;
    public GameObject otherModel;

    //�� ��
    public Transform [] myBody;
    //�� ��, �Ӹ�
    public Transform [] otherBody;

    Vector3 pos;
    SyncData[] syncData;

    // ť�� ����
    public GameObject cubeFactory;
    // ���� ���� Ʈ������
    public Transform catchedObj;

    void Start()
    {
        if(photonView.IsMine == false)
        {
            syncData = new SyncData[myBody.Length];
        }

        myModel.SetActive(photonView.IsMine);
        otherModel.SetActive(!photonView.IsMine);
    }

    void Update()
    {
        if(photonView.IsMine == false)
        {
            transform.position = Vector3.Lerp(transform.position, pos, 0.2f);

            for(int i = 0; i < otherBody.Length; i++)
            {
                otherBody[i].position = Vector3.Lerp(
                    otherBody[i].position,
                    syncData[i].pos, 0.2f);

                otherBody[i].rotation = Quaternion.Lerp(
                    otherBody[i].rotation,
                    syncData[i].rotation, 0.2f);
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(transform.position);
            for(int i = 0; i < myBody.Length; i++)
            {
                stream.SendNext(myBody[i].position);
                stream.SendNext(myBody[i].rotation);
            }
        }

        if(stream.IsReading)
        {
            pos = (Vector3)stream.ReceiveNext();

            if(syncData != null)
            {
                for (int i = 0; i < otherBody.Length; i++)
                {  
                    syncData[i].pos = (Vector3)stream.ReceiveNext();
                    syncData[i].rotation = (Quaternion)stream.ReceiveNext();
                }
            }
        }
    }

    [PunRPC]
    void RpcCreateCube()
    {
        //6. ť����忡�� ť�긦 �����
        GameObject cube = Instantiate(cubeFactory);
        if (photonView.IsMine)
        {
            //7. ���� ť�긦 �޼տ� ���δ�
            cube.transform.SetParent(myBody[1]);
        }
        else
        {
            cube.transform.SetParent(otherBody[1]);
        }
        //8. ���� ť�긦 �޼� ��ǥ�� ��ġ��Ų��.
        cube.transform.localPosition = Vector3.zero;
    }

    [PunRPC]
    void RpcCatchObj()
    {
        Transform rHand = otherBody[2];
        if (photonView.IsMine) rHand = myBody[2];        

        Collider[] hits = Physics.OverlapSphere(rHand.position, 0.1f);

        if (hits.Length > 0)
        {
            //������ ����
            catchedObj = hits[0].transform;
           
            //3. �ε��� ���� ������ �ڽ����� ���´�.
            hits[0].transform.SetParent(rHand);
           
            //4. �ε��� ���� ���� ������ ���� �ʰ�
            Rigidbody rb = hits[0].transform.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            //5. �������� ����ġ��
            hits[0].transform.localPosition = Vector3.zero;
            //hit.transform.localPosition = Vector3.zero;
        }
    }

    [PunRPC]
    void RpcDropObj()
    {
        // ��� �ִ� ������Ʈ�� �θ� null
        catchedObj.SetParent(null);
        // ��� �ִ� ������Ʈ -> RigidBody -> isKinematic �� false��
        catchedObj.GetComponent<Rigidbody>().isKinematic = false;

        // ������
        if(photonView.IsMine)
        {
            photonView.RPC("RpcThrowObj", RpcTarget.All,
                OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * 3,
                OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch));
        }
    }

    [PunRPC]
    void RpcThrowObj(Vector3 velocity, Vector3 angleVelocity)
    {
        // ��Ʈ�ѷ� �ӵ�(����, ũ��) �� ������
        // 1. ������ �ٵ�������
        Rigidbody rb = catchedObj.GetComponent<Rigidbody>();
        // 2. �ӵ��� ����
        rb.velocity = velocity;// OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * throwPower;
        // 3. ���ӵ� ����
        rb.angularVelocity = angleVelocity;// OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);

        // ������ �����Ѱ� ����(null)
        catchedObj = null;
    }
}
