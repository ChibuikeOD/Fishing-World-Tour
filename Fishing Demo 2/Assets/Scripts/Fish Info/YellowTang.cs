using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTang : FishInfo
{
    public override void Reset()
    {
        name = "Yellow Tang";

        fishStrength = 0.75f;
        chanceToChange = 20.0f;

        journalPage = Resources.Load<Sprite>("Pages/Yellow Tang");
    }
}
