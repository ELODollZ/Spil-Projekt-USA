using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Af Tobias

public class MonsterChase : MonoBehaviour
{

    public Transform Player;
   
    [SerializeField] 
    public float Speed;
    [SerializeField]
    private float maxDis;
    
    private float range;

    [SerializeField]
    float disBetweenStep;
    
    float disToNextStep;

    Vector2 lastPos;

    [SerializeField] ParticleSystem m_ParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        disToNextStep = disBetweenStep;
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, Player.position);

        if (range < maxDis)
        {

            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }

        disToNextStep -= Vector2.Distance(lastPos, (Vector2)transform.position);
        lastPos = transform.position;

        if (disToNextStep <= 0)
        {
            disToNextStep = disBetweenStep;
            m_ParticleSystem.Play();
        }
    }
}
