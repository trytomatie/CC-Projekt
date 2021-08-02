using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 goalPosition;
        // Set goalPosition to target.position + offset
        goalPosition = target.localPosition + offset;
        // Lerp current position to camera position
        Vector3 lerpedPositon = new Vector3(Mathf.Lerp(transform.position.x, goalPosition.x, 0.1f)
            , Mathf.Lerp(transform.position.y, goalPosition.y, 0.1f)
            , Mathf.Lerp(transform.position.z, goalPosition.z, 0.1f));
        transform.position = lerpedPositon;
    }
}
