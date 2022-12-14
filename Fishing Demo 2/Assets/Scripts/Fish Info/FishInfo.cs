using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishInfo
{
    public string name;

    public float fishStrength; //From 0 (strong) to 1 (weak)
    public float chanceToChange; //From 0 (rare) to 100 (frequent)

    public Sprite journalPage;

    public abstract void Reset();
}
