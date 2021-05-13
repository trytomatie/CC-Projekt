using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_CropSeed_Wheat : Item
{

    public Item_CropSeed_Wheat()
    {
        itemName = "Wheat seed";
        stackSize = 1;
        itemDescription = "Wheat seed";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(2);
    }
}
