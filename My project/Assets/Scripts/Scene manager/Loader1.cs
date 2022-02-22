using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Af Tobias
// Scene management script
public class Loader1 : MonoBehaviour
{
    // Det her script er sat p� en trigger i floor 1, hvor n�r man g�r ind i den, k�rer den det her script 

    [SerializeField] int sceneToLoad;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // skifter til scene 2 som er sat til at v�re floor 2 n�r man g�r ind i triggeren
        SceneManager.LoadScene(sceneToLoad);   
    }
}
