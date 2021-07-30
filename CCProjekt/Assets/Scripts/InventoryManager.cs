using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int inventoryLimit = 5;
    public TextMeshProUGUI itemUI;
    private void Start()
    {
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFence>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFarmland>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFarmland>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFarmland>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFarmland>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFarmland>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFarmland>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFarmland>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFarmland>());
        AddItem(ScriptableObject.CreateInstance<ItemOtherFarmland>());
    }

    public void Update()
    {

    }


    /// <summary>
    /// Add Item to Inventory
    /// - By Chstian Scherzer
    /// </summary>
    /// <param name="itemToAdd"></param>
    public bool AddItem(Item itemToAdd)
    {

        itemToAdd.attachedInventory = this;
        foreach (Item item in items)
        {
            if(item.itemName == itemToAdd.itemName)
            {
                item.stackSize += itemToAdd.stackSize;
                return true;
            }
        }
        if(items.Count < inventoryLimit)
        {
            items.Add(itemToAdd);
            return true;
        }
        return false;

    }

    /// <summary>
    /// Remove Item from Inventory
    /// - By Chrstian Scherzer
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="ammount"></param>
    public void RemoveItem(string itemName,int ammount)
    {
        foreach(Item item in items)
        {
            if(item.itemName == itemName)
            {
                if(item.stackSize >= ammount)
                {
                    item.stackSize -= ammount;
                    if(item.stackSize == 0)
                    {
                        items.Remove(item);
                    }
                    return;
                }
                else
                {
                    print("Not enough stacks");
                }
            }
        }
        print("Item to remove not found");
    }

    /// <summary>
    /// Remove Item from Inventory
    /// - By Chrstian Scherzer
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="ammount"></param>
    public bool RemoveItem(Item itemToRemove, int ammount)
    {
        // Checks items in inventory
        foreach (Item item in items)
        {
            // Checks the Item name for match
            if (item.itemName == itemToRemove.itemName)
            {
                // Checks if enough stacks are present
                if (item.stackSize >= ammount)
                {
                    item.stackSize -= ammount;
                    // if the stacksize reaches 0, remove the item from the inventory
                    if (item.stackSize == 0)
                    {
                        items.Remove(item);
                    }
                    return true;
                }
                else
                {
                    print("Not enough stacks");
                }
            }
        }
        print("Item to remove not found");
        return false;
    }
}
