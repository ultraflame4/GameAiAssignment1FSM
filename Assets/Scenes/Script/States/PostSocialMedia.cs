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
        Debug.Log("POST_SOCIAL_MEDIA: Posting pictures on social media...");
        yield return new WaitForSeconds(2);
        fsm.Transition(Bot.State_ReadEmail);
    
    }
}