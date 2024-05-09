using FSM;
using UnityEngine;

public class QueryAnime : CosbotState
{
    
    public QueryAnime(FiniteStateMachine fsm, Cosbot bot)  : base(fsm, bot) 
    {
        Name = "QueryAnime";
    }
    protected override void OnEnter()
    {
        Debug.Log("Entered Query Anime state!, Querying for anime to watch...");
    }

    public void OnExecute(){
        fsm.Transition(Bot.State_WatchAnime);
    }

    protected override void OnExit()
    {
        Debug.Log("Exited Query Anime state!, Found anime to watch!");
    }

}