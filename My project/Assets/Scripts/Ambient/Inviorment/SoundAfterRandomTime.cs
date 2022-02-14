using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using Misc;

//af Rasmus

public class SoundAfterRandomTime : MonoBehaviour, ISoundOrigin
{
    [SerializeField]
    float timeMin = 2.6f, timeMax = 4;

    [SerializeField]
    ParticleSystem m_ParticleSystem;

    Timer timer;

    bool pinged;

    public event MakeSound makeSound;

    public GameObject getOriginObj()
    {
        return gameObject;
    }

    public void Ping()
    {
        pinged = true;
    }


    // Start is called before the first frame update
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
            m_ParticleSystem.Play();
            pinged = false;
        }
    }

    private void TimerEnd()
    {
        makeSound?.Invoke();
        timer.Restart(Random.Range(timeMin, timeMax));
    }
}
