using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropWheat : Item
{

    public ItemCropWheat()
    {
        itemName = "Wheat";
        stackSize = 1;
        itemDescription = "Wheat";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(2);
        creditValue = 60;
    }
}
