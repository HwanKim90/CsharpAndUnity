using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObj : MonoBehaviour
{
    LineRenderer lr;

    // ���� ���� Transform
    Transform catchedObj;

    // ������ ��
    public float throwPower = 3f;
    public GameObject cubeFactory;
    // �޼�Ʈ������
    public Transform leftHand;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        //DrawGuideLine();
        CatchObj();
        DropObj();
    }


    void DrawGuideLine()
    {
        // 1.������ ��ġ, ������ �չ��⿡�� �߻��ϴ� Ray�� �����.
        Ray ray = new Ray(transform.position, transform.forward);
        // 2.�ε��� ���� �ִٸ�
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // 3.�ε��� �������� Line�� �׸���.
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }
        else
        {
            // 4.�ε��� ������ ������ ��������ġ���� ������ �չ������� �� ���ͱ��� �׷���
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + transform.forward * 1);
        }
    }


    void CatchObj()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, 0.5f);

            //// 1.������ ��ġ, ������ �չ��⿡�� �߻��ϴ� Ray�� �����.
            //Ray ray = new Ray(transform.position, transform.forward);
            //// 2.������ r �� ������� �߻��Ѵ�.
            //RaycastHit hit;

            //if (Physics.SphereCast(ray, 0.5f, out hit, 100f))
            if (hits.Length > 0)
            {
                // ������ ����
                catchedObj = hits[0].transform;
                // 3.�ε��� ���� ������ �ڽ����� ���´�.
                hits[0].transform.SetParent(transform);
                // 4.�ε��� ���� ���� ������ ���� �ʰ�
                Rigidbody rb = hits[0].transform.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                // 5.�������� ����ġ��
                //hit.transform.position = transform.position;
                hits[0].transform.localPosition = Vector3.zero;
                // 6.ť����忡�� ť�긦 �����
                GameObject cube = Instantiate(cubeFactory);
                // 7.����ť�긦 ���� �տ� ���δ�.
                cube.transform.SetParent(leftHand);
                // 8.����ť�긦 �޼���ǥ�� ��ġ��Ų��.
                cube.transform.localPosition = Vector3.zero;
            }
        }
    }

    
    void DropObj()
    {
        // �þ࿡ �������� ���ٸ� �Լ��� ������
        if (catchedObj == null) return;

        // ������ B��ư�� ����
        if (OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            // ��� �ִ� ������Ʈ�� �θ� null
            catchedObj.SetParent(null);
            // ��� �ִ� ������Ʈ -> rigidBody -> isKinematic�� false��
            catchedObj.GetComponent<Rigidbody>().isKinematic = false;
            // ������
            ThrowObj();
            // ������ �����Ѱ� ����(null)
            catchedObj = null;

        }
    }
    

    void ThrowObj()
    {
        // ��Ʈ�ѷ� �ӵ�(����, ũ��)�� ������.
        // 1.rigidBody��������
        Rigidbody rb = catchedObj.GetComponent<Rigidbody>();
        // 2.velocity�� ����
        rb.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * throwPower;
        // 3.���ӵ� ����
        rb.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);
    }
}
