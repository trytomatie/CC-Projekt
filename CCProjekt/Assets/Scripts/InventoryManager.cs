using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int selectedItem = 0;
    public TextMeshProUGUI itemUI;
    private void Start()
    {
        AddItem(ScriptableObject.CreateInstance<Item_CropSeed_Corn>());
        AddItem(ScriptableObject.CreateInstance<Item_CropSeed_Carrot>());
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && selectedItem < items.Count-1)
        {
            selectedItem++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && selectedItem > 0)
        {
            selectedItem--;
        }
        if(items.Count == 0)
        {
            itemUI.text = "No Item Selected";
        }
        else
        {
            itemUI.text = "Current Item: " + items[selectedItem].itemName;
        }
    }

    internal Item GetSelectedItem()
    {
        if(items.Count == 0)
        {
            return null;
        }
        return items[selectedItem];
    }


    /// <summary>
    /// Add Item to Inventory
    /// - By Chstian Scherzer
    /// </summary>
    /// <param name="itemToAdd"></param>
    public void AddItem(Item itemToAdd)
    {
        foreach(Item item in items)
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
