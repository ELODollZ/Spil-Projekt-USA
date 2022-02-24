using System.Collections;
using System.Collections.Generic;
using SoundWaveSystem;
using UnityEngine;
using UnityEngine.AI;

// Af Tobias
// F� Monster til at g� efter spilleren hvis man laver lyd inden for dens range

// �ndringer af rasmus
// Skiftede scriptet v�k fra monobehavier til AIState s� det kunne inkoboreres i Moster State systemet
// �ndrede s� monsteret bruger en riget body til bev�gelse for ikke at kunne g� igennem v�ge

public class MonsterChase : AIState
{

    //public Transform Player;
   
    // G�r s� man kan s�tte speed inde i Inspectoren
    [SerializeField] 
    public float Speed;
    // G�r s� man kan s�tte en Max distance mellem spilleren og monsteret inde i inspectoren
    [SerializeField]
    private float maxDis;
    
    private float range;


    #region Rasmus Tilf�jede af variabler
    [SerializeField] float intrestTime = 3;

    [SerializeField] Transform monster;

    [SerializeField] Rigidbody2D rb2d;

    float timeToStopIntrest;

    [SerializeField] AIState stateafterLoseIntrest;

    //afstater den tideliger Player transmorm variabel og er punktet som monstert f�lger efter
    [SerializeField] Vector2 chasePoint;

    NavMeshAgent agent;
    #endregion

    private void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }

    public override AIState HandleSoundHit(ISoundOrigin origin, Vector2 soundPoint, float disLeft)
    {
        chasePoint = soundPoint;
        agent.enabled = true;
       timeToStopIntrest = intrestTime;
        agent.SetDestination(chasePoint);
        return this;
    }

    
    public override AIState UpdateState(float deltaTime)
    {
        #region afstatet med navmesh
        //Tobiases del fra update funktion
        /* sets the range between the monster and the player
        range = Vector2.Distance(monster.transform.position, chasePoint);

        // Siger at hvis spilleren er inden for max distance mellem spiller og monster
        if (range < maxDis)
        {
            // S� begynder monsteret at bev�ger sig mod spilleren
            rb2d.velocity = (chasePoint-(Vector2)monster.transform.position).normalized * Speed;
        } */
        #endregion

        //hvis der er g�et l�nge siden nogen lyd skete skift 
        timeToStopIntrest -= deltaTime;
        if (timeToStopIntrest < 0)
        {
            return stateafterLoseIntrest;
        }

        return this;
    }
}
