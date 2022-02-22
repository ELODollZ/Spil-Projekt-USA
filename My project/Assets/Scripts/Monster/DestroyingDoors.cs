using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    // AF Rasmus

public class DestroyingDoors : MonoBehaviour
{
    [SerializeField]
    Door door;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            door.Destroy(transform.position);
        }
    }
}
