using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_FreeSeeds : Interactable
{
    public string[] seedDrops;
    private void Start()
    {
        interactableText = "Pickup seed";
    }
    public override void Interact(GameObject interactor)
    {
        interactor.GetComponent<InventoryManager>().AddItem((Item)ScriptableObject.CreateInstance(seedDrops[Random.Range(0,seedDrops.Length)]));
        Destroy(gameObject);
    }
}
