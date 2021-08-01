using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;
    public bool isInteractingWithUI;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        { 
            instance = this;
        }
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
