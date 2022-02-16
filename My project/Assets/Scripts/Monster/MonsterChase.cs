using System.Collections;
using System.Collections.Generic;
using SoundWaveSystem;
using UnityEngine;

//Af Tobias

// �ndringer af rasmus
// Skiftede scriptet v�k fra monobehavier til AIState s� det kunne inkoboreres i Moster State systemet

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

    float timeToStopIntrest;

    [SerializeField] AIState stateafterLoseIntrest;

    //afstater den tideliger Player transmorm variabel
    Vector2 chasePoint;
    #endregion

    // G�r s� man kan v�lge de particles som vi vil bruge p� monsteret
    [SerializeField] ParticleSystem m_ParticleSystem;

    public override AIState HandleSoundHit(ISoundOrigin origin, IHitObj[] hits, float disLeft)
    {
        //finder starts positionen af den lyd reflektion eller lydkilde som mosteret h�rte
        if (hits[0] == null) chasePoint = origin.SoundPos;
        else
        {
            for (int i = 2; i < hits.Length; i++)
            {
                if (hits[i] == null)
                {
                    chasePoint = hits[i - 1].HitPos;
                }
                else
                {
                    chasePoint = hits[i].HitPos;
                }
            }
        }

        timeToStopIntrest = intrestTime;

        return this;
    }

    
    public override AIState UpdateState(float deltaTime)
    {
        #region Tobiases del fra update funktion
        // sets the range between the monster and the player
        range = Vector2.Distance(transform.position, chasePoint);

        // Siger at hvis spilleren er inden for max distance mellem spiller og monster
        if (range < maxDis)
        {
            // S� begynder monsteret at bev�ger sig mod spilleren
            transform.position = Vector2.MoveTowards(transform.position, chasePoint, Speed * Time.deltaTime);
        }
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
