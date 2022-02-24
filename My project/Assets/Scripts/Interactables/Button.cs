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

    [SerializeField]
    bool onTimeUse = true;

    bool used = false;

    public Vector2 position { get{ return transform.position; } }

    public void Interact()
    {
        //hvis knappen kun tan trykkes en gang
        if (onTimeUse)
        {
            if (!used)
            {
                Pressed?.Invoke();
                used = true;
            }
        }
        else
        {
            Pressed?.Invoke();
        }
    }
}
