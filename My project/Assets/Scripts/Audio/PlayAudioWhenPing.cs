using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//af rasmus
//spiller en lyd når funktionen PlayAudio bliver kaldet, er ment til at blive sat ind i en unity event

public class PlayAudioWhenPing : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //spiler en lyd med en vis lydstyrke
    public void PlayAudio(float power)
    {
        audioSource.volume = power;
        audioSource.Play();
    }
}
