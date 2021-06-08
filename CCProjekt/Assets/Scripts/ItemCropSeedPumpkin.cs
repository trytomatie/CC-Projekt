using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropSeedPumpkin : Item
{

    public ItemCropSeedPumpkin()
    {
        itemName = "Pumpkin seed";
        stackSize = 1;
        itemDescription = "Can be used to plant Pumpkins.";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(5);
    }
}
