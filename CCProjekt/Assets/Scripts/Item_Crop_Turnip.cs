using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Crop_Turnip : Item
{

    public Item_Crop_Turnip()
    {
        itemName = "Turnip";
        stackSize = 1;
        itemDescription = "Turnip";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(4);
        creditValue = 120;
    }
}
