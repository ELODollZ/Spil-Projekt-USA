using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Misc;
using UnityEngine.Experimental.Rendering.Universal;

//af Rasmus
//Scriptet st�r for at vise et obj i lidt tid, Det g�r den hved at bruge unitys 2d lys fra deres Universal Renderer.
// dise obj er prim�rt ment til brug med v�gene i spille da det var meget vigtigt at hele v�gen ikke lyste op p� en gang
//fordi der bruges mange af dem er de lavet s� de kan bruges i en obj pool

public class PingedTimedDisapering : MonoBehaviour, IPoolerble
{
    [SerializeField]
    float pingTime = 6;
    Timer timer;

    [SerializeField]
    Light2D m_light;

    public event SimpleCall disabledEvent;

    //den alternative start funktion til pool objekter der kaldes fra de stripts der skal bruge dem
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
        //fader lys
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
