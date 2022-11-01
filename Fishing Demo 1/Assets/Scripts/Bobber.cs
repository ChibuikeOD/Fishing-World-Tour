using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    public bool sunk;
    public bool hooking;

    // Start is called before the first frame update
    void Start()
    {
        sunk = false;
        hooking = false;
    }
}
