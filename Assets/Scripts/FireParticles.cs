using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticles : MonoBehaviour
{
    public static FireParticles particlesManager;

    [HideInInspector]
    public ParticleSystem particles;

    private void Awake()
    {
        particlesManager = this;
        particles = GetComponent<ParticleSystem>();
    }
}
