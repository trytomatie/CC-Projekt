using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_CropSeed_Melon : Item
{

    public Item_CropSeed_Melon()
    {
        itemName = "Melon seed";
        stackSize = 1;
        itemDescription = "Can be used to plant Melons.";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(3);
    }
}
