using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Af Rasmus

public class SimpleMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    ParticleSystem m_ParticleSystem;

    Rigidbody2D rb2d;

    [SerializeField]
    float disBetweenStep;

    float disToNextStep;

    Vector2 lastPos;

    void Start()
    {
        disToNextStep = disBetweenStep;
        rb2d = GetComponent<Rigidbody2D>();
    }


    
    void Update()
    {
        Vector2 move = new Vector2(); ;

        if (Input.GetKey(KeyCode.W))
        {
            move.y += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.y -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += speed;
        }

        disToNextStep -= Vector2.Distance(lastPos, (Vector2)transform.position);
        lastPos = transform.position;

        rb2d.velocity = move;

        if (disToNextStep <= 0)
        {
            disToNextStep = disBetweenStep;
            //m_ParticleSystem.Play();
        }

    }
}
