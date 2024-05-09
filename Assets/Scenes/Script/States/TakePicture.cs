using System.Collections;
using FSM;
using UnityEngine;

public class TakePicture : CosbotState
{
    public TakePicture(Cosbot bot)  : base(bot) 
    {
    }

    protected override IEnumerator OnStart()
    {
        Debug.Log("Approach other Cos-Bot");
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Asking for permission...");
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Taking pictures...");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Finished Taking picture, transition back to wander");
        fsm.Transition(Bot.State_Wander);
    }
}