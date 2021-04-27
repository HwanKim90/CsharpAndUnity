using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun
{
    public float moveSpeed = 5;

    private void Start()
    {
       
    }

    void Update()
    {
        // 내거일때만 움직이자.
        if (photonView.IsMine)
        {
            Move();
        }

    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);

        dir.Normalize();

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
        
