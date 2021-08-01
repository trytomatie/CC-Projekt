using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_DroppedField : Interactable
{
    private Item item;
    private void Start()
    {
        interactableText = "Pickup field";
        // Generate Random Seed
        item = (Item)ScriptableObject.CreateInstance("ItemOtherFarmland");
    }
    /// <summary>
    /// Add Random seed to Inventory
    /// </summary>
    /// <param name="interactor"></param>
    public override void Interact(GameObject interactor)
    {
        if(interactor.GetComponent<InventoryManager>().AddItem(item))
        {
            GameManager.Instance.SpawnInterfaceSound(GameManager.Instance.plopSound, 0.2f);
            Destroy(gameObject);
        }
        else
        {
            GameManager.SpawnFloatingText("Cannot pickup any more Items!", transform);
        }
    }
}
