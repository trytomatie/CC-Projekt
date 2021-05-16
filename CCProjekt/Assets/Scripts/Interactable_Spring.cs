using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Spring : Interactable
{

    public override void Interact(GameObject interactor)
    {
        interactor.GetComponent<PlayerController>().Water = interactor.GetComponent<PlayerController>().maxWater;
    }
}
