using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//Af Daniel Nybo

    // edits af rasmus

public class KillPlayer : MonoBehaviour
{
    //kalder variabler som endelige ikke bliver brugte, det var ment til hvis vi ogs� skulle fjerne rigidbody2D og scripts for at undg� errors n�r spilleren d�de
    public GameObject player;
    GameObject enemy;
    Rigidbody2D rb2d;

    #region - Rasmus -
    [SerializeField]
    UnityEvent playBonk;

    [SerializeField]
    DeathOverlay deathOverlay;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //kalder rigidbodyen s� jeg kunne have brugte den senere.
        GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //laver en function der tjekker hvad object rammes af, og s� om objectet har tag Enemy og hvis den har k�re den if statement.
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //debug er for at se at spilleren er d�d.
            Debug.Log("The Player has entered Death!");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //- Rasmus -
            StartCoroutine(PlayerDead());
        }
        // -Rasmus- tilf�jede s� spilleren laver lyd n�r g�r ind i en v�g
        else
        {
            playBonk?.Invoke();
        }
    }

    //- Rasmus -
    //Venter et sekundt f�r scene skift
    IEnumerator PlayerDead()
    {
        deathOverlay.StartFadeOfColor(1);

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
