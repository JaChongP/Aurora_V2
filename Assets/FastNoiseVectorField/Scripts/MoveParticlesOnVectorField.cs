using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticlesOnVectorField : MonoBehaviour
{
    public float ParticleVelocity;
    
    [SerializeField] private VectorFieldGizmo vectorField = null;
    private ParticleSystem myParticleSystem = null;
    
 
    private void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }
    
    private void Update()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[myParticleSystem.particleCount];
        int totalParticles = myParticleSystem.GetParticles(particles);

        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i].velocity = vectorField.SampleDirectionFromPosition(particles[i].position) * ParticleVelocity;
            particles[i].position = new Vector3(particles[i].position.x, particles[i].position.y, 0.0f);
        }
        
        myParticleSystem.SetParticles(particles);
    }
}
