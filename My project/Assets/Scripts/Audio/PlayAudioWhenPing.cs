using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//af rasmus
//spiller en lyd når funktionen PlayAudio bliver kaldet, er ment til at blive sat ind i en unity event

public class PlayAudioWhenPing : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip[] sounds = new AudioClip[1];

    [SerializeField]
    SoundPlayMode soundPlayMode = SoundPlayMode.none;

    int next = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //spiler en lyd med en vis lydstyrke
    public void PlayAudio(float power)
    {
        //hvilken lyd der skal spilles
        switch (soundPlayMode)
        {
            case SoundPlayMode.random:
                audioSource.clip = sounds[Random.Range(0, sounds.Length)];
                break;
            case SoundPlayMode.inOrder:
                audioSource.clip = sounds[next];
                next++;
                if (next == sounds.Length) next = 0;
                break;
            case SoundPlayMode.none:
                break;
            default:
                break;
        }

        audioSource.volume = power;
        audioSource.Play();
    }
}


public enum SoundPlayMode {random, inOrder,/* bySoundPower,*/ none}
