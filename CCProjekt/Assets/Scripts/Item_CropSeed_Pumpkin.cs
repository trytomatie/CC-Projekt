using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_CropSeed_Pumpkin : Item
{

    public Item_CropSeed_Pumpkin()
    {
        itemName = "Pumpkin seed";
        stackSize = 1;
        itemDescription = "Can be used to plant Pumpkins.";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(5);
    }
}
