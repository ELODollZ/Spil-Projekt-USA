using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;


//af Rasmus


public class PlayerNewSoundTest : MonoBehaviour, ISoundOrigin, IHitObj
{
    [SerializeField]
    float soundDampening = 0;

    public float Dampening { get { return soundDampening; } }

    public event MakeSound makeSound;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Color pingColor = Color.red;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            makeSound?.Invoke();
        }
    }


    public GameObject getOriginObj()
    {
        return gameObject;
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
        spriteRenderer.color = pingColor;
    }

    public void EndOfRay()
    {
        
    }
}
