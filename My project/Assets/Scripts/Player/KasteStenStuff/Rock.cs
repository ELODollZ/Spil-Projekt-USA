using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
//Made By Editor: Daniel M�nster Nybo (Rock scripts)
public class Rock : MonoBehaviour, ISoundOrigin
{
    //lave variable for hhv. levetiden af rock for at den ikke overloader ens computer, hastigheden af rock, og rigidbody
    private Rigidbody2D rb2d;
    [SerializeField]
    public float speedAfKastingRock = 10f;float lifetime = 10f;
    //gør så man kan sætte et particel system på i unity
    [SerializeField]
    ParticleSystem particleSystem;

    public event MakeSound makeSound;

    public void Update()
    {
        //laver en livestid på gameobjects den skyder og ødelægger dem efter tiden er gået.
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    //laver en funktioner der invoker particlesystem når den rammer noget.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //aktivere particlesystemet.
        makeSound?.Invoke(20);
    }

    public void Ping(float power)
    {
        particleSystem.Play();
    }
}
