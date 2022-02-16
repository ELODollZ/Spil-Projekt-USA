using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//af Rasmus
// når man bruger unity events der sænder varriabler med skal der laves en klasse til dem så de kan Serialiseres, hvilket gør det muligt at se dem i editoren

namespace Misc.Events
{
    [System.Serializable]
    public class FloatEvent : UnityEvent<float>{}
    
}