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
    ParticleSystem m_ParticleSystem;

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
        m_ParticleSystem.Play();
        timer.Restart(Random.Range(timeMin, timeMax));
    }
}
