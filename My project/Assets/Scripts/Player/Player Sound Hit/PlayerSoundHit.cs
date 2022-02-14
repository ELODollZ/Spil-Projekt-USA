using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;

//af rasmus
// skriptet stå for at pinge alle de ting en ray ramte før den kom til spilleren

public class PlayerSoundHit : MonoBehaviour, IHitObj
{
    [SerializeField]
    float soundDampening = 0;

    public float Dampening { get { return soundDampening; } }

    public event MakeSound makeSound;


    public void MakeSound()
    {
        makeSound?.Invoke();
    }

    public void Hit(ISoundOrigin origin, IHitObj[] hits, Vector2 hitPoint, float disLeft)
    {
        origin.Ping();
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) return;
            hits[i].Ping();
        }
    }

    public void Ping()
    {
        
    }

    public void EndOfRay()
    {

    }
}
