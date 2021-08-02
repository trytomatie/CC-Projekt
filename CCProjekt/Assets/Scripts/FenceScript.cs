using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    public float speedModifer = 0.1f;

    /// <summary>
    /// Slows Enemys on enter
    /// By Christian Scherzer
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<StatusManager>().movementspeedModifier = speedModifer;
        }
    }

    /// <summary>
    /// Sets Enemy speed back to 100%
    /// By Christian Scherzer
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<StatusManager>().movementspeedModifier = 1;
        }
    }
}
