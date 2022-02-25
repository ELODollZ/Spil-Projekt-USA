using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Af Rasmus
// Movement af spiller

public class SimpleMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float sneakSpeed;

    [SerializeField]
    PlayerSoundAfterStep stepPlaye, sneeakstep;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float aSpeed = speed;

        //hvis sneek
        if (Input.GetKey(KeyCode.LeftShift))
        {
            aSpeed = sneakSpeed;
            stepPlaye.enabled= false;
            sneeakstep.enabled = true;
        }
        else
        {
            stepPlaye.enabled = true;
            sneeakstep.enabled = false;
        }



        Vector2 move = new Vector2(); ;

        if (Input.GetKey(KeyCode.W))
        {
            move.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += 1;
        }

        rb2d.velocity = move.normalized * aSpeed;

    }
}
