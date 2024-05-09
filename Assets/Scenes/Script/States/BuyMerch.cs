using System.Collections;
using FSM;
using UnityEngine;

public class BuyMerch : CosbotState
{
    public BuyMerch(Cosbot bot)  : base(bot) 
    {
    }

    protected override IEnumerator OnStart()
    {
        Debug.Log("Approaching store...");
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Picking items...");
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Bought items transitioning back to wander...");
        Bot.budget -= 50;
        fsm.Transition(Bot.State_Wander);
    }
}