using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Af Tobias
// S�tter knapper p� Main menu

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;

    public void PlayButton()
    {
        // Starter spillet og s�tter spilleren p� Floor 1 n�r man trykker p� Play knappen
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        // Slutter spillet n�r man trykker p� Quit knappen 
        Application.Quit();
    }
}
