using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using Misc;
using UnityEngine.Events;

//af Rasmus

public class SoundAfterRandomTime : MonoBehaviour, ISoundOrigin
{
    [SerializeField]
    float timeMin = 2.6f, timeMax = 4;

    [SerializeField]
    UnityEvent originPinged;

    Timer timer;
    bool pinged;

    public event MakeSound makeSound;


    public void Ping()
    {
        pinged = true;
    }

    void Start()
    {
        timer = new Timer(Random.Range(timeMin, timeMax));
        timer.timerDone += TimerEnd;
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);

        if (pinged)
        {
            originPinged?.Invoke();
            pinged = false;
        }
    }


    private void TimerEnd()
    {
        makeSound?.Invoke();
        timer.Restart(Random.Range(timeMin, timeMax));
    }
}
