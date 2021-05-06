using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public TextMeshProUGUI itemUI;
    private void Start()
    {
        AddItem(ScriptableObject.CreateInstance<Item_CropSeed_Corn>());
        AddItem(ScriptableObject.CreateInstance<Item_CropSeed_Carrot>());
    }

    public void Update()
    {

    }


    /// <summary>
    /// Add Item to Inventory
    /// - By Chstian Scherzer
    /// </summary>
    /// <param name="itemToAdd"></param>
    public void AddItem(Item itemToAdd)
    {
        itemToAdd.attachedInventory = this;
        foreach (Item item in items)
        {
            if(item.itemName == itemToAdd.itemName)
            {
                item.stackSize += itemToAdd.stackSize;
                return;
            }
        }
        items.Add(itemToAdd);
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
    public void RemoveItem(Item itemToRemove, int ammount)
    {
        foreach (Item item in items)
        {
            if (item.itemName == itemToRemove.itemName)
            {
                if (item.stackSize >= ammount)
                {
                    item.stackSize -= ammount;
                    if (item.stackSize == 0)
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
}
