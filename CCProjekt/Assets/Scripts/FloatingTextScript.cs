using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour
{
    public float destroyTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        // Destroy text after a set amount of time
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy Floating text if game is over
        if (GameManager.Instance.isGameOver)
        {
            Destroy(gameObject);
        }
        // Moves text up by 200 units every second
        GetComponent<RectTransform>().position += new Vector3(0, 200f, 0) * Time.deltaTime;
    }
}
