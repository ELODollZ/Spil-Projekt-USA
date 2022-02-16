using System.Collections;
using System.Collections.Generic;
using SoundWaveSystem;
using UnityEngine;

//Af Tobias

// ændringer af rasmus
// Skiftede scriptet væk fra monobehavier til AIState så det kunne inkoboreres i Moster State systemet

public class MonsterChase : AIState
{

    //public Transform Player;
   
    // Gør så man kan sætte speed inde i Inspectoren
    [SerializeField] 
    public float Speed;
    // Gør så man kan sætte en Max distance mellem spilleren og monsteret inde i inspectoren
    [SerializeField]
    private float maxDis;
    
    private float range;


    #region Rasmus Tilføjede af variabler
    [SerializeField] float intrestTime = 3;

    float timeToStopIntrest;

    [SerializeField] AIState stateafterLoseIntrest;

    //afstater den tideliger Player transmorm variabel
    Vector2 chasePoint;
    #endregion

    // Gør så man kan vælge de particles som vi vil bruge på monsteret
    [SerializeField] ParticleSystem m_ParticleSystem;

    public override AIState HandleSoundHit(ISoundOrigin origin, IHitObj[] hits, float disLeft)
    {
        //finder starts positionen af den lyd reflektion eller lydkilde som mosteret hørte
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
            // Så begynder monsteret at bevæger sig mod spilleren
            transform.position = Vector2.MoveTowards(transform.position, chasePoint, Speed * Time.deltaTime);
        }
        #endregion
        //hvis der er gået længe siden nogen lyd skete skift 
        timeToStopIntrest -= deltaTime;
        if (timeToStopIntrest < 0)
        {
            return stateafterLoseIntrest;
        }

        return this;
    }
}
