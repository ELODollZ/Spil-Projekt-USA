using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using Misc.Events;

//Made By Editor: Daniel M�nster Nybo (Rock scripts)

// ændringer af Rasmus
// Ændringer : gjorde så stenen bruger lydsystemet 
// sten aktivere kanpper nåt de rammer

public class Rock : MonoBehaviour, ISoundOrigin
{
    //lave variable for hhv. levetiden af rock for at den ikke overloader ens computer, hastigheden af rock, og rigidbody
    private Rigidbody2D rb2d;
    [SerializeField]
    float lifetime = 10f;
    public GameObject rockPrefab;

    [SerializeField] FloatEvent PingEvent;

    [SerializeField] float soundDis = 20;

    public Vector2 SoundPos { get { return transform.position; } }

    public event MakeSound makeSound;

    bool pinged = false;
    float power = 0;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (pinged)
        {
            PingEvent?.Invoke(power);
            pinged = false;
            power = -1;
        }

        //laver en livestid på gameobjects den skyder og ødelægger dem efter tiden er gået.
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0f)
            {
                makeSound?.Invoke(soundDis * 0.5f);
                Destroy(gameObject, 1f);
                rb2d.velocity = Vector2.zero;
                respawnRockEfterhit();
            }
        }
    }

    //laver en funktioner der invoker particlesystem når den rammer noget.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;

        //- Rasmus -
        //sten aktivere knap
        if (collision.gameObject.CompareTag("Button"))
        {
            collision.gameObject.GetComponent<Button>().Interact();            
        }
        // lyd
        makeSound?.Invoke(soundDis);
    }

    public void Ping(float power)
    {
        pinged = true;
        if (this.power < power)
        {
            this.power = power;
        }
    }

    //funktionen kalder et prefab  som er sat ind i unity editoren og sætter position som er den samme som sten døde på.
    public void respawnRockEfterhit()
    {
        Instantiate(rockPrefab, transform.position, Quaternion.identity);
      
    }
}
