using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_State_LV10 : MonoBehaviour
{
    enum PlayerState
    {
        Move,
        Fly,
        Respawn
    }

    //public static int deathCount = 0;
    

    public Transform flyPoint;
    public Transform startPoint;
    

    PlayerState state;
    Material originMat;
    

    float moveSpeed = 2.5f;
    public float flySpeed = 15f;
    void Start()
    {
        
        state = PlayerState.Move;
        
        originMat = startZone.GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case PlayerState.Move:
                MoveInput();
                
                break;
            case PlayerState.Fly:
                Fly();
                break;
            case PlayerState.Respawn:
                Respawn();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "Enemy" || other.CompareTag("RotEnemy"))
        {
            state = PlayerState.Fly;
            if (GameManager10.lv10_deathCnt >= 0 && GameManager10.lv10_deathCnt <=10) GameManager10.lv10_deathCnt++;
            moveSpeed = GameManager10.instance.MoveSpeedUp(moveSpeed);
            Debug.Log(moveSpeed);
            //deathCount++;
            //PlayerPrefs.SetInt("deathCount", deathCount);
            //deathUI.text = "Death : " + PlayerPrefs.GetInt("deathCount");
        }
    }

    void MoveInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        dir.Normalize();

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

   
        

        
        

    void Fly()
    {
        MoveFlyAni();
        FlyRotateAni();
        state = PlayerState.Respawn;
    }
        


        

    void MoveFlyAni()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "position", flyPoint,

            "time", 0.7f,
            "oncomplete", "ReturnStartPointAni",
            "easetype", "easeOutCubic"
        ));
    }
        
    void ReturnStartPointAni()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
             
             "position", startPoint,
            
             "time", 0.7f,
             "easetype", "easeInSine"
        ));
    }

    void FlyRotateAni()
    {
        iTween.RotateTo(gameObject, iTween.Hash(
            "rotation", new Vector3(180, 180, 180) * 5,
            "time", 2f
            
        
        ));
    }
        
        
           
        
       
           
           

        

    public float rotSpeed = 2f;
    
    void RotateCube()
    {
        transform.Rotate(new Vector3(180, 180, 0) * Time.deltaTime * rotSpeed) ;
    }

    public GameObject startZone;
    public Material mat;
    
    void Respawn()
    {
        if (Vector3.Distance(transform.position, startPoint.position) <= 1f)
        {
            startZone.GetComponent<Renderer>().material = mat;
            transform.position = startPoint.transform.position;

            StartCoroutine(bottomEft());

            state = PlayerState.Move;
        }
    }
        
            
            
            
        

    IEnumerator bottomEft()
    {
        
        startZone.GetComponent<Renderer>().material = mat;
        yield return new WaitForSeconds(0.1f);

        startZone.GetComponent<Renderer>().material = originMat;
        yield return new WaitForSeconds(0.1f);

        startZone.GetComponent<Renderer>().material = mat;
        yield return new WaitForSeconds(0.1f);

        startZone.GetComponent<Renderer>().material = originMat;
        yield return new WaitForSeconds(0.1f);
    }
}
