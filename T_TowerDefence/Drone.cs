using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    //Tower
    GameObject tower;
    //NavMeshAgent
    NavMeshAgent nma;
    void Start()
    {
        tower = GameObject.Find("Tower");

        nma = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //  Tower를 향해 간다.
        nma.SetDestination(tower.transform.position);
    }
}
