using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalmonInfo : FishInfo
{
    public override void Reset()
    {
        name = "Salmon";

        fishStrength = 0.5f;
        chanceToChange = 50.0f;
    }
}
