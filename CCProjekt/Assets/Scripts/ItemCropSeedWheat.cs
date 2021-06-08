using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropSeedWheat : Item
{

    public ItemCropSeedWheat()
    {
        itemName = "Wheat seed";
        stackSize = 1;
        itemDescription = "Can be used to plant Wheat.";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(2);
    }
}
