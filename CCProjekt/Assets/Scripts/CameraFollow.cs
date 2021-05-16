using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool avoidCameraCliping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 goalPosition;
        RaycastHit[] hits = Physics.RaycastAll(target.position, ((target.position + offset)- target.position), 5);
        if(hits.Length > 0 && avoidCameraCliping)
        {
            goalPosition = hits[0].point;
        }
        else
        {
            goalPosition = target.localPosition + offset;
        }
        Vector3 lerpedPositon = new Vector3(Mathf.Lerp(transform.position.x, goalPosition.x, 0.1f)
            , Mathf.Lerp(transform.position.y, goalPosition.y, 0.1f)
            , Mathf.Lerp(transform.position.z, goalPosition.z, 0.1f));
        transform.position = lerpedPositon;
    }
}
