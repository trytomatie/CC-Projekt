using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject ratPrefab;
    public Transform[] spawnpoints;
    public DayNightCycler dnc;

    public float boxRadius;
    public float zRange = 5;
    public GameObject seedPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRat", 0f, 3f);
        InvokeRepeating("SpawnSeeds", 0f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void SpawnRat ()
    {
        if (dnc.dayTime > dnc.dayLenght / 2)
        {
            int randomPos = Random.Range(0, spawnpoints.Length);

            Instantiate(ratPrefab, spawnpoints[randomPos].position, ratPrefab.transform.rotation);
        }
    }

    void SpawnSeeds ()
    {
        if (!Physics.CheckSphere(transform.position, boxRadius))
        {
            Instantiate(seedPrefab, new Vector3(Random.Range(-24, -32), 15.9f, Random.Range(5, -30)), seedPrefab.transform.rotation);
        }
    }
}
