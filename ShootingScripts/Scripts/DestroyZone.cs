using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Ãæµ¹ÇßÀ» ¶§ ºÎµúÈù³ð ´Ù ÆÄ±«
    private void OnTriggerEnter(Collider other)
    {
        // ºÎµúÈù ³ð ÆÄ±«
        Destroy(other.gameObject);
    }
}
