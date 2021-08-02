using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Vendor : Interactable
{
    private AudioSource audioSource;
    private void Start()
    {
        interactableText = "Sell Crops";
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Sell crops from interactor inventory
    /// By Christian Scherzer
    /// </summary>
    /// <param name="interactor"></param>
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
        if(itemsToRemove.Count>0)
        {
            audioSource.Play();
        }
        foreach(Item item in itemsToRemove)
        {
            GameManager.Instance.Credits += item.stackSize * Mathf.RoundToInt(item.creditValue * GameManager.Instance.cropYieldMultipier);
            GameManager.Instance.cropsSold += item.stackSize;
            invManager.RemoveItem(item, item.stackSize);
        }
    }
}
