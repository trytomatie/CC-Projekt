using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject ratPrefab;
    public Transform[] spawnpoints;
    public Transform[] caveSpawnpoints;
    public DayNightCycler dnc;

    public float boxRadius;
    public float zRange = 5;
    public GameObject seedPrefab;
    public GameObject fieldPrefab;

    private int timeInterval = 0;
    private int maxTimeInterval = 3;

    private int ratSpawnRate = 1;
    private float ratSpawnRateGrowth = 1;
    // Start is called before the first frame update
    void Start()
    {
        // Sets spawn rate of rats depending on the difficulty
        switch (GameManager.Instance.difficulty)
        {
            case 0:
                maxTimeInterval = 10;
                ratSpawnRateGrowth = 3f;
                break;
            case 1:
                maxTimeInterval = 7;
                ratSpawnRateGrowth = 3f;
                break;
            case 2:
                maxTimeInterval = 6;
                ratSpawnRateGrowth = 4f;
                break;
        }

        InvokeRepeating("SpawnRat", 0f, 1f); // spawns rat at midnight
        Invoke("SpawnMultipleSeeds", 0f); // spawns seeds on the first day
        InvokeRepeating("SpawnMultipleRats", 0f, GameManager.Instance.dayNightCycler.dayLenght); // spawns caverats at 12pm
    }

    /// <summary>
    /// spawns rats from midnight until 8am
    /// by Shaina Milde
    /// </summary>
    private void SpawnRat ()
    {
        if (dnc.dayTime > dnc.dayLenght / 2 && dnc.currentDayTimeInMinutes <= 1920)
        {
            if (timeInterval < maxTimeInterval)
            {
                timeInterval = timeInterval + 1;

                return;

            }

            if (timeInterval >= maxTimeInterval)
            {
                timeInterval = 0;
            }

            // Spawn multiple rats depending on Daycount and ratSpawnRateGrowth
            for(int i = 0; i < ratSpawnRate *(int)((DayNightCycler.Instance.dayCount+1) * ratSpawnRateGrowth);i++)
            { 
                int randomPos = Random.Range(0, spawnpoints.Length);

                Instantiate(ratPrefab, spawnpoints[randomPos].position, ratPrefab.transform.rotation);  // spawns rats at a random set spawnpoint
            }
        }
    }

    /// <summary>
    /// checks if location already has an object, if not a seedpack is spawned
    /// by Shaina Milde
    /// </summary>
    private void SpawnSeeds ()
    {
        int i = 0;
        bool placeOccupied = true;

        while (placeOccupied && i < 100) // tries to place seeds in different locations until it succeeds or i reaches 100
        {
            Vector3 randomPosition = new Vector3(Random.Range(-24, -32), 0.1f, Random.Range(5, -30)); //chooses random position to place the seed on
            placeOccupied = Physics.CheckSphere(randomPosition, boxRadius); // checks if randomPosition is occupied by a collider

            if (!placeOccupied) // if area isnt occupied a seed is spawned
            {
                Instantiate(seedPrefab, randomPosition, seedPrefab.transform.rotation);  
            }
           
            i++;
        }

    }
    /// <summary>
    /// spawns 6 seed packs
    /// by Shaina Milde
    /// </summary>
    private void SpawnMultipleSeeds ()
    {
        for (int i = 0; i < 6; i++)
        {
            SpawnSeeds();
        }
    }

    /// <summary>
    /// spawns 5 rats in the cave
    /// by Shaina Milde
    /// </summary>
    private void SpawnMultipleRats ()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomPos = Random.Range(0, caveSpawnpoints.Length);

            GameObject rat = Instantiate(ratPrefab, caveSpawnpoints[randomPos].position, ratPrefab.transform.rotation);
            rat.GetComponent<RatAi>().isCaveRat = true; // set rat to cave rat
        }
    }
}
