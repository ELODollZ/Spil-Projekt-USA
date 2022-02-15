using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Af Tobias
public class Loader1 : MonoBehaviour
{
    // Det her script er sat på en trigger i floor 1, hvor når man går ind i den, kører den det her script 

    void OnTriggerEnter2D(Collider2D collision)
    {
        // skifter til scene 2 som er sat til at være floor 2 når man går ind i triggeren
        SceneManager.LoadScene(2);   
    }
}
