using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isEnabled = true;
    public string interactableText = "...";
    public enum InteractionType { Mouse, Direct}
    public InteractionType interactionType = InteractionType.Direct;
    public virtual void Interact(GameObject interactor)
    {
        
    }
}
