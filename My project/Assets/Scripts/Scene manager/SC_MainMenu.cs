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
        // Starter spillet og sætter spilleren på Floor 1 når man trykker på Play knappen
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        // Slutter spillet når man trykker på Quit knappen 
        Application.Quit();
    }
}
