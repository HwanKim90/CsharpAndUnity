using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAniEvent : MonoBehaviour
{
    public void PlayerHit()
    {
        // Enemy ������Ʈ �����ͼ� 
        Enemy enemy = GetComponentInParent<Enemy>();
        // AttackAction �Լ� ����
        enemy.AttackAction();
    }
}
