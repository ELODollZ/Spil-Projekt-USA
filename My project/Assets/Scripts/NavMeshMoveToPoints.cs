using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMoveToPoints : MonoBehaviour
{
    public Transform Goal;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    public void UpdateDestination(Vector3 position)
    {
        agent.SetDestination(Goal.position);
    }
}
