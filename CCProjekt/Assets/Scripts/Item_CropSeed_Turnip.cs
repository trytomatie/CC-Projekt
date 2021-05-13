using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_CropSeed_Turnip : Item
{

    public Item_CropSeed_Turnip()
    {
        itemName = "Turnip seed";
        stackSize = 1;
        itemDescription = "Turnip seed";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(4);
    }
}
