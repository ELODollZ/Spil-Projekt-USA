using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//af Rasmus

namespace Misc.Events
{
    [System.Serializable]
    public class UnityBoolEvent : UnityEvent<bool>{ }
    [System.Serializable]
    public class UnityIntEvent : UnityEvent<int> { }
    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string> { }
    [System.Serializable]
    public class UnityFloatEvent : UnityEvent<float> { }
    [System.Serializable]
    public class UnityStringArrayEvent : UnityEvent<string[]> {}
}