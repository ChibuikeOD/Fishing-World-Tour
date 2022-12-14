using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldfish : FishInfo
{
    public override void Reset()
    {
        name = "Goldfish";

        fishStrength = 0.9f;
        chanceToChange = 10.0f;

        journalPage = Resources.Load<Sprite>("Pages/goldfish");
    }
}
