using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//af Rasmus
// n�r man bruger unity events der s�nder varriabler med skal der laves en klasse til dem s� de kan Serialiseres, hvilket g�r det muligt at se dem i editoren

namespace Misc.Events
{
    [System.Serializable]
    public class FloatEvent : UnityEvent<float>{}
    
}