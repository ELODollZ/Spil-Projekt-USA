using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag( "Player"))
        {
            collision.gameObject. GetComponent<Throwing>().CurrentRock++;
            Destroy(gameObject);
        }
    }
}
