using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Crop_Melon : Item
{

    public Item_Crop_Melon()
    {
        itemName = "Melon";
        stackSize = 1;
        itemDescription = "Melon";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(3);
        creditValue = 40;
    }
}
