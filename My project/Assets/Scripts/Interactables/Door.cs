using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using Misc.Events;

// af rasmus
// styring af door

public class Door : MonoBehaviour, IInteractable, ISoundOrigin
{
    public event MakeSound makeSound;

    [Tooltip("flalse er med uret, true er mod uret")]
    [SerializeField]
    //flalse er med uret, true er mod uret
    bool openDir = false;

    [SerializeField]
    float soundDistance = 15;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float doorOpenState = 0.5f, doorSpeed = 1;

    [SerializeField]
    FloatEvent onOriginPing1, onOriginPing2;


    int eventToTriger = 0;
    bool pinged = false;

    float higestPing = 0, doorDesierdState;

    public Vector2 position { get { return (Vector2)transform.position; } }

    private void Start()
    {
        doorDesierdState = doorOpenState;
        animator.SetFloat("Blend", doorOpenState);
    }

    //n�r spillern Interact med d�ren
    public void Interact()
    {
        if (doorDesierdState > 0.5f || doorDesierdState < 0.5f)
        {
            doorDesierdState = 0.5f;
        }else
        {
            if (openDir)
            {
                doorDesierdState = 1;
            }
            else
            {
                doorDesierdState = 0;
            }
        }
        eventToTriger = 0;
        makeSound?.Invoke(soundDistance);
    }

    public void Ping(float power)
    {
        pinged = true;
        if (higestPing < power)
        {
            higestPing = power;
        }
    }

    private void Update()
    {
        //hvis noget pingede 
        if (pinged)
        {
            if (eventToTriger == 0)
            {
                onOriginPing1?.Invoke(higestPing);
            }
            else
            {
                onOriginPing2?.Invoke(higestPing);
            }
            higestPing = 0;
            pinged = false;
        }

        //�bner eller lukker d�ren
        if (doorDesierdState < doorOpenState)
        {
            doorOpenState -= Time.deltaTime * doorSpeed;
            if (doorOpenState < doorDesierdState) {
                doorOpenState = doorDesierdState;
                eventToTriger = 1;
                makeSound?.Invoke(soundDistance);
            }
            animator.SetFloat("Blend", doorOpenState);
        }
        else if (doorDesierdState > doorOpenState)
        {
            doorOpenState += Time.deltaTime * doorSpeed;
            if (doorOpenState > doorDesierdState)
            {
                doorOpenState = doorDesierdState;
                eventToTriger = 1;
                makeSound?.Invoke(soundDistance);
            }
            animator.SetFloat("Blend", doorOpenState);
        }
    }
}
