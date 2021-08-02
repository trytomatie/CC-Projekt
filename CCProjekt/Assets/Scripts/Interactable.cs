using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isEnabled = true;
    public string interactableText = "...";
    public enum InteractionType { Mouse, Direct}
    public InteractionType interactionType = InteractionType.Direct;

    /// <summary>
    /// Virtual method for Interaction
    /// By Christian Scherzer
    /// </summary>
    /// <param name="interactor"></param>
    public virtual void Interact(GameObject interactor)
    {
        
    }
}
