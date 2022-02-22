using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// af rasmus
// en kanp der sender en event

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField]
    UnityEvent Pressed;

    public Vector2 position { get{ return transform.position; } }

    public void Interact()
    {
        Pressed?.Invoke();
    }
}
