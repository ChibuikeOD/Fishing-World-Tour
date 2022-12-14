using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanSunfish : FishInfo
{
    public override void Reset()
    {
        name = "Ocean Sun Fish";

        fishStrength = 0.5f;
        chanceToChange = 50.0f;

        journalPage = Resources.Load<Sprite>("Pages/Ocean Sunfish");
    }
}
