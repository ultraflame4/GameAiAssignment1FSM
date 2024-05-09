using System;
using System.Collections;
using FSM;
using UnityEngine;



public class Cosbot : FSM.FiniteStateMachine
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

    public bool HasConventionEnded { get; private set; } = true;
    public float budget { get; private set; } = 1000;


    private void Start()
    {
        State_BuyMerch = new BuyMerch(this);
        State_CosplayPlanning = new CosplayPlanning(this);
        State_Photoshoot = new Photoshoot(this);
        State_PostSocialMedia = new PostSocialMedia(this);
        State_QueryAnime = new QueryAnime(this);
        State_ReadEmail = new ReadEmail(this);
        State_SponsoredPanel = new SponsoredPanel(this);
        State_SponsorNegotiation = new SponsorNegotiation(this);
        State_WatchAnime = new WatchAnime(this);
        State_Wander = new Wander(this);
        State_TakePicture = new TakePicture(this);

        SetInitialState(State_ReadEmail);

        StateChanged += (prev, next) =>
        {
            if (prev == State_CosplayPlanning)
            {
                // Start convention timer
                StartCoroutine(ConventionCentreTimeCycle_Coroutine());
            }
            Debug.Log($"FSM STATE CHANGED: {prev} -> {next}");
        };

    }

    IEnumerator ConventionCentreTimeCycle_Coroutine()
    {
        HasConventionEnded = false;
        yield return new WaitForSeconds(5);
        HasConventionEnded = true;
        budget = 1000;
    }

    public CosbotEmail ReadEmail()
    {
        return new CosbotEmail()
        {
            name = Guid.NewGuid().ToString(),
            type = CosbotEmailType.SPAM
        };
        var values = Enum.GetValues(typeof(CosbotEmailType));
        var rand = new System.Random();

        return new CosbotEmail()
        {
            name = Guid.NewGuid().ToString(),
            type = (CosbotEmailType)values.GetValue(rand.Next(values.Length))
        };
    }


}