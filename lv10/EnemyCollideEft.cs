using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollideEft : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScaleUpAni();

        }
    }

    void ScaleUpAni()
    {
        

        if (gameObject.CompareTag("RotEnemy") && GameManager10.lv10_deathCnt < 4)
        {
            iTween.ScaleTo(gameObject, iTween.Hash(
                "scale", new Vector3(3f, 3f, 3f),
                "time", 0.1f,
                "oncomplete", "ScaleDownAni"
            )); ;
        }

        if (gameObject.CompareTag("RotEnemy") && GameManager10.lv10_deathCnt >= 4)
        {
            if (gameObject.CompareTag("RotEnemy"))
            {
                iTween.ScaleTo(gameObject, iTween.Hash(
                    "scale", new Vector3(0.5f, 0.5f, 0.5f),
                    "time", 0.1f

                )); ;
            }
        }

    }

    void ScaleDownAni()
    {
        

        if (gameObject.CompareTag("RotEnemy"))
        {
            iTween.ScaleTo(gameObject, iTween.Hash(
                "scale", new Vector3(1f, 1f, 1f),
                "time", 0.1f

            )); ;
        }
    }
}
