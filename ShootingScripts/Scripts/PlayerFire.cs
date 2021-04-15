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


    // 2.총알을 쏠때 배열에서 사용할 수 있는 총알 사용한다.

    // 탄창 갯수
    int magazineCnt = 10;

    // 총알탄창
    //GameObject[] bullets = new GameObject[5];
    List<GameObject> bulletList = new List<GameObject>();
    // 발사된 총알을 담는 변수
    List<GameObject> firedBullet = new List<GameObject>();

    void Start()
    {
        // 1.최초에 총알공장에서 총알을 10개를 만들어서 배열을 넣는다.
        
        for (int i = 0; i < magazineCnt; i++)
        {
            // 총알을 만들어서 배열에 넣는다.
            GameObject bullet = Instantiate(bulletFactory);
            
            bullet.SetActive(false);
            
            bulletList.Add(bullet);
            
            // 만들어진 총알을 비활성화한다.
            //bullets[i].SetActive(false);
        }
        

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // 탄창에서 비활성화 되어있는 총알 찾는다.
           
            // 찾은 총알은 활성화 시키고
            bulletList[0].SetActive(true);
            // firePos의 위치로 놓는다.
            bulletList[0].transform.position = firePos.position;
            // 발사된 리스트에 추가
            firedBullet.Add(bulletList[0]);
            //탄창에서 지워주자.
            bulletList.RemoveAt(0);
        }
    }

        ////1.사용자가 Fire버튼을 누르면
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    //2.총알을 총알 공장에서 만든다.
        //    GameObject bullet = Instantiate(bulletFactory);
        //    //3.만들어진 총알을 firePos의 위치에 놓는다.
        //    bullet.transform.position = firePos.position;
        //}
    //}

    public void AddMagazine(GameObject bullet)
    {
        // 총알 비활성화
        bullet.SetActive(false);
        // 탄창에 집어놓고
        bulletList.Add(bullet);
        // 발사된 리스트에서 지워주자
        firedBullet.Remove(bullet);
    }
}

        
        
        
        


