using UnityEngine;
using FSM;

public class ReadEmail : CosbotState
{
    float timeout_secs = 1;
    float timeout_counter = 0;

    public ReadEmail(FiniteStateMachine fsm, Cosbot bot) : base(fsm, bot)
    {
        Name = "READ_EMAIL";
    }
    
    protected override void OnEnter()
    {
        Debug.Log("Entered ReadEmail state! The bot is now picking an email to read.");
    }

    protected override void OnExecute()
    {
        timeout_counter += Time.deltaTime;
        if (timeout_counter >= timeout_secs)
        {
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
    }

    protected override void OnExit()
    {
        Debug.Log("Exit ReadEmail state!");
    }
}