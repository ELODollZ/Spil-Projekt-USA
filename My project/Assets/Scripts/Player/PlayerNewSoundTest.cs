using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using UnityEngine.Events;
using Misc.Events;

//af Rasmus
// skriptet stå for at lave lyd fra spilleren

public class PlayerNewSoundTest : MonoBehaviour, ISoundOrigin
{
    public event MakeSound makeSound;

    [Header("Sound Stuff")]
    [SerializeField]
    float soundDis = 20;

    [Header("Event")]
    [SerializeField]
    FloatEvent pingEvent;


    bool pinged = false;
    float higestPing = 0;


    public void MakeSound()
    {
        makeSound?.Invoke(soundDis);
        Ping(1);
    }

    public void Ping(float power)
    {
        pinged = true;
        if (higestPing < power)
        {
            higestPing = power;
        }
    }

    private void Update()
    {
        if (pinged)
        {
            pinged = false;
            pingEvent?.Invoke(higestPing);
            higestPing = 0;
        }
    }
}
