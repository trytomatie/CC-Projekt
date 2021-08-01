using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropSeedCorn : Item
{

    public ItemCropSeedCorn()
    {
        itemName = "Corn seed";
        stackSize = 1;
        itemDescription = "Can be used to plant Corn.\nValue: 20 credits";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(0);
    }
}
