using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour
{
    public float destroyTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position += new Vector3(0, 200f, 0) * Time.deltaTime;
    }
}
