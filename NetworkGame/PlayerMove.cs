using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun, IPunObservable
{
    public float moveSpeed = 5;

    // 상대방 위치, 회전
    Vector3 otherPos;
    Quaternion otherRot;

    // 카메라
    public GameObject cam;

    // 총
    public Transform gun;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 보내기
        if (stream.IsWriting)
        {
            // 나의 위치와 회전값을 보낸다.
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            // 총의 회전값을 보낸다.
            stream.SendNext(gun.rotation);
        }

        // 받기
        if(stream.IsReading)
        {
            // 누군가의 위치값과 회전값을 받는다.
            otherPos = (Vector3)stream.ReceiveNext();
            otherRot = (Quaternion)stream.ReceiveNext();
            // 누군가의 총 회전값을 받는다.
            gun.rotation = (Quaternion)stream.ReceiveNext();
        }
    }

    void Start()
    {
        // 내것일때만 카메라를 켜주자
        if (photonView.IsMine)
            cam.SetActive(true);
    }

    void Update()
    {
        // 내거일때만 움직이자.
        if (photonView.IsMine)
        {
            Move();
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, otherPos, 0.2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, otherRot, 0.2f);
        }

    }



    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        dir.Normalize();

        // 카메라가 보는 방향으로 dir 재설정
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    
}
        
