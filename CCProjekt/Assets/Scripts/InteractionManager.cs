using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Interactable target;
    public TextMeshProUGUI interactionTooltipText;

    private Vector3 tooltipOffset = new Vector3(0, 1, 0);
    private List<Interactable> allInteractablesInRange = new List<Interactable>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && target != null)
        {
            target.Interact(GameObject.Find("Player"));            
        }
    }

    private void LateUpdate()
    {
        target = null;
        float distance = 5;
        foreach(Interactable interactable in allInteractablesInRange)
        {
            float distanceToInteractable = Vector3.Distance(transform.position, interactable.transform.position);
            if (distanceToInteractable < distance && interactable.isEnabled)
            {
                target = interactable;
                interactionTooltipText.transform.position = target.gameObject.transform.position + tooltipOffset;
                distance = distanceToInteractable;

            }
        }
        if(target == null)
        {
            interactionTooltipText.transform.position = new Vector3(0,-100,0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Interactable>() != null)
        { 
            allInteractablesInRange.Add(other.GetComponent<Interactable>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Interactable>() != null)
        {
            allInteractablesInRange.Remove(other.GetComponent<Interactable>());
        }
    }
}
