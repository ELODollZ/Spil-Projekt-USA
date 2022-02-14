using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Af Rasmus

public class PlayerPingVisual : MonoBehaviour
{
    [SerializeField]
    ParticleSystem m_ParticleSystem;

    public void Pinged ()
    {
        m_ParticleSystem.Play();
    }

}
