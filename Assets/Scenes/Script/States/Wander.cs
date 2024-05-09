using System.Collections;
using FSM;
using UnityEngine;

public class Wander : CosbotState
{
    bool nearbyMerchStore = false;
    bool nearbyCosbot = false;
    public Wander(Cosbot bot)  : base(bot) 
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

    protected override IEnumerator OnStart()
    {
        yield return 0;
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
    }

    protected override void OnExit()
    {
        Debug.Log("Exit Wander state! The convention has come to an end.");
    }
}