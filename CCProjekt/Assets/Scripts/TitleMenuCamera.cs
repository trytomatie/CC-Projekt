using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenuCamera : MonoBehaviour
{
    public float speed = 3;

    // Update is called once per frame
    void Update()
    {
        // handels Camera Rotation
        transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);
    }
}
