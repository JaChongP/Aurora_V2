using UnityEngine;

public class ConvertEventStringToStateMachine : MonoBehaviour
{
    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    public void OnComboFound(string comboName)
    {
        Debug.Log(comboName);
        
        if (comboName.CompareTo("Calm") == 0)
        {
            stateMachine.SetState( (int)EAuroraStates.Calm );
        }

        if (comboName.CompareTo("Chaotic") == 0)
        {
            stateMachine.SetState((int)EAuroraStates.Chaotic);
        }

        if (comboName.CompareTo("Steady") == 0)
        {
            stateMachine.SetState((int)EAuroraStates.Steady);
        }

        if (comboName.CompareTo("Magenta") == 0)
        {
            stateMachine.SetState((int)EAuroraStates.Magenta);
        }

        if (comboName.CompareTo("Cyan") == 0)
        {
            stateMachine.SetState((int)EAuroraStates.Cyan);
        }

        if (comboName.CompareTo("Chartreuse") == 0)
        {
            stateMachine.SetState((int)EAuroraStates.Chartreuse);
        }

        if (comboName.CompareTo("Adagio") == 0)
        {
            stateMachine.SetState((int)EAuroraStates.Adagio);
        }

        if (comboName.CompareTo("Allegro") == 0)
        {
            stateMachine.SetState((int)EAuroraStates.Allegro);
        }

        if (comboName.CompareTo("Presto") == 0)
        {
            stateMachine.SetState((int)EAuroraStates.Presto);
        }
    }
}
