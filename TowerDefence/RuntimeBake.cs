using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RuntimeBake : MonoBehaviour
{
    NavMeshSurface nms;

    void Start()
    {
        nms = GetComponent<NavMeshSurface>();
        nms.BuildNavMesh();
    }
}
