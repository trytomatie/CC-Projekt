using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Crop_Corn : Item
{

    public Item_Crop_Corn()
    {
        itemName = "Corn";
        stackSize = 1;
        itemDescription = "Corn";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(0);
        creditValue = 20;
    }
}
