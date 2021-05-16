using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject ratPrefab;
    public Transform[] spawnpoints;
    public DayNightCycler dnc;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRat", 0f, 3f);
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
}
