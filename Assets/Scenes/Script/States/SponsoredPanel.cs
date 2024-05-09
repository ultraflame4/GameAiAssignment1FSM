using FSM;
using UnityEngine;

public class SponsoredPanel : CosbotState
{
    float timeout_secs = 1;
    float timeout_counter = 0;

    public SponsoredPanel(FiniteStateMachine fsm, Cosbot bot) : base(fsm, bot)
    {
        Name = "SponsoredPanel";
    }


    protected override void OnEnter()
    {
        Debug.Log("Entered SponsoredPanel state! The bot is now at a meet and greet panel in the convention centre, sponsored by the sponsor");
        timeout_counter = 0;
    }

    protected override void OnExecute()
    {
        timeout_counter += Time.deltaTime;
        if (timeout_counter >= timeout_secs)
        {
            fsm.Transition(Bot.State_Wander);
        }
    }

    protected override void OnExit()
    {
        Debug.Log("Exit SponsoredPanel state! The panel session has ended!");
    }
}