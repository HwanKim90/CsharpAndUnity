using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObj : MonoBehaviour
{
    LineRenderer lr;

    // 잡은 놈의 Transform
    Transform catchedObj;

    // 던지는 힘
    public float throwPower = 3f;
    public GameObject cubeFactory;
    // 왼손트랜스폼
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
        // 1.오른손 위치, 오른손 앞방향에서 발사하는 Ray를 만든다.
        Ray ray = new Ray(transform.position, transform.forward);
        // 2.부딪힌 곳이 있다면
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // 3.부딪힌 지점까지 Line을 그린다.
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }
        else
        {
            // 4.부딪힌 지점이 없으면 오른손위치에서 오른손 앞방향으로 몇 미터까지 그려라
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + transform.forward * 1);
        }
    }


    void CatchObj()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, 0.5f);

            //// 1.오른손 위치, 오른손 앞방향에서 발사하는 Ray를 만든다.
            //Ray ray = new Ray(transform.position, transform.forward);
            //// 2.반지름 r 인 구모양을 발사한다.
            //RaycastHit hit;

            //if (Physics.SphereCast(ray, 0.5f, out hit, 100f))
            if (hits.Length > 0)
            {
                // 잡은놈 저장
                catchedObj = hits[0].transform;
                // 3.부딪힌 놈을 오른손 자식으로 놓는다.
                hits[0].transform.SetParent(transform);
                // 4.부딪힌 놈의 물리 연산이 되지 않게
                Rigidbody rb = hits[0].transform.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                // 5.잡은놈을 손위치로
                //hit.transform.position = transform.position;
                hits[0].transform.localPosition = Vector3.zero;
                // 6.큐브공장에서 큐브를 만든다
                GameObject cube = Instantiate(cubeFactory);
                // 7.만든큐브를 왼쪽 손에 붙인다.
                cube.transform.SetParent(leftHand);
                // 8.만든큐브를 왼손좌표에 위치시킨다.
                cube.transform.localPosition = Vector3.zero;
            }
        }
    }

    
    void DropObj()
    {
        // 먄약에 잡은놈이 없다면 함수를 나가라
        if (catchedObj == null) return;

        // 오른손 B버튼을 때면
        if (OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            // 잡고 있는 오브젝트의 부모를 null
            catchedObj.SetParent(null);
            // 잡고 있는 오브젝트 -> rigidBody -> isKinematic을 false로
            catchedObj.GetComponent<Rigidbody>().isKinematic = false;
            // 던진다
            ThrowObj();
            // 잡은놈 저장한것 리셋(null)
            catchedObj = null;

        }
    }
    

    void ThrowObj()
    {
        // 컨트롤러 속도(방향, 크기)로 던진다.
        // 1.rigidBody가져오자
        Rigidbody rb = catchedObj.GetComponent<Rigidbody>();
        // 2.velocity를 셋팅
        rb.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * throwPower;
        // 3.각속도 셋팅
        rb.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);
    }
}
