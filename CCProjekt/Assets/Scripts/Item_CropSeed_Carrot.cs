using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_CropSeed_Carrot : Item
{

    public Item_CropSeed_Carrot()
    {
        itemName = "Carrot seed";
        stackSize = 1;
        itemDescription = "Can be used to plant Carrots.";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(1);
    }
}
