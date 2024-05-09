using System.Collections;
using FSM;
using UnityEngine;

public class Photoshoot : CosbotState
{
    public Photoshoot(Cosbot bot)  : base(bot) 
    {
        // Name = "Photoshoot";
    }


    protected override void OnEnter()
    {
        // Debug.Log("Entered Photoshoot state!");
        
    }

    protected override IEnumerator OnStart()
    {
        Debug.Log("PHOTOSHOOT: Doing a professional photoshoot for a collab...");
        yield return new WaitForSeconds(1);
        fsm.Transition(Bot.State_Wander);
    }

    protected override void OnExit()
    {
        // Debug.Log("Exit Photoshoot state! The photoshoot session has ended!");
    }
}