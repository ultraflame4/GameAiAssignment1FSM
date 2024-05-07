using UnityEngine;

public class Cosbot : MonoBehaviour
{
    private FSM.FiniteStateMachine fsm;

    private void Start()
    {
        fsm = new FSM.FiniteStateMachine();
    }
}