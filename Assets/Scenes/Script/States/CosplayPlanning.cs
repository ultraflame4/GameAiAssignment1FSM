using UnityEngine;
using FSM;
using System.Collections;

public class CosplayPlanning : CosbotState
{

    public CosplayPlanning(Cosbot bot)  : base(bot) 
    {
        Name = "CosplayPlanning";
    }
    protected override void OnEnter()
    {
        Debug.Log("Entered CosplayPlanning state! The bot is now carefully reviewing materials and planning its cosplay!");
    }

    protected override IEnumerator OnStart()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Planning for cosplay...");
        fsm.Transition(Bot.isSponsored ? Bot.State_Photoshoot : Bot.State_Wander);
    }

    protected override void OnExit()
    {
        Debug.Log("Exit CosplayPlanning state! The bot has finished planning!");
    }
}