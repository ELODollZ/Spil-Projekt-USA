using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Misc;

//af Rasmus

public class TestPartikalOnTimer : MonoBehaviour
{
    [SerializeField]
    float time = 5;

    [SerializeField]
    ParticleSystem particleSystem;

    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(time);
        timer.timerDone += particleSystem.Play;
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);
    }

}
