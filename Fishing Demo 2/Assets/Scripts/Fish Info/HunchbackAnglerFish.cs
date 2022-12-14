using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunchbackAnglerFish : FishInfo
{
    public override void Reset()
    {
        name = "Queen Angel Fish";

        fishStrength = 0.75f;
        chanceToChange = 25.0f;

        journalPage = Resources.Load<Sprite>("Pages/Hunchback Anglerfish");
    }
}
