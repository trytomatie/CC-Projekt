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
        if(target != null && target.gameObject.activeSelf == false)
        {
            allInteractablesInRange.Remove(target);
            target = null;
        }
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
            if(interactable == null)
            {
                continue;
            }
            float distanceToInteractable = Vector3.Distance(transform.position, interactable.transform.position);
            if (distanceToInteractable < distance && interactable.isEnabled && interactable.interactionType == Interactable.InteractionType.Direct)
            {
                target = interactable;
                interactionTooltipText.GetComponent<TooltipScriptUI>().tooltipTarget = target.transform;
                interactionTooltipText.text = interactable.interactableText;
                distance = distanceToInteractable;

            }
        }
        if(target == null)
        {
            interactionTooltipText.GetComponent<TooltipScriptUI>().tooltipTarget = null;
        }
    }
    /// <summary>
    /// Add Interactables from Interactablelist
    /// by Christian Scherzer
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Interactable>() != null)
        { 
            allInteractablesInRange.Add(other.GetComponent<Interactable>());
        }
    }
    /// <summary>
    /// Remove Interactables from Interactablelist
    /// by Christian Scherzer
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Interactable>() != null)
        {
            allInteractablesInRange.Remove(other.GetComponent<Interactable>());
        }
    }
}
