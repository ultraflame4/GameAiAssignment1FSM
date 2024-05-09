using UnityEngine;
using FSM;
using System.Collections;

public class ReadEmail : CosbotState
{

    public ReadEmail(Cosbot bot)  : base(bot) 
    {
        // Name = "READ_EMAIL";
    }

    protected override void OnEnter()
    {
        // Debug.Log("Entered ReadEmail state! The bot is now picking an email to read.");
    }

    protected override IEnumerator OnStart()
    {
        Debug.Log("READ_EMAIL: Reading email...");
        yield return new WaitForSeconds(1);
        // Debug.Log($"Read email of type {email.type}");
        var email = Bot.ReadEmail();
        switch (email.type)
        {
            case CosbotEmailType.SPONSOR:
                fsm.Transition(Bot.State_SponsorNegotiation);
                break;
            case CosbotEmailType.COLLAB:
                fsm.Transition(Bot.State_CosplayPlanning);
                break;
            default:
                fsm.Transition(Bot.State_QueryAnime);
                break;
        }
 
    
    }

    protected override void OnExit()
    {
        // Debug.Log("Exit ReadEmail state!");
    }
}