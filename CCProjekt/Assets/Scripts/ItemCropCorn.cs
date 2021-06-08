using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropCorn : Item
{

    public ItemCropCorn()
    {
        itemName = "Corn";
        stackSize = 1;
        itemDescription = "Corn";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(0);
        creditValue = 20;
    }
}
