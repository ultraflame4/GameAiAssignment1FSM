using FSM;
using UnityEngine;

public class Wander : CosbotState
{
    bool nearbyMerchStore = false;
    bool nearbyCosbot = false;
    public Wander(FiniteStateMachine fsm, Cosbot bot) : base(fsm, bot)
    {
        Name = "Wander";

        Transitions.Add(()=>{
            if (bot.HasConventionEnded){
                return bot.State_PostSocialMedia;
            }
            if (nearbyMerchStore && bot.budget > 0){
                return bot.State_BuyMerch;
            }
            if (nearbyCosbot){
                return bot.State_TakePicture;
            }
            return null;
        });
    }

    protected override void OnEnter()
    {
        Debug.Log("Entered Wander state! The bot is now wandering around the convention centre!");
    }



    protected override void OnExecute()
    {
        // Random walking code here
    }

    protected override void OnExit()
    {
        Debug.Log("Exit Wander state! The convention has come to an end.");
    }
}