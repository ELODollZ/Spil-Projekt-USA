using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMoveToPoints : MonoBehaviour
{
    public Transform Goal;

    void start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = Goal.position;
    }
}
