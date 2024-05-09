using System.Collections;
using FSM;
using UnityEngine;

public class Photoshoot : CosbotState
{

    float timeout_secs = 1;
    float timeout_counter = 0;
    public Photoshoot(Cosbot bot)  : base(bot) 
    {
        Name = "Photoshoot";
    }


    protected override void OnEnter()
    {
        Debug.Log("Entered Photoshoot state! The bot is now at a professional photoshoot nearby the convetion and taking pictures for brands promotions.");
        timeout_counter = 0;
    }

    protected override IEnumerator OnStart()
    {
        yield return new WaitForSeconds(1);
        fsm.Transition(Bot.State_SponsoredPanel);
    }

    protected override void OnExit()
    {
        Debug.Log("Exit Photoshoot state! The photoshoot session has ended!");
    }
}