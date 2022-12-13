using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishInfo
{
    public string name;

    public float fishStrength; //From 0 (weak) to 1 (strong)
    public float chanceToChange; //From 0 (rare) to 100 (frequent)

    public abstract void Reset();
}
