using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using UnityEngine.Events;

public class ObjPing : MonoBehaviour, IHitObj
{
    [SerializeField]
    float soundDampening = 1;

    [SerializeField]
    UnityEvent hitSoundEvent, playerPingEvent;

    public float Dampening { get { return soundDampening; } }

    bool pinged;
    bool hit;

    //når Obj bliver ramt sender den en event
    public void Hit(ISoundOrigin origin, IHitObj[] hits, Vector2 hitPoint, float disLeft, float maxDis)
    {
        hit = true;
    }

    //når objet bliver pinget sender event
    public void Ping()
    {
        pinged = true;
    }

    public void EndOfRay()
    {

    }


    private void Update()
    {
        if (pinged)
        {
            pinged = false;
            playerPingEvent?.Invoke();
        }
        if (hit)
        {
            hitSoundEvent?.Invoke();
            hit = false;
        }
    }
}
