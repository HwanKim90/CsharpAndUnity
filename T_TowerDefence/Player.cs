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

    //내 몸
    public Transform [] myBody;
    //너 팔, 머리
    public Transform [] otherBody;

    Vector3 pos;
    SyncData[] syncData;

    // 큐브 공장
    public GameObject cubeFactory;
    // 잡은 놈의 트렌스폼
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
        //6. 큐브공장에서 큐브를 만든다
        GameObject cube = Instantiate(cubeFactory);
        if (photonView.IsMine)
        {
            //7. 만든 큐브를 왼손에 붙인다
            cube.transform.SetParent(myBody[1]);
        }
        else
        {
            cube.transform.SetParent(otherBody[1]);
        }
        //8. 만든 큐브를 왼손 좌표에 위치시킨다.
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
            //잡은놈 저장
            catchedObj = hits[0].transform;
           
            //3. 부딪힌 놈을 오른손 자식으로 놓는다.
            hits[0].transform.SetParent(rHand);
           
            //4. 부딪힌 놈의 물리 연산이 되지 않게
            Rigidbody rb = hits[0].transform.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            //5. 잡은놈을 손위치로
            hits[0].transform.localPosition = Vector3.zero;
            //hit.transform.localPosition = Vector3.zero;
        }
    }

    [PunRPC]
    void RpcDropObj()
    {
        // 잡고 있는 오브젝트의 부모를 null
        catchedObj.SetParent(null);
        // 잡고 있는 오브젝트 -> RigidBody -> isKinematic 을 false로
        catchedObj.GetComponent<Rigidbody>().isKinematic = false;

        // 던진다
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
        // 컨트롤러 속도(방향, 크기) 로 던진다
        // 1. 리지드 바디가져오자
        Rigidbody rb = catchedObj.GetComponent<Rigidbody>();
        // 2. 속도를 셋팅
        rb.velocity = velocity;// OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * throwPower;
        // 3. 각속도 셋팅
        rb.angularVelocity = angleVelocity;// OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);

        // 잡은놈 저장한것 리셋(null)
        catchedObj = null;
    }
}
