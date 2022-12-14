using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowTrout : FishInfo
{
    public override void Reset()
    {
        name = "Rainbow Trout";

        fishStrength = 0.5f;
        chanceToChange = 30.0f;

        journalPage = Resources.Load<Sprite>("Pages/Rainbow Trout");
    }
}
