using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using UnityEngine.Events;
using Misc.Events;

//af Rasmus
// skriptet stå for at lave lyd rays fra spilleren

public class PlayerNewSoundTest : MonoBehaviour, ISoundOrigin
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

    [SerializeField]
    float playerSound = 1;

    bool madeSound;

    private void Update()
    {
        if (madeSound)
        {
            //Event at spilleren blev pinget, bliver kaldt med det samme og med den samme styrke fordi spilleren altid høre sine fodspor på et en vis styrke
            pingEvent?.Invoke(playerSound);
            madeSound = false;
        }
    }

    //når denne funktion bliver klade sender spilleren lyd rays
    public void MakeSound()
    {
        makeSound?.Invoke(soundDis);
        madeSound = true;
    }


    public void Ping(float power){    }
}
