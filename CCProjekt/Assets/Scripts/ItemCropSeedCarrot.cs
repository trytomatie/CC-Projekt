using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropSeedCarrot : Item
{

    public ItemCropSeedCarrot()
    {
        itemName = "Carrot seed";
        stackSize = 1;
        itemDescription = "Can be used to plant Carrots.\nValue: 10 credits";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(1);
    }
}
