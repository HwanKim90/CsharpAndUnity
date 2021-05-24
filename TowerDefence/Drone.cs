using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    GameObject tower;
    
    NavMeshAgent nma;
   
    void Start()
    {
        tower = GameObject.Find("Tower");
        nma = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        // Tower�� ���� ����.
        nma.SetDestination(tower.transform.position);
    }
}
