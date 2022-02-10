using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Misc;

// af Rasmus


public class WaterDrop : MonoBehaviour
{
    [SerializeField]
    float timeMin = 0.6f, timeMax = 1;

    [SerializeField]
    ParticleSystem particleSystem;

    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(Random.Range(timeMin, timeMax));
        timer.timerDone += TimerEnd;
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);
    }

    private void TimerEnd()
    {
        particleSystem.Play();
        timer.Restart(Random.Range(timeMin, timeMax));
    }
}
