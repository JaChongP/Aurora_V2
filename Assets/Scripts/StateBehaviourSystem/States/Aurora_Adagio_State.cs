using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aurora_Adagio_State : AStateBehaviour
{
    private ParticleSystem ps;

    [Header("Particles Behavior")]
    [SerializeField] private float ParticleVelocity;
    [SerializeField] private MoveParticlesOnVectorField movement;


    public override bool InitializeState()
    {
        ps = GetComponent<ParticleSystem>();

        return true;
    }

    public override void OnStateStart()
    {
    }

    public override void OnStateUpdate()
    {
        movement.GetComponent<MoveParticlesOnVectorField>().ParticleVelocity = ParticleVelocity;
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
