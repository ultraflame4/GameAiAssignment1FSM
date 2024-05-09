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
        Debug.Log("Negotiating with sponsor...");
        yield return new WaitForSeconds(1);
        if (Random.value > 0.5f)
        {
            Debug.Log("Negotiations failed.");
            fsm.Transition(Bot.State_ReadEmail);
        }
        else
        {
            Bot.isSponsored = true;
            fsm.Transition(Bot.State_CosplayPlanning);
            Debug.Log("Negotiations success!");
        }

    }
}