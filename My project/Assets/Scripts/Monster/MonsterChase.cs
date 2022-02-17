using System.Collections;
using System.Collections.Generic;
using SoundWaveSystem;
using UnityEngine;

//Af Tobias

// ændringer af rasmus
// Skiftede scriptet væk fra monobehavier til AIState så det kunne inkoboreres i Moster State systemet
// ændrede så monsteret bruger en riget body til bevægelse for ikke at kunne gå igennem væge

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

    [SerializeField] Transform monster;

    [SerializeField] Rigidbody2D rb2d;

    float timeToStopIntrest;

    [SerializeField] AIState stateafterLoseIntrest;

    //afstater den tideliger Player transmorm variabel og er punktet som monstert følger efter
    [SerializeField] Vector2 chasePoint;
    #endregion

    public override AIState HandleSoundHit(ISoundOrigin origin, Vector2 soundPoint, float disLeft)
    {
        chasePoint = soundPoint;

        timeToStopIntrest = intrestTime;

        return this;
    }

    
    public override AIState UpdateState(float deltaTime)
    {
        #region Tobiases del fra update funktion
        // sets the range between the monster and the player
        range = Vector2.Distance(monster.transform.position, chasePoint);

        // Siger at hvis spilleren er inden for max distance mellem spiller og monster
        if (range < maxDis)
        {
            // Så begynder monsteret at bevæger sig mod spilleren
            rb2d.velocity = (chasePoint-(Vector2)monster.transform.position).normalized * Speed;
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
