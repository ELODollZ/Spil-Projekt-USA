using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using Misc;
using Misc.Events;

//af Rasmus
//bruger en timer til at lave lydblølger efter tilfældig tide mellem timeMin og timeMax

public class SoundAfterRandomTime : MonoBehaviour, ISoundOrigin
{
    [SerializeField]
    float timeMin = 2.6f, timeMax = 4;

    [SerializeField]
    FloatEvent originPinged;

    [Header("Sound Stuff")]
    [SerializeField]
    float soundDis = 20;


    Timer timer;

    bool pinged;
    float higestPing = 0;

    public event MakeSound makeSound;


    public void Ping(float power)
    {
        pinged = true;
        if (higestPing < power)
        {
            higestPing = power;
        }
    }

    void Start()
    {
        timer = new Timer(Random.Range(timeMin, timeMax));
        timer.timerDone += TimerEnd;
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);

        //hvis noget pingede 
        if (pinged)
        {
            originPinged?.Invoke(higestPing);
            higestPing = 0;
            pinged = false;
        }
    }


    private void TimerEnd()
    {
        makeSound?.Invoke(soundDis);
        timer.Restart(Random.Range(timeMin, timeMax));
    }
}
