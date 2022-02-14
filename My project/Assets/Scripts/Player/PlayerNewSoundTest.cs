using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using UnityEngine.Events;

//af Rasmus
// skriptet stå for at lave lyd fra spilleren

public class PlayerNewSoundTest : MonoBehaviour, ISoundOrigin
{
    public event MakeSound makeSound;

    [Header("Sound Stuff")]
    [SerializeField]
    float soundDis = 20;
    [SerializeField]
    AudioClip audioClip;

    [Header("Event")]
    [SerializeField]
    UnityEvent pingEvent;


    public void MakeSound()
    {
        makeSound?.Invoke(soundDis, audioClip);
    }

    public void Ping()
    {
        pingEvent?.Invoke();
    }
}
