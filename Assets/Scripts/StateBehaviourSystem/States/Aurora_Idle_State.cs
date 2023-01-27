using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aurora_Idle_State : AStateBehaviour
{
    private ParticleSystem ps;
    [Header("Vector Field")]
    [SerializeField] private VectorFieldGizmo vectorField = null;

    [Space(10)]

    [Header("Particles Behavior")]
    [SerializeField] private float ParticleVelocity;


    public override bool InitializeState()
    {
        ps = GetComponent<ParticleSystem>();

        return true;
    }

    public override void OnStateStart()
    {
        Debug.Log("Idle_State STARTED");
    }

    public override void OnStateUpdate()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
        int totalParticles = ps.GetParticles(particles);

        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i].velocity = vectorField.SampleDirectionFromPosition(particles[i].position) * ParticleVelocity;
            particles[i].position = new Vector3(particles[i].position.x, particles[i].position.y, 0.0f);
        }

        ps.SetParticles(particles);
    }

    public override void OnStateEnd()
    {
    }

    public override int StateTransitionCondition()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            return (int)EAuroraStates.Calm;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            return (int)EAuroraStates.Steady;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            return (int)EAuroraStates.Chaotic;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            return (int)EAuroraStates.Magenta;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            return (int)EAuroraStates.Cyan;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            return (int)EAuroraStates.Chartreuse;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            return (int)EAuroraStates.Adagio;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            return (int)EAuroraStates.Allegro;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            return (int)EAuroraStates.Presto;
        }
        return (int)EAuroraStates.Invalid;
    }
}
