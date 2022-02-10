using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by: Daniel Mønster Nybo
public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.D))
        {
            transform.position = Vector2.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = Vector2.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector2.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = Vector2.down * moveSpeed * Time.deltaTime;
        }
    }
}
