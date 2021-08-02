using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    public int stackSize;
    public string itemDescription;
    public Sprite sprite;
    public ItemType itemType;
    public InventoryManager attachedInventory;
    public int creditValue = 0;
    public enum ItemType {Seed,Crop,Other};

}
