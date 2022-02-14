using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Af Tobias

public class SC_MainMenu : MonoBehaviour
{

    public GameObject MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayButton()
    {
        // Start spillet når der bliver trykket på Play knappen
        UnityEngine.SceneManagement.SceneManager.LoadScene("Floor 1");
    }

    public void QuitButton()
    {
        // Quit game
        Application.Quit();
    }
}
