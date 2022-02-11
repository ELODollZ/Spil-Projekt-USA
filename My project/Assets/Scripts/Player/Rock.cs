using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made By Editor: Daniel M�nster Nybo (Rock scripts)
public class Rock : MonoBehaviour
{
    //lave variable for hhv. levetiden af rock for at den ikke overloader ens computer, hastigheden af rock, og rigidbody
    private float lifetime = 10000f;
    public float speedAfKastingRock = 10f;
    private Rigidbody2D rb2d;

    [SerializeField]
    ParticleSystem particleSystem;

    void Start()
    {
        //kalder i starten rigidbody fra unity og giver den velocity, og retter den mod højre og ganger noget speed på.
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speedAfKastingRock;
    }

    void Update()
    {


        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        particleSystem.Play();
    }

}
