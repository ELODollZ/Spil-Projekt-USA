using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingDoors : MonoBehaviour
{
    [SerializeField]
    public GameObject Doors;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Door"))
        {
            Destroy(Doors);

        }
    }
}
