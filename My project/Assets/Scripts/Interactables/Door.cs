using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using Misc.Events;

// af rasmus

public class Door : MonoBehaviour, IInteractable, ISoundOrigin
{
    public event MakeSound makeSound;

    [SerializeField]
    float soundDistance = 15;

    [SerializeField]
    private bool open = false;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float delayForSound = 0.3f;

    [SerializeField]
    FloatEvent onOriginPing;

    bool pinged = false;

    float higestPing = 0;

    private void Start()
    {
        animator.SetBool("Open", open);
    }

    public void Interact()
    {
        open = !open;
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
    }
}
