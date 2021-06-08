using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropCarrot : Item
{

    public ItemCropCarrot()
    {
        itemName = "Carrot";
        stackSize = 1;
        itemDescription = "Carrot";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(1);
        creditValue = 10;
    }
}
