using System.Collections;
using FSM;
using UnityEngine;

public class SponsoredPanel : CosbotState
{

    public SponsoredPanel(Cosbot bot)  : base(bot) 
    {
        Name = "SponsoredPanel";
    }


    protected override void OnEnter()
    {
        Debug.Log("Entered SponsoredPanel state! The bot is now at a meet and greet panel in the convention centre, sponsored by the sponsor");
        
    }

    protected override IEnumerator OnStart()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Doing sponsor stuff...");
        fsm.Transition(Bot.State_Wander);

    }

    protected override void OnExit()
    {
        Debug.Log("Exit SponsoredPanel state! The panel session has ended!");
    }
}