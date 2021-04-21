using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAniEvent : MonoBehaviour
{
    public void PlayerHit()
    {
        // Enemy 컴포넌트 가져와서 
        Enemy enemy = GetComponentInParent<Enemy>();
        // AttackAction 함수 실행
        enemy.AttackAction();
    }
}
