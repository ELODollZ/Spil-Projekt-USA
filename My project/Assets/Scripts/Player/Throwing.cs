using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made By Editor: Daniel M�nster Nybo (shooting/throwing scripts)
public class Throwing : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public GameObject rockPrefab;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(rockPrefab, gameObject.transform);
            Rock rock = go.GetComponent<Rock>();
            rock.targetVector = new Vector3(1, 1, 0);
            Debug.Log("throwen");
        }

    }
}
