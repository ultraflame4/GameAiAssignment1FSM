using FSM;

public class CosbotState : FSM.State
{
    public Cosbot Bot {get; private set;}
    public CosbotState(Cosbot bot) : base(bot)
    {
        Bot=bot;
    }
}