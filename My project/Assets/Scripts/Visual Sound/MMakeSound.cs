using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using UnityEngine.Events;
using Misc.Events;

//af Rasmus
// skriptet stå for at lave lyd rays fra spilleren

public class MMakeSound : MonoBehaviour, ISoundOrigin
{
    public Vector2 SoundPos
    { get { return (Vector2)transform.position; } }
    public event MakeSound makeSound;

    [Header("Sound Stuff")]
    [SerializeField]
    float soundDis = 20;

    [Header("Event")]
    [SerializeField]
    FloatEvent pingEvent;


    bool pinged;
    float higestPing = 0;

    private void Update()
    {
        if (pinged)
        {
            pinged = false;
            pingEvent?.Invoke(higestPing);
            higestPing = -1;
        }
    }

    //når denne funktion bliver klade sender spilleren lyd rays
    public void MakeSound()
    {
        makeSound?.Invoke(soundDis);
    }


    public void Ping(float power) {
        pinged = true;
        if (higestPing < power)
        {
            higestPing = power;
        }
    }
}
