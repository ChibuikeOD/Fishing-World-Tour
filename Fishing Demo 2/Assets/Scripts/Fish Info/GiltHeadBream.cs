using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiltHeadBream : FishInfo
{
    public override void Reset()
    {
        name = "Gilt Head Bream";

        fishStrength = 0.65f;
        chanceToChange = 20.0f;

        journalPage = Resources.Load<Sprite>("Pages/Gilt-head Bream");
    }
}
