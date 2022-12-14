using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPerch : FishInfo
{
    public override void Reset()
    {
        name = "Yellow Perch";

        fishStrength = 0.7f;
        chanceToChange = 25.0f;

        journalPage = Resources.Load<Sprite>("Pages/Yellow Perch");
    }
}
