using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallmouthBass : FishInfo
{
    public override void Reset()
    {
        name = "Smallmouth Bass";

        fishStrength = 0.50f;
        chanceToChange = 20.0f;

        journalPage = Resources.Load<Sprite>("Pages/Smallmouth Bass");
    }
}
