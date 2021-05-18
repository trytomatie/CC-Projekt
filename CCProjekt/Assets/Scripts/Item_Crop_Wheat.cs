using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Crop_Wheat : Item
{

    public Item_Crop_Wheat()
    {
        itemName = "Wheat";
        stackSize = 1;
        itemDescription = "Wheat";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(2);
        creditValue = 60;
    }
}
