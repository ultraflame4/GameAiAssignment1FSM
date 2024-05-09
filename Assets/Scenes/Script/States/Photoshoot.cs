using FSM;
using UnityEngine;

public class Photoshoot : CosbotState
{

    float timeout_secs = 1;
    float timeout_counter = 0;
    public Photoshoot(FiniteStateMachine fsm, Cosbot bot) : base(fsm, bot)
    {
        Name = "Photoshoot";
    }


    protected override void OnEnter()
    {
        Debug.Log("Entered Photoshoot state! The bot is now at a professional photoshoot nearby the convetion and taking pictures for brands promotions.");
        timeout_counter = 0;
    }

    protected override void OnExecute()
    {
        timeout_counter += Time.deltaTime;
        if (timeout_counter >= timeout_secs)
        {
            fsm.Transition(Bot.State_SponsoredPanel);
        }
    }

    protected override void OnExit()
    {
        Debug.Log("Exit Photoshoot state! The photoshoot session has ended!");
    }
}