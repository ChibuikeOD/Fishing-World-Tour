using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite floatingBobber;
    public Sprite nibbleBobber;
    public Sprite biteBobber;

    public bool sunk;
    public bool hooking;
    public bool occupied;

    public FishInfo hookedFish;

    // Start is called before the first frame update
    void Start()
    {
        sunk = false;
        hooking = false;
        occupied = false;
    }

    public void NibbleAnimate()
    {
        StartCoroutine(Nibble());
    }

    public void BiteAnimate()
    {
        spriteRenderer.sprite = biteBobber;
    }

    IEnumerator Nibble()
    {
        spriteRenderer.sprite = nibbleBobber;

        yield return new WaitForSeconds(1);
        
        spriteRenderer.sprite = floatingBobber;
    }
}
