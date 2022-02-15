using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioWhenPing : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(float power)
    {
        audioSource.volume = power;
        audioSource.Play();
    }
}
