using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Crop_Pumpkin : Item
{

    public Item_Crop_Pumpkin()
    {
        itemName = "Pumpkin";
        stackSize = 1;
        itemDescription = "Pumpkin";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(5);
        creditValue = 80;
    }
}
