using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    GameObject menu, inGame;


    bool pauseState = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseState)
            {
                Pause(false);
            }
            else
            {
                Pause(true);
            }
        }
    }


    public void Pause(bool pause)
    {
        menu.SetActive(pause);
        inGame.SetActive(!pause);
        pauseState = pause;
        if (pauseState)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}
