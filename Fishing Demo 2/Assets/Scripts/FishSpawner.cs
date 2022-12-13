using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FishSpawner : MonoBehaviour
{
    [SerializeField]
    private int maxNumberOfFish = 1;

    [SerializeField]
    private GameObject fishPrefab;
    [SerializeField]
    private float spawnTime = 5f;

    [SerializeField]
    public FishInfo[] fishInfoArray;

    private bool spawning;

    void Start()
    {
        spawning = false;
        fishInfoArray = new FishInfo[3];
        fishInfoArray[0] = new SalmonInfo();
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
        Vector3 newSpawnPosition = new Vector3(Random.Range(-10f, 10), Random.Range(-2f, 5), 0);

        //Spawn new fish
        GameObject Fish = Instantiate(fishPrefab, newSpawnPosition, Quaternion.Euler(0, 0, -90));

        //Give new fish its info
        Fish.GetComponent<FishAI>().fishInfo = fishInfoArray[0];
        Debug.Log(Fish.GetComponent<FishAI>().fishInfo);

        //Stop spawning process
        spawning = false;
    }
}