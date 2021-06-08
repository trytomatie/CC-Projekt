using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropPumpkin : Item
{

    public ItemCropPumpkin()
    {
        itemName = "Pumpkin";
        stackSize = 1;
        itemDescription = "Pumpkin";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(5);
        creditValue = 80;
    }
}
