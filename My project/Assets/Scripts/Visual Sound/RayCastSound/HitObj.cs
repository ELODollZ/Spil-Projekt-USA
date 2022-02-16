using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//af Rasmus

namespace SoundWaveSystem
{
    //en interface for ting der kan blive ramt af lyd
    public interface IHitObj
    {
        void Hit(ISoundOrigin origin, IHitObj[] hits, Vector2 hitPoint, float disLeft, float fullDis);
        void Ping();
        Vector2 HitPos { get; }
        //GameObject getOriginObj();
        float Dampening { get; }
        void EndOfRay();
    }

    //interface for ting der kan sende lyd
    public interface ISoundOrigin
    {
        event MakeSound makeSound;
        Vector2 SoundPos { get; }
        void Ping(float power);
    }

    public delegate void MakeSound(float soundDis);
}
