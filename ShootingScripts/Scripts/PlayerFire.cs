using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // �Ѿ˰���
    public GameObject bulletFactory;
    // �߻���ġ
    public GameObject firePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1.����ڰ� Fire��ư�� ������
        if (Input.GetButtonDown("Fire1"))
        {
            //2.�Ѿ��� �Ѿ� ���忡�� �����.
            GameObject bullet = Instantiate(bulletFactory);
            //3.������� �Ѿ��� firePos�� ��ġ�� ���´�.
            bullet.transform.position = firePos.transform.position;
        }
    }
}
        

