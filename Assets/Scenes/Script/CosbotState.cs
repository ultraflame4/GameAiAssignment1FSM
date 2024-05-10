/// <summary>
/// Same as FSM.State, but holds a reference to the Bot. So that states do not need to do typecasting.
/// Otherwise it is mostly a remnant of a previous FSM design structure I had previously.
/// </summary>
public class CosbotState : FSM.State
{
    public Cosbot Bot {get; private set;}
    public CosbotState(Cosbot bot) : base(bot)
    {
        Bot=bot;
    }
}