using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Af Tobias

public class MonsterChase : MonoBehaviour
{

    public Transform Player;
   
    // G�r s� man kan s�tte speed inde i Inspectoren
    [SerializeField] 
    public float Speed;
    // G�r s� man kan s�tte en Max distance mellem spilleren og monsteret inde i inspectoren
    [SerializeField]
    private float maxDis;
    
    private float range;

    // S�tter distance mellem skridt som monsteret tager. Det skal bruges til particles p� monsteret
    [SerializeField]
    float disBetweenStep;
    
    float disToNextStep;

    Vector2 lastPos;
    
    // G�r s� man kan v�lge de particles som vi vil bruge p� monsteret
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
            // S� begynder monsteret at bev�ger sig mod spilleren
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
