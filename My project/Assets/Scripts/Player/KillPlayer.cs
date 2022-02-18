using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("The Player has entered Death!");
            Destroy(player);
        }

    }
}
