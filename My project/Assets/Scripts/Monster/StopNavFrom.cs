using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//af Rasmus

public class StopNavFrom : MonoBehaviour
{
    //Stopper Nav mesh for at rotere gameobjecttet automatisk fordi det ville rotete gameobjektet til at bruge z / x aksen til nav mesh
    void Awake()
    {
        NavMeshAgent agent = GetComponentInParent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.enabled = false;
    }

}
