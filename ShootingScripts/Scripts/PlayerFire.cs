using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // �Ѿ˰���
    public GameObject bulletFactory;
    // �߻���ġ
    // type�� GameObject -> Transform���� �ٲ� �� ����
    public Transform firePos;
    // Start is called before the first frame update


    // 2.�Ѿ��� �� �迭���� ����� �� �ִ� �Ѿ� ����Ѵ�.

    // źâ ����
    int magazineCnt = 10;

    // �Ѿ�źâ
    //GameObject[] bullets = new GameObject[5];
    List<GameObject> bulletList = new List<GameObject>();
    // �߻�� �Ѿ��� ��� ����
    List<GameObject> firedBullet = new List<GameObject>();

    void Start()
    {
        // 1.���ʿ� �Ѿ˰��忡�� �Ѿ��� 10���� ���� �迭�� �ִ´�.
        
        for (int i = 0; i < magazineCnt; i++)
        {
            // �Ѿ��� ���� �迭�� �ִ´�.
            GameObject bullet = Instantiate(bulletFactory);
            
            bullet.SetActive(false);
            
            bulletList.Add(bullet);
            
            // ������� �Ѿ��� ��Ȱ��ȭ�Ѵ�.
            //bullets[i].SetActive(false);
        }
        

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // źâ���� ��Ȱ��ȭ �Ǿ��ִ� �Ѿ� ã�´�.
           
            // ã�� �Ѿ��� Ȱ��ȭ ��Ű��
            bulletList[0].SetActive(true);
            // firePos�� ��ġ�� ���´�.
            bulletList[0].transform.position = firePos.position;
            // �߻�� ����Ʈ�� �߰�
            firedBullet.Add(bulletList[0]);
            //źâ���� ��������.
            bulletList.RemoveAt(0);
        }
    }

        ////1.����ڰ� Fire��ư�� ������
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    //2.�Ѿ��� �Ѿ� ���忡�� �����.
        //    GameObject bullet = Instantiate(bulletFactory);
        //    //3.������� �Ѿ��� firePos�� ��ġ�� ���´�.
        //    bullet.transform.position = firePos.position;
        //}
    //}

    public void AddMagazine(GameObject bullet)
    {
        // �Ѿ� ��Ȱ��ȭ
        bullet.SetActive(false);
        // źâ�� �������
        bulletList.Add(bullet);
        // �߻�� ����Ʈ���� ��������
        firedBullet.Remove(bullet);
    }
}

        
        
        
        


