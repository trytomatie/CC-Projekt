using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropMelon : Item
{

    public ItemCropMelon()
    {
        itemName = "Melon";
        stackSize = 1;
        itemDescription = "Melon";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(3);
        creditValue = 40;
    }
}
