using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Af Tobias
public class Loader1_Reverse : MonoBehaviour
{
    // Det her script er sat p� en trigger i floor 2, hvor n�r man g�r ind i den, k�rer den det her script 

    void OnTriggerEnter2D(Collider2D collision)
    {
        // skifter til scene 1 som er sat til at v�re floor 1 n�r man g�r ind i triggeren
        SceneManager.LoadScene(1);
    }
}
