using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// af Tobias
// Når man går ind i en sten samler man den op

// ændring af Rasmus
// bruger funktion til at give sten i stedet for at endre variabel

public class StonePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Hvis det er en ting med tagget "Player" så bliver den samlet op
        if (collision.gameObject.CompareTag( "Player"))
        {
            // Sætter +1 på rock counteren og så destroerer objectet
            //collision.gameObject. GetComponent<Throwing>().CurrentRock++;
            collision.gameObject.GetComponent<Throwing>().AddStone();
            Destroy(gameObject);
        }
    }
}
