using UnityEngine;

public class Cosbot : MonoBehaviour
{

    public CosbotState Active {get; private set;}
    public CosbotState BuyMerch {get; private set;}
    public CosbotState CosplayPlanning {get; private set;}
    public CosbotState Photoshoot {get; private set;}
    public CosbotState PostSocialMedia {get; private set;}
    public CosbotState QueryAnime {get; private set;}
    public CosbotState ReadEmail {get; private set;}
    public CosbotState SponsoredPanel {get; private set;}
    public CosbotState SponsorNegotiation {get; private set;}

    private FSM.FiniteStateMachine fsm;

    private void Start()
    {
        fsm = new FSM.FiniteStateMachine();
    }
}