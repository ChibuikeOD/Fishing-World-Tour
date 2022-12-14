using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Player's caught fish
    private FishInfo[] caughtFish = new FishInfo[10];
    //Number of unique species the player has caught
    private int species = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance { get; private set; }

    //Add a fish to the caughtFish array
    public void AddFish(FishInfo newFish)
    {
        caughtFish[species] = newFish;
        species++;

        for (int i = 0; i < 10; i++)
        {
            Debug.Log(caughtFish[i]);
        }
    }

    //Check if the fish given has been caught, true if it has been caught, false if not
    public bool hasFishBeenCaught(FishInfo fish)
    {
        //Player has no new species up until now, the fish can be added by default
        if (species == 0)
        {
            return false;
        }

        for (int i = 0; i < species; i++)
        {
            //The fish exists in the array, it has been caught
            if (fish == caughtFish[i])
            {
                return true;
            }
        }

        return false;
    }

    public int getSpecies()
    {
        return species;
    }

    public FishInfo returnFish(int index)
    {
        return caughtFish[index];
    }
}
