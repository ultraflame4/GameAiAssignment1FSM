using System.Collections;
using FSM;
using UnityEngine;



public class Cosbot : MonoBehaviour
{
    public CosbotState State_Wander { get; private set; }
    public CosbotState State_BuyMerch { get; private set; }
    public CosbotState State_CosplayPlanning { get; private set; }
    public CosbotState State_Photoshoot { get; private set; }
    public CosbotState State_PostSocialMedia { get; private set; }
    public CosbotState State_QueryAnime { get; private set; }
    public CosbotState State_ReadEmail { get; private set; }
    public CosbotState State_SponsoredPanel { get; private set; }
    public CosbotState State_SponsorNegotiation { get; private set; }
    public CosbotState State_WatchAnime { get; private set; }
    public CosbotState State_TakePicture { get; private set; }

    public bool isSponsored = false;

    public bool HasConventionEnded {get; private set;} = true;
    public float budget {get; private set;} = 1000;

    private FSM.FiniteStateMachine fsm;


    private void Start()
    {
        fsm = new FSM.FiniteStateMachine();


        State_BuyMerch = new BuyMerch(fsm, this);
        State_CosplayPlanning = new CosplayPlanning(fsm, this);
        State_Photoshoot = new Photoshoot(fsm, this);
        State_PostSocialMedia = new PostSocialMedia(fsm, this);
        State_QueryAnime = new QueryAnime(fsm, this);
        State_ReadEmail = new ReadEmail(fsm, this);
        State_SponsoredPanel = new SponsoredPanel(fsm, this);
        State_SponsorNegotiation = new SponsorNegotiation(fsm, this);
        State_WatchAnime = new WatchAnime(fsm, this);
        State_Wander = new Wander(fsm, this);
        State_TakePicture = new TakePicture(fsm, this);

        fsm.SetInitialState(State_QueryAnime);
        
        fsm.StateChanged += (prev, next)=>{
            if (prev == State_CosplayPlanning){
                // Start convention timer
                StartCoroutine(ConventionCentreTimeCycle_Coroutine());
            }
        };
        
    }


    IEnumerator ConventionCentreTimeCycle_Coroutine(){
        HasConventionEnded = false;
        yield return new WaitForSeconds(2);
        HasConventionEnded = true;
        budget = 1000;
    }
    

    
}