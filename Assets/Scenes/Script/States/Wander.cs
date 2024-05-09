using System.Collections;
using FSM;
using UnityEngine;

public class Wander : CosbotState
{

    public Wander(Cosbot bot) : base(bot)
    {
        // Name = "Wander";

    }

    protected override void OnEnter()
    {
        // Debug.Log("Entered Wander state!");
    }

    public bool CheckForCosBotWithinLineOfSight()
    {
        return Random.value > 0.5;
    }

    protected override IEnumerator OnStart()
    {
        Debug.Log("WANDER: Wandering around the convention centre...");

        bool nearbyMerchStore = Random.value > 0.35;
        bool nearbyCosbot = Random.value > 0.5;

        while (!Bot.HasConventionEnded)
        {
            if (nearbyMerchStore && Bot.budget > 0)
            {
                fsm.Transition(Bot.State_BuyMerch);
            }
            if (nearbyCosbot)
            {
                fsm.Transition(Bot.State_TakePicture);
            }
            yield return new WaitForSeconds(0.1f);
        }
        
        // Debug.Log("Convention ended");
        fsm.Transition(Bot.State_PostSocialMedia);


    }

    protected override void OnExit()
    {
        // Debug.Log("Exit Wander state!");
    }
}