using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Af Tobias

public class MonsterChase : MonoBehaviour
{

    public Transform Player;
   
    // Gør så man kan sætte speed inde i Inspectoren
    [SerializeField] 
    public float Speed;
    // Gør så man kan sætte en Max distance mellem spilleren og monsteret inde i inspectoren
    [SerializeField]
    private float maxDis;
    
    private float range;

    // Sætter distance mellem skridt som monsteret tager. Det skal bruges til particles på monsteret
    [SerializeField]
    float disBetweenStep;
    
    float disToNextStep;

    Vector2 lastPos;
    
    // Gør så man kan vælge de particles som vi vil bruge på monsteret
    [SerializeField] ParticleSystem m_ParticleSystem;

   
    void Start()
    {
        disToNextStep = disBetweenStep;
    }

    void Update()
    {
        // sets the range between the monster and the player
        range = Vector2.Distance(transform.position, Player.position);

        // Siger at hvis spilleren er inden for max distance mellem spiller og monster
        if (range < maxDis)
        {
            // Så begynder monsteret at bevæger sig mod spilleren
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }

        // plays the sound waves every few steps
        disToNextStep -= Vector2.Distance(lastPos, (Vector2)transform.position);
        lastPos = transform.position;

        if (disToNextStep <= 0)
        {
            disToNextStep = disBetweenStep;
            m_ParticleSystem.Play();
        }
    }
}
