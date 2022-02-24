using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetGameScript : MonoBehaviour
{
    [SerializeField]
    public GameObject ResetGame;

    public void ResetButton()
    {
        SceneManager.LoadScene(0);
    }
}
