using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//af rasmus
// styre animation hved setning af værdier til animtoren

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    Vector2 privPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = (Vector2)transform.position-privPos;
        privPos = (Vector2)transform.position;

        int dir = 0;

        if (move.x < 0)
        {
            dir = 2;
        }
        if (move.x > 0)
        {
            dir = 3;
        }
        if (move.y < 0)
        {
            dir = 1;
        }
        if (move.y > 0)
        {
            dir = 4;
        }
        animator.SetInteger("Dirrection", dir);
    }
}
