using System.Collections;
using FSM;
using UnityEngine;

public class WatchAnime : CosbotState
{
    public float CompletionPercent { get; private set; }
    public WatchAnime(Cosbot bot)  : base(bot) 
    {
        Name = "WatchAnime";
    }
    protected override void OnEnter()
    {
        Debug.Log("Started watching anime!");
  
    }
    protected override IEnumerator OnStart()
    {
        CompletionPercent = 0;
        while (CompletionPercent < 1f){
            CompletionPercent = Mathf.Clamp01(CompletionPercent + 0.25f);
            Debug.Log($"Watch completion: {CompletionPercent * 100}%");
            yield return new WaitForSeconds(0.4f);
        }
        fsm.Transition(Bot.State_CosplayPlanning);
    }

    protected override void OnExit()
    {
        Debug.Log("Finished watching anime!");
    }
}