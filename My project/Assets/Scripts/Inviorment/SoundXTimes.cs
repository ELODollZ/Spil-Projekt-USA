using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Misc;

public class SoundXTimes : MonoBehaviour
{
    [SerializeField]
    float[] soundWhen = new float[] {1f};

    int nextWait = 0;

    [SerializeField]
    UnityEvent sound;

    Timer timer;

    bool loop = false;

    void Start()
    {
        timer = new Timer(soundWhen[0]);
        timer.timerDone += EndOFTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer.Tick(Time.deltaTime);
    }

    public void EndOFTimer()
    {
        sound?.Invoke();
        nextWait++;
        if (nextWait == soundWhen.Length)
        {
            if (loop)
            {
                ResetSound();
            }
            else
            {
                enabled = false;
            }
        }
         else
        {
            timer.Restart(soundWhen[nextWait]);
        }

    }

    public void ResetSound()
    {
        timer = new Timer(soundWhen[0]);
        nextWait = 0;
        enabled = true;
    }

}
