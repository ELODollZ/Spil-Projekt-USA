using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using Misc.Events;

// af rasmus
// styring af dør

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
    float delayForSound = 0.2f, doorOpenState = 0.5f, doorSpeed = 1;

    [SerializeField]
    FloatEvent onOriginPing;

    bool pinged = false;

    float higestPing = 0, doorDesierdState;

    public Vector2 position { get { return (Vector2)transform.position; } }

    private void Start()
    {
        doorDesierdState = doorOpenState;
        animator.SetFloat("Blend", doorOpenState);
    }

    //når spillern Interact med døren
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

        StartCoroutine(PlaySoundLate(delayForSound));
    }

    public void Ping(float power)
    {
        pinged = true;
        if (higestPing < power)
        {
            higestPing = power;
        }
    }

    private IEnumerator PlaySoundLate(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("did sound");
        makeSound?.Invoke(soundDistance);
    }

    private void Update()
    {
        //hvis noget pingede 
        if (pinged)
        {
            onOriginPing?.Invoke(higestPing);
            higestPing = 0;
            pinged = false;
        }

        //Åbner eller lukker døren
        if (doorDesierdState < doorOpenState)
        {
            doorOpenState -= Time.deltaTime * doorSpeed;
            if (doorOpenState < doorDesierdState) doorOpenState = doorDesierdState;
            animator.SetFloat("Blend", doorOpenState);
        }
        else if (doorDesierdState > doorOpenState)
        {
            doorOpenState += Time.deltaTime * doorSpeed;
            if (doorOpenState > doorDesierdState) doorOpenState = doorDesierdState;
            animator.SetFloat("Blend", doorOpenState);
        }
    }
}
