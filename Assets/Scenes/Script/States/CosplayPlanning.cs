using UnityEngine;
using FSM;
using System.Collections;

public class CosplayPlanning : CosbotState
{

    public CosplayPlanning(Cosbot bot) : base(bot)
    {
        // Name = "CosplayPlanning";
    }
    protected override void OnEnter()
    {
        // Debug.Log("Entered CosplayPlanning state! The bot is now carefully reviewing materials and planning its cosplay!");
    }

    protected override IEnumerator OnStart()
    {
        Debug.Log("COSPLAY_PLANNING: Planning for cosplay...");
        yield return new WaitForSeconds(1);
        if (Bot.isSponsored)
        {
            fsm.Transition(Bot.State_SponsoredPanel);
        }
        else if (Bot.isCollabing){
            fsm.Transition(Bot.State_Photoshoot);
        }
        else{
            fsm.Transition(Bot.State_Wander);
        }

    }

    protected override void OnExit()
    {
        // Debug.Log("Exit CosplayPlanning state! The bot has finished planning!");
    }
}