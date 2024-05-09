using System.Collections;
using FSM;
using UnityEngine;

public class QueryAnime : CosbotState
{
    
    public QueryAnime(Cosbot bot)  : base(bot) 
    {
        // Name = "QueryAnime";
    }
    protected override void OnEnter()
    {
        // Debug.Log("Entered Query Anime state!, Querying for anime to watch...");
    }

    protected override IEnumerator OnStart(){
        Debug.Log("QUERY_ANIME: Picking anime to watch...");

        yield return new WaitForSeconds(0.5f);
        fsm.Transition(Bot.State_WatchAnime);
    }

    protected override void OnExit()
    {
        // Debug.Log("Exited Query Anime state!, Found anime to watch!");
    }

}