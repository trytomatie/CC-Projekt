using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Vector3 lastMousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }
    /// <summary>
    /// Aims the player towards mouse Position
    /// by Christian Scherzer
    /// </summary>
    private void Aim()
    {
        {
            // Creates ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            // Casts ray
            RaycastHit[] hits = Physics.RaycastAll(ray);
            // Checks all raycast hits for collision with aim Detector
            foreach (RaycastHit hit in hits)
            {
                // If aim detector is hit, turn player toward impactpoint
                if (hit.collider.tag == "AimDetector")
                {
                    Quaternion currentRotation = transform.rotation;
                    transform.LookAt(hit.point);
                    Quaternion targetRotation = transform.rotation;
                    transform.rotation = Quaternion.Euler(0,  Mathf.LerpAngle(currentRotation.eulerAngles.y,targetRotation.eulerAngles.y,0.04f), 0);
                    break;
                }
            }
        }
        lastMousePos = Input.mousePosition;
    }
}
