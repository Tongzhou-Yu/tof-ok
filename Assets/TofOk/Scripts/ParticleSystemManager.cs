using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public float lifeTime;
    void Update()
    {
        if (this.TryGetComponent<ParticleSystem>(out var particlesystem))
        {
            if (particlesystem.time >= lifeTime)
                particlesystem.Pause();
        }
    }
}
