using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알공장
    public GameObject bulletFactory;
    // 발사위치
    // type을 GameObject -> Transform으로 바꿀 수 있음
    public Transform firePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1.사용자가 Fire버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            //2.총알을 총알 공장에서 만든다.
            GameObject bullet = Instantiate(bulletFactory);
            //3.만들어진 총알을 firePos의 위치에 놓는다.
            bullet.transform.position = firePos.position;
        }
    }
}
        

