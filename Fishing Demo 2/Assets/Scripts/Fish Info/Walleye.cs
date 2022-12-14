using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walleye : FishInfo
{
    public override void Reset()
    {
        name = "Walleye";

        fishStrength = 0.7f;
        chanceToChange = 25.0f;

        journalPage = Resources.Load<Sprite>("Pages/Walleye");
    }
}
