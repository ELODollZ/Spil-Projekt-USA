using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Misc;
using UnityEngine.Experimental.Rendering.Universal;

//af Rasmus
    //Scriptet står for at vise et obj i lidt tid

public class PingedTimedDisapering : MonoBehaviour, IPoolerble
{
    [SerializeField]
    float pingTime = 6;
    Timer timer;

    [SerializeField]
    Light2D m_light;

    public event SimpleCall disabledEvent;

 
    public GameObject PoolInstantiate(Vector2 pos, Vector3 rot)
    {
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot);
        if (timer == null)
        {
            timer = new Timer(pingTime);
        }
        else
        {
            timer.Restart();
        }
        timer.timerDone += TimerDone;
        gameObject.SetActive(true);
        return gameObject;
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);
        m_light.intensity = timer.TimeLeft/timer.TimerLengh;
    }

    private void TimerDone()
    {
        disabledEvent?.Invoke(this);
        gameObject.SetActive(false);
    }

    public void RestartTimer()
    {
        timer.Restart();
    }
}

public delegate void SimpleCall(PingedTimedDisapering PoolObj);
