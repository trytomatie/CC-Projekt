using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Vendor : Interactable
{

    private void Start()
    {
        interactableText = "Sell Crops";
    }
    public override void Interact(GameObject interactor)
    {
        InventoryManager invManager = interactor.GetComponent<InventoryManager>();
        List<Item> itemsToRemove = new List<Item>();
        foreach(Item item in invManager.items)
        {
            if(item.itemType == Item.ItemType.Crop)
            {
                itemsToRemove.Add(item);
            }
        }
        foreach(Item item in itemsToRemove)
        {
            GameManager.instance.Credits += item.stackSize * item.creditValue;
            invManager.RemoveItem(item, item.stackSize);
        }
    }
}
