using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// af Tobias
// N�r man g�r ind i en sten samler man den op

// �ndring af Rasmus
// bruger funktion til at give sten i stedet for at endre variabel

public class StonePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Hvis det er en ting med tagget "Player" s� bliver den samlet op
        if (collision.gameObject.CompareTag( "Player"))
        {
            // S�tter +1 p� rock counteren og s� destroerer objectet
            //collision.gameObject. GetComponent<Throwing>().CurrentRock++;
            collision.gameObject.GetComponent<Throwing>().AddStone();
            Destroy(gameObject);
        }
    }
}
