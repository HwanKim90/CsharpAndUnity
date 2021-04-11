using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    GameObject target;
    public float speed = 5;
    Vector3 dir;



    void Start()
    {
        // Plyer GameObject ã�Ƽ� target�� �ֱ�
        target = GameObject.Find("Player");

        int rand = Random.Range(1, 11);

        //Random.Range()
        if (rand < 4)
        {

            // ����1,2,3�� ������ �Ʒ���!
            dir = Vector3.down;

        }
        else 
        {
            // ����4,5,6,7,8,9,10�� ������ Player�� 

            dir = target.transform.position - transform.position;
            dir.Normalize();
        }


        // �¾�� �ѹ��� ������ ���ϰ�
    }


    // Update is called once per frame
    void Update()
    {
        // �Ʒ��� ��� �����̰� �ʹ�.
        //transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Ÿ���� ���ϴ� ���� ���ϱ�
        //dir = target.transform.position - transform.position;
        //dir.Normalize();

        // �׹������� ��� �����̰� �ʹ�.
        // �̵����� p = p0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collision : " + collision.gameObject.name);
        // �浹�� ���ӿ�����Ʈ ���ְ�
        Destroy(collision.gameObject);
        // ���� ���ӿ�����Ʈ ������
        Destroy(gameObject);
    }

    


}

    

    


