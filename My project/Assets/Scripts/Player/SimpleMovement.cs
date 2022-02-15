using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Af Rasmus
// Movement af spiller

public class SimpleMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D rb2d;

    void Start()
    {
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

        rb2d.velocity = move;

    }
}
