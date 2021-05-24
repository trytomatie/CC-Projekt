using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_CropSeed_Wheat : Item
{

    public Item_CropSeed_Wheat()
    {
        itemName = "Wheat seed";
        stackSize = 1;
        itemDescription = "Can be used to plant Wheat.";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(2);
    }
}
