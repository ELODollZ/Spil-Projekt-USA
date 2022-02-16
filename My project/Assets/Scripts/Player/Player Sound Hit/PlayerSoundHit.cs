using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using Misc.Events;

//af rasmus
// skriptet st� for at pinge alle de ting en ray ramte f�r den kom til spilleren

public class PlayerSoundHit : MonoBehaviour, IHitObj
{
    [SerializeField]
    float soundDampening = 0;

    public float Dampening { get { return soundDampening; } }

    //n�r spilleren bliver ramt beder den alt andet der var ramt af den samme ray at blive pinget, der bliver ogs� affyret en event med lyd s� spille lyd kan g�re ting
    public void Hit(ISoundOrigin origin, IHitObj[] hits, Vector2 hitPoint, float disLeft, float maxDis)
    {
        origin.Ping(disLeft / maxDis);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) return;
            hits[i].Ping();
        }
    }

    public void Ping(){    }

    public void EndOfRay(){    }
}
