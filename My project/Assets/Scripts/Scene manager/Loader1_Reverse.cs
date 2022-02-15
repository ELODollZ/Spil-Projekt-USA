using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Af Tobias
public class Loader1_Reverse : MonoBehaviour
{
    // Det her script er sat på en trigger i floor 2, hvor når man går ind i den, kører den det her script 

    void OnTriggerEnter2D(Collider2D collision)
    {
        // skifter til scene 1 som er sat til at være floor 1 når man går ind i triggeren
        SceneManager.LoadScene(1);
    }
}
