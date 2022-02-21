using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// af Daniel Nybo (ødelægge dør når enemy rammer den.
public class DestroyingDoors : MonoBehaviour
{
    [SerializeField]
    public GameObject door;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
