using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // �浹���� �� �ε����� �� �ı�
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� �� �ı�
        Destroy(other.gameObject);
    }
}
