using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made By Editor: Daniel M�nster Nybo (shooting/throwing scripts)
public class Throwing : MonoBehaviour
{
    public Transform KasteStartingsPladsForRock;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public GameObject rockPrefab;


    //skaber en der bliver kalder indholdet vært update i spillet.
    void Update()
    {
        //laver en funktion der trigger hver gang man trykker på "throwingRockButton1"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //kalder en anden funktion shoot.
            Shoot();
            Debug.Log("throwen");
        }
    }

    void Shoot()
    {
        //funktion der fremkalder et prefab og giver den bevægelse.
        Instantiate(rockPrefab, KasteStartingsPladsForRock.position, KasteStartingsPladsForRock.rotation);

    }
    /*
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(rockPrefab, gameObject.transform);
            Rock rock = go.GetComponent<Rock>();
            rock.targetVector = new Vector3(1, 1, 0);
        }
    }
    */

}
