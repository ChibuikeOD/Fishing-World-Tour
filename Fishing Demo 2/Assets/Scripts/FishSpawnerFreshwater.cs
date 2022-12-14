using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnerFreshwater : MonoBehaviour
{
    [SerializeField]
    private int maxNumberOfFish = 1;

    [SerializeField]
    private GameObject fishPrefab;
    [SerializeField]
    private float spawnTime = 5f;

    private FishInfo[] fishInfoArray;

    private bool spawning;

    void Start()
    {
        spawning = false;
        fishInfoArray = new FishInfo[5];
        fishInfoArray[0] = new Goldfish();
        fishInfoArray[1] = new RainbowTrout();
        fishInfoArray[2] = new SmallmouthBass();
        fishInfoArray[3] = new Walleye();
        fishInfoArray[4] = new YellowPerch();
    }

    void Update()
    {
        //Find the number of fish in the lake right now
        var currentNumberOfFish = GameObject.FindGameObjectsWithTag("Fish").Length;

        //A new fish can spawn in
        if (currentNumberOfFish < maxNumberOfFish && spawning != true)
        {
            StartCoroutine(spawnFish());
        }
    }

    private IEnumerator spawnFish()
    {
        //Prevent this function from being accessed multiple times
        spawning = true;

        //Wait spawnTime seconds
        yield return new WaitForSeconds(spawnTime);

        //Find place fish can spawn
        Vector3 newSpawnPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-2f, 5f), 0);

        //Spawn new fish
        GameObject Fish = Instantiate(fishPrefab, newSpawnPosition, Quaternion.Euler(0, 0, -90));

        //Give new fish its info
        Fish.GetComponent<FishAI>().fishInfo = fishInfoArray[Random.Range(0, 5)];
        Debug.Log(Fish.GetComponent<FishAI>().fishInfo);

        //Stop spawning process
        spawning = false;
    }
}
