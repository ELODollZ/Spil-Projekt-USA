using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made By Editor: Daniel M�nster Nybo (shooting/throwing scripts)
public class Rock : MonoBehaviour
{
    public int speed = 50;
    public Vector3 targetVector;
    public float lifetime = 10f;

    [SerializeField]
    ParticleSystem particleSystem;

    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        rb.AddForce(targetVector.normalized * speed);
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
           particleSystem.Play();
        }
    }
}
