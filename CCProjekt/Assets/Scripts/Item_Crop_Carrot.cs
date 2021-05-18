using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Crop_Carrot : Item
{

    public Item_Crop_Carrot()
    {
        itemName = "Carrot";
        stackSize = 1;
        itemDescription = "Carrot";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(1);
        creditValue = 10;
    }
}
