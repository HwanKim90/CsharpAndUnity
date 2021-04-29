using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun, IPunObservable
{
    public float moveSpeed = 5;

    // ���� ��ġ, ȸ��
    Vector3 otherPos;
    Quaternion otherRot;

    // ī�޶�
    public GameObject cam;

    // ��
    public Transform gun;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // ������
        if (stream.IsWriting)
        {
            // ���� ��ġ�� ȸ������ ������.
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            // ���� ȸ������ ������.
            stream.SendNext(gun.rotation);
        }

        // �ޱ�
        if(stream.IsReading)
        {
            // �������� ��ġ���� ȸ������ �޴´�.
            otherPos = (Vector3)stream.ReceiveNext();
            otherRot = (Quaternion)stream.ReceiveNext();
            // �������� �� ȸ������ �޴´�.
            gun.rotation = (Quaternion)stream.ReceiveNext();
        }
    }

    void Start()
    {
        // �����϶��� ī�޶� ������
        if (photonView.IsMine)
            cam.SetActive(true);
    }

    void Update()
    {
        // �����϶��� ��������.
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

        // ī�޶� ���� �������� dir �缳��
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    
}
        
