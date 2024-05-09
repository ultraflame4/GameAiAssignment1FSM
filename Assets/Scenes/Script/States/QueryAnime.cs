using System.Collections;
using FSM;
using UnityEngine;

public class QueryAnime : CosbotState
{
    
    public QueryAnime(Cosbot bot)  : base(bot) 
    {
        Name = "QueryAnime";
    }
    protected override void OnEnter()
    {
        Debug.Log("Entered Query Anime state!, Querying for anime to watch...");
    }

    protected override IEnumerator OnStart(){
        Debug.Log("Picked anime, transitioning to watch");
        fsm.Transition(Bot.State_WatchAnime);
        yield return 0;
    }

    protected override void OnExit()
    {
        Debug.Log("Exited Query Anime state!, Found anime to watch!");
    }

}