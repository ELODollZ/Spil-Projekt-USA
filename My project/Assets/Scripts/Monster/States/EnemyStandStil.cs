using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;


// AI state står stille
public class EnemyStandStil : AIState
{
    [SerializeField] float heringMin = 1f;

    [SerializeField] AIState stateWhenHearSound;

    public override AIState HandleSoundHit(ISoundOrigin origin, Vector2 soundPoint, float disLeft)
    {
        if (disLeft > heringMin)
        {
            stateWhenHearSound.HandleSoundHit(origin, soundPoint, disLeft);
            return stateWhenHearSound;
        }

        return this;
    }

    public override AIState UpdateState(float deltaTime)
    {
        return this;
    }
}
