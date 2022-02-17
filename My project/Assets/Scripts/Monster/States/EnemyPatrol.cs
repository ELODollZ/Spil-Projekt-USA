using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;

public class EnemyPatrol : AIState
{
    public override AIState HandleSoundHit(ISoundOrigin origin, Vector2 hits, float disLeft)
    {
        return this;
    }

    public override AIState UpdateState(float deltaTime)
    {
        return this;
    }
}
