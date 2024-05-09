using System.Collections;
using FSM;
using UnityEngine;

public class PostSocialMedia : CosbotState
{
    public PostSocialMedia(Cosbot bot)  : base(bot) 
    {
    }

    protected override IEnumerator OnStart()
    {
        Debug.Log("Posting pictures on social media...");
        yield return new WaitForSeconds(2);
        Debug.Log("Finished posting pictures!");
        fsm.Transition(Bot.State_ReadEmail);
    
    }
}