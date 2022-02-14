using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Af Tobias

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;

    public void PlayButton()
    {
        // Start spillet når der bliver trykket på Play knappen
        SceneManager.LoadScene("Floor 1");
    }

    public void QuitButton()
    {
        // Quit game
        Application.Quit();
    }
}
