using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenAngelfish : FishInfo
{
    public override void Reset()
    {
        name = "Queen Angel Fish";

        fishStrength = 0.50f;
        chanceToChange = 30.0f;

        journalPage = Resources.Load<Sprite>("Pages/Queen Angelfish");
    }
}
