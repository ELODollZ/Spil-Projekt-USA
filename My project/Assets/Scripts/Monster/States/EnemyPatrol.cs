using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;

public class EnemyPatrol : AIState
{
    [SerializeField] Transform monster;

    [SerializeField] Transform[] folowPoints;

    [SerializeField] float speed = 2;

    [SerializeField] bool loop = true;

    [SerializeField] float heringMin = 1f;

    [SerializeField] AIState stateWhenHearSound;

    private int nextTaget = 0;

    private bool revers = false;

    private bool inPlay = false;


    public override AIState HandleSoundHit(ISoundOrigin origin, Vector2 soundPoint, float disLeft)
    {
        // hvis mosteret høre en lyd høj nok skifter den stadie
        if (disLeft > heringMin)
        {
            stateWhenHearSound.HandleSoundHit(origin, soundPoint, disLeft);
            return stateWhenHearSound;
        }

        return this;
    }

    public override AIState UpdateState(float deltaTime)
    {
        if (Vector2.Distance(monster.position, folowPoints[nextTaget].position) < speed * Time.deltaTime)
        {
            monster.position = folowPoints[nextTaget].position;
            if (loop)
            {
                nextTaget++;
                if (nextTaget == folowPoints.Length)
                {
                    nextTaget = 0;
                }
            }
            else
            {
                if (revers)
                {
                    nextTaget--;
                    if (nextTaget == 0)
                    {
                        revers = false;
                    }
                }
                else
                {
                    nextTaget++;
                    if (nextTaget == folowPoints.Length - 1)
                    {
                        revers = true;
                    }
                }
            }
        }
        else
        {
            Vector2 velocity = ((Vector2)folowPoints[nextTaget].position - (Vector2)monster.position).normalized * speed;
            monster.position += (Vector3)velocity * Time.deltaTime;
        }

        return this;
    }
}
