using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Misc;

public class PingedTimedDisapering : MonoBehaviour, IPoolerble
{
    [SerializeField]
    float pingTime = 6;

    Timer timer;

    public GameObject PoolInstantiate(Vector2 pos, Vector3 rot)
    {
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot);
        timer = new Timer(pingTime);
        timer.timerDone += TimerDone;
        gameObject.SetActive(true);
        return gameObject;
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);
    }

    private void TimerDone()
    {
        gameObject.SetActive(false);
    }
}
