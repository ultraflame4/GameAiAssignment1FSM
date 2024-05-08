using FSM;
using UnityEngine;

public class WatchAnime : CosbotState
{
    public float CompletionPercent {get; private set;}
    public WatchAnime(FiniteStateMachine fsm, Cosbot bot)  : base(fsm, bot) 
    {
        Name = "WatchAnime";
        Transitions.Add(()=>{
            if (CompletionPercent >= 1f) return bot.State_CosplayPlanning;
            return null;
        });
    }
    protected override void OnEnter()
    {
        Debug.Log("Started watching anime!");
        CompletionPercent = 0;
    }
    protected override void OnExecute()
    {
        CompletionPercent = Mathf.Clamp01(CompletionPercent + 0.2f * Time.deltaTime);
        Debug.Log($"Watch completion: {CompletionPercent*100}%");
    }

    protected override void OnExit()
    {
        Debug.Log("Finished watching anime!");
    }
}