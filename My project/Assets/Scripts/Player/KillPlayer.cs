using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Af Daniel Nybo
public class KillPlayer : MonoBehaviour
{
    //kalder variabler som endelige ikke bliver brugte, det var ment til hvis vi ogs� skulle fjerne rigidbody2D og scripts for at undg� errors n�r spilleren d�de
    GameObject player;
    GameObject enemy;
    Rigidbody2D rb2d;
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
        if (other.gameObject.CompareTag("enemy"))
        {
            //debug er for at se at spilleren er d�d.
            Debug.Log("The Player has entered Death!");
            Destroy(player);
        }

    }
}
