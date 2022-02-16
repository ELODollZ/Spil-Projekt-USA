using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using UnityEngine.Events;
using Misc.Events;

//af Rasmus
// skriptet st� for at lave lyd rays fra spilleren

public class PlayerNewSoundTest : MonoBehaviour, ISoundOrigin
{
    public event MakeSound makeSound;

    [Header("Sound Stuff")]
    [SerializeField]
    float soundDis = 20;

    [Header("Event")]
    [SerializeField]
    FloatEvent pingEvent;

    //n�r denne funktion bliver klade sender spilleren lyd rays
    public void MakeSound()
    {
        makeSound?.Invoke(soundDis);
        //Event at spilleren blev pinget, bliver kaldt med det samme og med maks styrke fordi spilleren altid h�re sine fodspor p� fuld styrke
        pingEvent?.Invoke(1);
    }


    public void Ping(float power){    }
}
