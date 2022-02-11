using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//af Rasmus

namespace SoundWaveSystem
{
    //en interface for ting der kan blive ramt af lyd
    public interface IHitObj
    {
        void Hit(ISoundOrigin origin, IHitObj[] hits, Vector2 hitPoint, float disLeft);
        void Ping();
        GameObject getOriginObj();
        float Dampening { get; }
        void EndOfRay();
    }

    //interface for ting der kan sende lyd
    public interface ISoundOrigin
    {
        event MakeSound makeSound;
        void Ping();
        GameObject getOriginObj();
    }

    public delegate void MakeSound();
}
