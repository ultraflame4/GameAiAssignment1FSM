using UnityEngine;
using FSM;

public class CosplayPlanning : CosbotState
{

    float timeout_secs = 1;
    float timeout_counter = 0;
    public CosplayPlanning(FiniteStateMachine fsm, Cosbot bot) : base(fsm, bot)
    {
        Name = "CosplayPlanning";

        Transitions.Add(() =>
        {
            if (timeout_counter >= timeout_secs)
            {
                return bot.isSponsored ? bot.State_Photoshoot : bot.State_Wander;
            }

            return null;
        });
    }
    protected override void OnEnter()
    {
        Debug.Log("Entered CosplayPlanning state! The bot is now carefully reviewing materials and planning its cosplay!");
        timeout_counter = 0;
    }

    protected override void OnExecute()
    {
        timeout_counter += Time.deltaTime;
    }

    protected override void OnExit()
    {
        Debug.Log("Exit CosplayPlanning state! The bot has finished planning!");
    }
}