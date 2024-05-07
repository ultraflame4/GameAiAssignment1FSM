using FSM;

public class CosbotState : FSM.State
{
    public Cosbot Bot {get; private set;}
    public CosbotState(FiniteStateMachine fsm, Cosbot bot) : base(fsm)
    {
        Bot=bot;
    }
}