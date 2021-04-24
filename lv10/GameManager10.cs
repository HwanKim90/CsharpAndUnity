using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager10 : MonoBehaviour
{
    public static GameManager10 instance;

    public static int lv10_deathCnt = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public float MoveSpeedUp(float moveSpeed)
    {
        if (GameManager10.lv10_deathCnt > 3 && GameManager10.lv10_deathCnt < 10)
            moveSpeed = 3.5f;
      
        if (GameManager10.lv10_deathCnt == 10)
            moveSpeed = 5f;
      
        return moveSpeed;
    }
}
            
      

            

       

            

