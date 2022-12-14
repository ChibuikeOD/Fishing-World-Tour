using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanSunfish : FishInfo
{
    public override void Reset()
    {
        name = "Ocean Sun Fish";

        fishStrength = 0.25f;
        chanceToChange = 65.0f;

        journalPage = Resources.Load<Sprite>("Pages/Ocean Sunfish");
    }
}
