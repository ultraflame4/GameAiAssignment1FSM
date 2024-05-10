using System.Collections;
using FSM;
using UnityEngine;

public class SponsorNegotiation : CosbotState
{
    public SponsorNegotiation(Cosbot bot) : base(bot)
    {
    }

    protected override IEnumerator OnStart()
    {
        Bot.isSponsored = false;
        Debug.Log("SPONSOR_NEGOTIATION: Negotiating with sponsor...");
        yield return new WaitForSeconds(1);
        // 50% - 50% chance of the negotiation failing or succeeding.
        if (Random.value > 0.5f)
        {
            Debug.Log("Negotiations failed.");
            fsm.Transition(Bot.State_ReadEmail);
        }
        else
        {
            Bot.isSponsored = true;
            Debug.Log("Negotiations success!");
            fsm.Transition(Bot.State_CosplayPlanning);
        }

    }
}