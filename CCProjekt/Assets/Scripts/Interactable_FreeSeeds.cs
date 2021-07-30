using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_FreeSeeds : Interactable
{
    public string[] seedDrops;
    public Item item;
    private void Start()
    {
        interactableText = "Pickup seed";
        // Generate Random Seed
        item = (Item)ScriptableObject.CreateInstance(seedDrops[Random.Range(0, seedDrops.Length)]);
    }
    /// <summary>
    /// Add Random seed to Inventory
    /// </summary>
    /// <param name="interactor"></param>
    public override void Interact(GameObject interactor)
    {
        if(interactor.GetComponent<InventoryManager>().AddItem(item))
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.SpawnFloatingText("Cannot pickup any more Items!", transform);
        }
    }
}
