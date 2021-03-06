using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Spring : Interactable
{

    private void Start()
    {
        interactableText = "Refill water";
    }

    /// <summary>
    /// Refill the Water of the interactor
    /// By Christian Scherzer
    /// </summary>
    /// <param name="interactor"></param>
    public override void Interact(GameObject interactor)
    {
        interactor.GetComponent<PlayerController>().Water = interactor.GetComponent<PlayerController>().maxWater;
    }
}
