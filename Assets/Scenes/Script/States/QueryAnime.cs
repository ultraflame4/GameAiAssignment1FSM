using FSM;
using UnityEngine;

public class QueryAnime : CosbotState
{
    
    public QueryAnime(FiniteStateMachine fsm, Cosbot bot)  : base(fsm, bot) 
    {
        Name = "QueryAnime";
        Transitions.Add(()=>bot.State_WatchAnime);
    }
    protected override void OnEnter()
    {
        Debug.Log("Entered Query Anime state!, Querying for anime to watch...");
    }
    protected override void OnExit()
    {
        Debug.Log("Exited Query Anime state!, Found anime to watch!");
    }

}