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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRat", 0f, 3f);
        InvokeRepeating("SpawnMultipleSeeds", 0f, GameManager.Instance.dayNightCycler.dayLenght);
        InvokeRepeating("SpawnMultipleRats", 0f, GameManager.Instance.dayNightCycler.dayLenght);
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    /// <summary>
    /// spawns rats at midnight
    /// </summary>
    private void SpawnRat ()
    {
        if (dnc.dayTime > dnc.dayLenght / 2)
        {
            int randomPos = Random.Range(0, spawnpoints.Length);

            Instantiate(ratPrefab, spawnpoints[randomPos].position, ratPrefab.transform.rotation);
        }
    }

    /// <summary>
    /// checks if location already has an object, if not a seedpack is spawned
    /// </summary>
    private void SpawnSeeds ()
    {
        int i = 0;
        bool placeOccupied = true;

        while (placeOccupied && i < 100)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-24, -32), 0.1f, Random.Range(5, -30));
            placeOccupied = Physics.CheckSphere(randomPosition, boxRadius);

            if (!placeOccupied)
            {
                Instantiate(seedPrefab, randomPosition, seedPrefab.transform.rotation);
            }
           
            i++;
        }

    }
    /// <summary>
    /// spawns up to 6 seed packs
    /// </summary>
    private void SpawnMultipleSeeds ()
    {
        for (int i = 0; i < 6; i++)
        {
            SpawnSeeds();
        }
    }

    private void SpawnMultipleRats ()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomPos = Random.Range(0, caveSpawnpoints.Length);

            Instantiate(ratPrefab, caveSpawnpoints[randomPos].position, ratPrefab.transform.rotation);
        }
    }
}
