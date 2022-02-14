using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//af Rasmus

namespace Misc.Events
{
    [System.Serializable]
    public class AudioEvent : UnityEvent<AudioClip, float>{ }

}