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
        if (lastMousePos != Input.mousePosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag == "AimDetector")
                {
                    transform.LookAt(hit.point);
                    transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                    break;
                }
            }
        }
        lastMousePos = Input.mousePosition;
    }
}
