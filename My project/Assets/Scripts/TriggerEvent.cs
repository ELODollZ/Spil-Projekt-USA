using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    UnityEvent Event;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Event?.Invoke();
    }
}
