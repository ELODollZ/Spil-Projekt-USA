using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//Af Daniel Nybo

    // edits af rasmus

public class KillPlayer : MonoBehaviour
{
    //kalder variabler som endelige ikke bliver brugte, det var ment til hvis vi også skulle fjerne rigidbody2D og scripts for at undgå errors når spilleren døde
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
        //kalder rigidbodyen så jeg kunne have brugte den senere.
        GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //laver en function der tjekker hvad object rammes af, og så om objectet har tag Enemy og hvis den har køre den if statement.
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //debug er for at se at spilleren er død.
            Debug.Log("The Player has entered Death!");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //- Rasmus -
            StartCoroutine(PlayerDead());
        }
        // -Rasmus- tilføjede så spilleren laver lyd når går ind i en væg
        else
        {
            playBonk?.Invoke();
        }
    }

    //- Rasmus -
    //Venter et sekundt før scene skift
    IEnumerator PlayerDead()
    {
        deathOverlay.StartFadeOfColor(1);

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
