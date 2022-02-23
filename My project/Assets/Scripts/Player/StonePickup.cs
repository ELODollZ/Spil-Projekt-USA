using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// af Tobias
// N�r man g�r ind i en sten samler man den op
public class StonePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Hvis det er en ting med tagget "Player" s� bliver den samlet op
        if (collision.gameObject.CompareTag( "Player"))
        {
            // S�tter +1 p� rock counteren og s� destroerer objectet
            collision.gameObject. GetComponent<Throwing>().CurrentRock++;
            Destroy(gameObject);
        }
    }
}
