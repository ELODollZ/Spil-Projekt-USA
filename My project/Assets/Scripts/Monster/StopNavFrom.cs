using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopNavFrom : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        NavMeshAgent agent = GetComponentInParent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.enabled = false;
    }

}
