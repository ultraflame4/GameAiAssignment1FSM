using FSM;
using UnityEngine;

public class Wander : CosbotState
{
    bool nearbyMerchStore = false;
    bool nearbyCosbot = false;
    public Wander(FiniteStateMachine fsm, Cosbot bot) : base(fsm, bot)
    {
        Name = "Wander";

    }

    protected override void OnEnter()
    {
        Debug.Log("Entered Wander state! The bot is now wandering around the convention centre!");
    }

    public bool CheckForCosBotWithinLineOfSight()
    {
        return Random.value > 0.5;
    }

    protected override void OnExecute()
    {

        if (Bot.HasConventionEnded)
        {
            fsm.Transition(Bot.State_PostSocialMedia);
        }
        if (nearbyMerchStore && Bot.budget > 0)
        {
            fsm.Transition(Bot.State_BuyMerch);
        }
        if (nearbyCosbot)
        {
            fsm.Transition(Bot.State_TakePicture);
        }

        // Random walking code here
    }

    protected override void OnExit()
    {
        Debug.Log("Exit Wander state! The convention has come to an end.");
    }
}