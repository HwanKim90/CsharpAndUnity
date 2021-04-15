using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    GameObject target;
    public float speed = 5;
    Vector3 dir;
    // ���߰���
    public GameObject exploFactory;

    void Start()
    {
        

        int rand = Random.Range(1, 11);

        //Random.Range()
        if (rand < 4)
        {

            // ����1,2,3�� ������ �Ʒ���!
            dir = Vector3.down;

        }
        else 
        {
            // Plyer GameObject ã�Ƽ� target�� �ֱ�
            target = GameObject.Find("Player");

            if (target != null)
            {
                // ����4,5,6,7,8,9,10�� ������ Player�� 
                dir = target.transform.position - transform.position;
                dir.Normalize();
            }
            
        }


        // 5�� �ִٰ� �ı��϶�
        //Destroy(gameObject, 5);
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
        // 1.ScoreManager ���ӿ�����Ʈ ã��
        GameObject smObj = GameObject.Find("ScoreManager");
        
        // 2.ã�� ScoreManager ���ӿ�����Ʈ -> ScoreManager��ũ��Ʈ
        ScoreManager sm = smObj.GetComponent<ScoreManager>();

        // 3.sm�� ������ �ִ� AddScore�Լ� ����
        sm.AddScore(10);


        // 1.�浹���忡�� �浹ȿ���� ����
        GameObject explo = Instantiate(exploFactory);
        
        // 2.������� ȿ���� ��ġ��Ų��.
        explo.transform.position = transform.position;

        //print("Collision : " + collision.gameObject.name);
        // �浹�� ���ӿ�����Ʈ ���ְ�
        Destroy(collision.gameObject);
        
        // ���� ���ӿ�����Ʈ ������
        Destroy(gameObject);
    }

    


}

    

    


