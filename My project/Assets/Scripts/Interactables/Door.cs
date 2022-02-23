using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using Misc.Events;
using UnityEngine.Events;

// af rasmus
// styring af door

public class Door : MonoBehaviour, IInteractable, ISoundOrigin
{
    public event MakeSound makeSound;

    [Tooltip("True er med uret, False er mod uret")]
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

    [SerializeField]
    UnityEvent onLockedDoor;

    [SerializeField]
    bool locked = false;

    int eventToTriger = 0;
    bool pinged = false;

    float higestPing = 0, doorDesierdState;

    public Vector2 position { get { return (Vector2)transform.position; } }

    public Vector2 SoundPos
    { get { return (Vector2)transform.position; }}

    [SerializeField]
    GameObject desParticle;

    private void Start()
    {
        doorDesierdState = doorOpenState;
        animator.SetFloat("Blend", doorOpenState);
    }

    //når spillern Interact med døren
    public void Interact()
    {
        //gør ikke noget hvis døren er låst
        if (locked)
        {
            onLockedDoor?.Invoke();
            return;
        }

        // får døren til at åbne
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
        //hvis døren blev pinget
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

        //Åbner eller lukker døren
        if (doorDesierdState < doorOpenState)
        {
            doorOpenState -= Time.deltaTime * doorSpeed;
            if (doorOpenState < doorDesierdState) {
                doorOpenState = doorDesierdState;
                eventToTriger = 1;
                makeSound?.Invoke(soundDistance);
            }
            //bruger animation Blend til at styre dens position
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
            //bruger animation Blend til at styre dens position
            animator.SetFloat("Blend", doorOpenState);
        }
    }

    public void Unlock()
    {
        locked = false;
    }

    //til ødelægning af dør
    public void Destroy(Vector2 destroierPos)
    {
        Instantiate(desParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
