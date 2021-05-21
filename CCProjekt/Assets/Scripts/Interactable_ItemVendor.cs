using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_ItemVendor : Interactable
{
    public string itemName;
    private Item item;
    private void Start()
    {
        item = (Item)ScriptableObject.CreateInstance(itemName);
        interactableText = "Buy" + item.itemName + " " + item.creditValue + " credits";
    }
    public override void Interact(GameObject interactor)
    {
        InventoryManager invManager = interactor.GetComponent<InventoryManager>();
        if(GameManager.Instance.Credits >= item.creditValue)
        { 
            GameManager.Instance.Credits -= item.creditValue;
            invManager.AddItem((Item)ScriptableObject.CreateInstance(itemName));
        }
    }
}
