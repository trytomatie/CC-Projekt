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
        interactableText = "Buy <color=yellow>" + item.itemName + "</color> " + item.creditValue + " credits";
    }
    /// <summary>
    /// Buys item for credits
    /// By Christian Scherzer
    /// </summary>
    /// <param name="interactor"></param>
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
