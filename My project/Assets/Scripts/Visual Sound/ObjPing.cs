using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using UnityEngine.Events;

//af rasmus
// et genbrugeligt sound hit script, der bruger unity events til at gøre det muligt at sætte events op i editoren

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

    //den funktíon er her kun for Interfacen
    public void EndOfRay(){    }


    private void Update()
    {
        //forde et obj højst sansyneligt bliver ramt af mere end en ray så sender den først at den er blevet ramt på den næste update
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
